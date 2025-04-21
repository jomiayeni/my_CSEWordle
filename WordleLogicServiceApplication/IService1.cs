using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WordleLogicServiceApplication
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GenerateWord(string filePath);

        [OperationContract]
        bool IsValidGuess(string filePath, string guess);

        [OperationContract]
        List<WordLetter> WordGuessChecker(string userGuess, string actualWord);

        [OperationContract]
        List<WordLetter> ConvertToDisplay(List<WordLetter> guess);

    }
    [DataContract]
    public class WordLetter
    {
        [DataMember]
        public char Letter { get; set; }

        [DataMember]
        public LetterStatus Status { get; set; }

        [DataMember]
        public int Position { get; set; }

        public enum LetterStatus
        {
            Unknown = 0,
            CorrectLetter = 1,
            CorrectLetterWrongSpot = 2,
            IncorrectLetter = 3
        }

        public WordLetter(char letter)
        {
            Letter = letter;
            Status = LetterStatus.Unknown;
            Position = 0;
        }
    }
}

