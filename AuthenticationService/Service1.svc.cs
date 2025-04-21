using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Grpc.Core;


namespace AuthenticationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // TODO: Maybe change this to xml... Or remove entirely
        private static readonly string attemptsFilePath = "loginAttempts.txt";

        // Max attempts 5 in a 10 minute window.
        private const int maxAttempts = 5;
        private static readonly TimeSpan attemptWindow = TimeSpan.FromMinutes(10);
        public string Login(string username, string hashedPassword, string userXmlPath) 
         {
            string clientIP = GetClientIP();

            if (IsBlocked(username, clientIP))
            {
                return "Too many login attempts. Please try again later.";
            }

            var users = LoadUsers(userXmlPath);
            bool firstAttemptToday = IsFirstAttemptOfDay(clientIP);

            if (!users.ContainsKey(username))
            {
                LogAttempt(username, clientIP, false);
                return firstAttemptToday ? "Invalid username." : "Invalid username or password.";
            }

            string storedHashed = users[username];
         
            if (storedHashed == hashedPassword)
            {
                LogAttempt(username, clientIP, true);
                return "Login successful.";
            }
            else
            {
                LogAttempt(username, clientIP, false);
                return firstAttemptToday ? "Invalid password." : "Invalid username or password.";
            }
        }
        public string Register(string username, string password, string userXmlPath)
        {
            var users = LoadUsers(userXmlPath);

            string validationError = ValidateUsername(username, users);
            if (!string.IsNullOrEmpty(validationError))
            {
                return validationError;
            }

          //  string hashedPassword = ComputeHash(password);
            SaveUser(userXmlPath, username, password);
            return "Registration successful.";
        }



        private Dictionary<string, string> LoadUsers(string xmlPath)
        {
            if (!File.Exists(xmlPath))
            {
                // Create empty file with root Users tag
                var emptyList = new UserList();
                using (var stream = File.Create(xmlPath))
                {
                    var serializer = new DataContractSerializer(typeof(UserList));
                    serializer.WriteObject(stream, emptyList);
                }

            }
            Dictionary<string, string> users = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (File.Exists(xmlPath))
            {
                var serializer = new DataContractSerializer(typeof(UserList));
                using (var stream = File.OpenRead(xmlPath))
                {
                    var userList = (UserList)serializer.ReadObject(stream);
                    foreach (var user in userList)
                    {
                        users[user.Username] = user.HashedPassword;
                    }
                }
            }
            return users;
        }
        private void SaveUser(string xmlPath, string username, string hashedPassword)
        {
            UserList users = new UserList();

            if (File.Exists(xmlPath))
            {
                var serializer = new DataContractSerializer(typeof(UserList));
                using (var stream = File.OpenRead(xmlPath))
                {
                    users = (UserList)serializer.ReadObject(stream);
                }
            }

            users.Add(new User { Username = username, HashedPassword = hashedPassword });

            using (var stream = File.Create(xmlPath))
            {
                var serializer = new DataContractSerializer(typeof(UserList));
                serializer.WriteObject(stream, users);
            }
        }



        // Appends a single line to the specified file.
        private void AppendLine(string filePath, string line)
        {
            // Use locking to prevent simultaneous writes
            lock (filePath)
            {
                //File.AppendAllText(filePath, line + Environment.NewLine); // I commented out this line so that i can test the porgram !!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }

   

        // Logs a login attempt with a timestamp, username, client IP, and whether it was successful.
        private void LogAttempt(string username, string clientIP, bool success)
        {
            string logLine = string.Format("{0:o},{1},{2},{3}", DateTime.UtcNow, username, clientIP, success);
            AppendLine(attemptsFilePath, logLine);
        }

        // Checks whether there have been too many failed login attempts for the given username and IP.
        private bool IsBlocked(string username, string clientIP)
        {
            if (!File.Exists(attemptsFilePath))
            {
                return false;
            }
            var lines = File.ReadAllLines(attemptsFilePath);
            DateTime cutoff = DateTime.UtcNow - attemptWindow;
            // Count the number of failed attempts
            int count = lines.Count(delegate (string line)
            {
                string[] parts = line.Split(',');
                // if the input is invalid its not an attempt
                if (parts.Length != 4)
                    return false;
                DateTime timestamp;

                if (!DateTime.TryParse(parts[0], out timestamp))
                    return false;
                string logUsername = parts[1];
                string logIP = parts[2];
                bool logSuccess = bool.Parse(parts[3]);

                // If the invalid login was within the 10 minute window, count it
                return timestamp >= cutoff &&
                       logUsername.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                       logIP == clientIP &&
                       !logSuccess;
            });
            return count >= maxAttempts;
        }
        // Retrieves the client's IP address from HttpContext.
        // Have no idea if this actually works because everytime it would just be localhost
        private string GetClientIP()
        {
            try
            {
                string IP = HttpContext.Current.Request.UserHostAddress;
                return IP;
            }
            catch { }
            return "unknown";
        }
        // Helper function ensures that the username doesn't already exist or includes an invalid character
        private string ValidateUsername(string username, Dictionary<string, string> existingUsers)
        {
            if (existingUsers.ContainsKey(username))
            {
                return "User already exists.";
            }
            if (username.Contains(":") || username.Contains(","))
            {
                // These characters are used as delimeters in storage so having a username with this character would break it
                return "Username cannot include characters ':' or ',' ";
            }
            return string.Empty; // Valid username since no errors
        }
        private bool IsFirstAttemptOfDay(string clientIP)
        {
            if (!File.Exists(attemptsFilePath))
            {
                return true;
            }
            var lines = File.ReadAllLines(attemptsFilePath);
            DateTime localToday = DateTime.Now.Date;

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    DateTime timestamp;
                    if (DateTime.TryParseExact(parts[0].Trim(), "o", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal, out timestamp))
                    {
                        // Convert the logged UTC timestamp to local time.
                        DateTime localTimestamp = timestamp.ToLocalTime();


                        if (localTimestamp.Date == localToday && parts[2].Trim() == clientIP)
                        {
                            return false; // Found an attempt from this IP today.
                        }
                    }
                }
            }
            return true;
        }

        public string GetHint(string actualWord, List<int> revealedPositions)
        {
            if (string.IsNullOrEmpty(actualWord)) return "No word provided.";

            for (int i = 0; i < actualWord.Length; i++)
            {
                if (!revealedPositions.Contains(i))
                {
                    revealedPositions.Add(i); 
                    char hintChar = actualWord[i];
                    return $"Hint: The letter at position {i + 1} is '{char.ToUpper(hintChar)}'";
                }
            }

            return "All letters have already been revealed!";
        }

    }


}

