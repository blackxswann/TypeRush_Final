using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeRush_Final.Data
{
    public class TestResult
    {
        public int TestId { get; set; }  
        public double WPM { get; set; } 
        public double Accuracy { get; set; }  
        public Dictionary<char, int> MistypedCharacters { get; set; }  
        public int TotalTypedCharacters { get; set; }  
        public int CorrectTypedCharacters { get; set; } 
        public DateTime StartTime { get; set; }  
        public TimeSpan ElapsedTime { get; set; } 

        public TestResult(int testId, double wpm, double accuracy, Dictionary<char, int> mistypedCharacters,
                          int totalTypedCharacters, int correctTypedCharacters, DateTime startTime, TimeSpan elapsedTime)
        {
            TestId = testId;
            WPM = wpm;
            Accuracy = accuracy;
            MistypedCharacters = mistypedCharacters;
            TotalTypedCharacters = totalTypedCharacters;
            CorrectTypedCharacters = correctTypedCharacters;
            StartTime = startTime;
            ElapsedTime = elapsedTime;
        }
    }

}
