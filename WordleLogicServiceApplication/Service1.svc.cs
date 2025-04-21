using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WordleLogicServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GenerateWord(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file could not be found.\n", filePath);
            }
            string[] words = File.ReadAllLines(filePath);

            if (words.Length == 0)
            {
                throw new InvalidOperationException("The file is empty.\n");
            }

            Random rand = new Random();
            return words[rand.Next(words.Length)].Trim();
        }
        //Written by Alex Alvarado and edited by Eli Hoffman
        public List<WordLetter> WordGuessChecker(string userGuess, string actualWord)
        {

            //create two lists:
            //1) actual letter to hold each letter and status of actual guess in list
            //2) guess letter to hold each letter and status of guess in list
            List<WordLetter> actualLetter = new List<WordLetter>();
            List<WordLetter> guessLetter = new List<WordLetter>();

            int length = userGuess.Length;

            //adds each letter to the list holding the WordLetter objects
            foreach (char c in actualWord)
            {
                actualLetter.Add(new WordLetter(char.ToUpper(c)));
            }
            foreach (char c in userGuess)
            {
                guessLetter.Add(new WordLetter(char.ToUpper(c)));
            }

            // Get the counts of each letter 
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            for (int i = 0; i < actualWord.Length; i++)
            {
                char c = char.ToUpper(actualWord[i]);
                if (!letterCounts.ContainsKey(c))
                {
                    letterCounts[c] = 0;
                }
                letterCounts[c]++;
            }


            // first check the correct letters
            for (int i = 0; i < length; i++)
            {
                if (char.ToUpper(userGuess[i]) == char.ToUpper(actualWord[i]))
                {
                    guessLetter[i].Status = WordLetter.LetterStatus.CorrectLetter;

                    letterCounts[char.ToUpper(userGuess[i])]--;
                }
            }

            for (int i = 0; i < length; i++)
            {
                // Skip letters already marked as correct
                if (guessLetter[i].Status == WordLetter.LetterStatus.CorrectLetter)
                {
                    continue;
                }

                char letter = char.ToUpper(userGuess[i]);
                // If the letter exists and there's still count left
                if (letterCounts.ContainsKey(letter) && letterCounts[letter] > 0)
                {
                    guessLetter[i].Status = WordLetter.LetterStatus.CorrectLetterWrongSpot;
                    letterCounts[letter]--;
                }
                // This incorrect doesn't mean that the letter is not in the word at all necessarily
                // just that there is not another instance of the letter available
                // or it could be that the letter wasn't in the word at all
                else
                {
                    guessLetter[i].Status = WordLetter.LetterStatus.IncorrectLetter;
                    guessLetter[i].Position = i;
                }
            }

            return guessLetter;

        }

        //Written by Alex Alvarado
        public bool IsValidGuess(string filePath, string guess)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file could not be found.\n", filePath);
            }
            string[] words = File.ReadAllLines(filePath);

            if (words.Length == 0)
            {
                throw new InvalidOperationException("The file is empty.\n");
            }
            if (words.Contains(guess))
            {
                return true;
            }
            return false;
        }

        //Written by Alex Alvarado
        public List<WordLetter> ConvertToDisplay(List<WordLetter> guess)
        {
            List<WordLetter> display = new List<WordLetter>();
            for (int i = 0; i < guess.Count; i++)
            {
                char displayChar;
                if (guess[i].Status == WordLetter.LetterStatus.CorrectLetter)
                {
                    displayChar = guess[i].Letter;
                }
                else if (guess[i].Status == WordLetter.LetterStatus.CorrectLetterWrongSpot)
                {
                    displayChar = '?';

                }
                else if (guess[i].Status == WordLetter.LetterStatus.IncorrectLetter)
                {
                    displayChar = '_';
                }
                else
                {
                    Console.WriteLine("Something went wrong in convertToDisplay()");
                    displayChar = ' ';
                }
                display.Add(new WordLetter(displayChar));
            }
            return display;
        }

        //Written by Jomi Ayeni
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
