using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRush_Final.Data
{
    public class TypingPerformanceCalculator
    {
        private DateTime startTime;
        private int correctChars = 0;
        private int incorrectChars = 0;
        private int totalChars = 0;

        public TypingPerformanceCalculator(DateTime startTime)
        {
            this.startTime = startTime;
        }

        public void AddCorrectCharacter()
        {
            correctChars++;
        }

        public void AddIncorrectCharacter()
        {
            incorrectChars++;
        }

        public void SetTotalCharacters(int total)
        {
            totalChars = total;
        }

        public double CalculateWPM()
        {
            TimeSpan typingTime = DateTime.Now - startTime;
            double minutes = typingTime.TotalMinutes;

            if (minutes == 0) return 0;

            double wordsTyped = correctChars / 5.0;  
            return wordsTyped / minutes;
        }

        public double CalculateAccuracy()
        {
            if (totalChars == 0) return 0;

            return (double)correctChars / totalChars * 100;
        }

        public string GetPerformanceStats()
        {
            double wpm = CalculateWPM();
            double accuracy = CalculateAccuracy();
            return $"WPM: {wpm:F2}\nAccuracy: {accuracy:F2}%\nCorrect Characters: {correctChars}\nIncorrect Characters: {incorrectChars}";
        }
    }

}
