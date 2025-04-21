using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace helper_service
{
   
    public class Service1 : IService1
    {
        // In-memory store for user guess stats (not persistent across server restarts)
        private static Dictionary<string, int> userGuessCounts = new Dictionary<string, int>();

        public string GetHint(string actualWord, List<int> revealedPositions)
        {
            if (string.IsNullOrEmpty(actualWord))
                return "No word provided.";

            for (int i = 0; i < actualWord.Length; i++)
            {
                if (!revealedPositions.Contains(i))
                {
                    char hintChar = actualWord[i];
                    return $"Hint: The letter at position {i + 1} is '{char.ToUpper(hintChar)}'";
                }
            }

            return "All letters have already been revealed!";
        }

       
    }

}
