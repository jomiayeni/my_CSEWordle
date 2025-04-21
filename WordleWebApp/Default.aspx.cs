using System;
using System.Collections.Generic;

namespace WordleWebApp
{
    public class ServiceEntry
    {
        public string Provider { get; set; }
        public string ComponentType { get; set; }
        public string Operation { get; set; }
        public string Parameters { get; set; }
        public string ReturnType { get; set; }
        public string Description { get; set; }
        public string TryItLink { get; set; }
    }
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblUsername.Text = Session["Username"].ToString();
                // for the log in time
                if (Application["AppStartTime"] != null)
                {
                    lblAppStartTime.Text = "Wordle Web App started at: " + Application["AppStartTime"].ToString();
                }
                if (!IsPostBack)
                {
                    List<ServiceEntry> entries = new List<ServiceEntry>
        {
            new ServiceEntry
            {
                Provider = "Eli Hoffman",
                ComponentType = "Web Service (WSDL)",
                Operation = "Login",
                Parameters = "string username, string hashedPassword, string xmlFile",
                ReturnType = "string",
                Description = "Validates a user's credentials against XML file records",
                TryItLink = "Login.aspx"
            },
            new ServiceEntry
            {
                Provider = "Eli Hoffman",
                ComponentType = "Web Service (WSDL)",
                Operation = "Register",
                Parameters = "string username, string hashedPassword, string xmlFile",
                ReturnType = "string",
                Description = "Adds a username and password to an XML file, to be logged into later",
                TryItLink = "Login.aspx"
            },
            new ServiceEntry
            {
                Provider = "Eli Hoffman",
                ComponentType = "DLL Function",
                Operation = "HashPassword",
                Parameters = "string password",
                ReturnType = "string",
                Description = "Hashes the password using SHA-256",
                TryItLink = "HashPassword.aspx"
            },
            new ServiceEntry
            {
                Provider = "Alex Alvarado",
                ComponentType = "DLL Function",
                Operation = "GenerateWord",
                Parameters = "string filepath",
                ReturnType = "string",
                Description = "This function generates a random word from the list of words in word.txt in app data",
                TryItLink = "Member.aspx"
            },
            new ServiceEntry
            {
                Provider = "Alex Alvarado",
                ComponentType = "Cookies",
                Operation = "Saves username",
                Parameters = "N/A",
                ReturnType = "N/A",
                Description = "When a user registers they can opt in to using cookies and their username will be saved next time they log in",
                TryItLink = "Login.aspx"
            },
            new ServiceEntry
            {
                Provider = "Alex Alvarado/Eli Hoffman",
                ComponentType = "DLL Function",
                Operation = "WordGuessChecker",
                Parameters = "string userGuess, string actualWord",
                ReturnType = "List<WordLetter>",
                Description = "Takes a users guess and the actaul generated word and compares them and creates a list that holds WordLetters that have the status of each letter",
                TryItLink = "Member.aspx"
            },
            new ServiceEntry
            {
                Provider = "Alex Alvarado",
                ComponentType = "DLL Function",
                Operation = "IsValidGuess",
                Parameters = "string filePath, string guess",
                ReturnType = "bool",
                Description = "takes a users guess and checks whether it is in the list of guessable words in words.txt",
                TryItLink = "Staff.aspx"
            },
            new ServiceEntry
            {
                Provider = "Jomi Ayeni", 
                ComponentType = "Web Service (WSDL)",
                Operation = "GetHint",
                Parameters = "string actualWord, List<string> revealedPositions",
                ReturnType = "string",
                Description = "Returns a hint to help the user based on previous guesses and the actual word",
                TryItLink = "Member.aspx" 
            },
            new ServiceEntry
            {
                Provider = "Jomi Ayeni",
                ComponentType = "User control",
                Operation = "Logout window",
                Parameters = "N/A",
                ReturnType = "N/A",
                Description = "Allows user to log out of the game and log in again if you want to",
                TryItLink = "Logout.aspx"
            },
            

        };

                    ServiceDirectoryGrid.DataSource = entries;
                    ServiceDirectoryGrid.DataBind();
                }
            }
            else
            {
                // Not logged in - redirect to login
                Response.Redirect("Login.aspx");

                //lblUsername.Text = "Not Logged in";
            }
        }

        protected void btnGoToMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("Member.aspx");
        }

        protected void btnGoToStaff_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff.aspx");
        }
    }
}
