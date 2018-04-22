using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Quiz
{
    public class Question
    {
        public string[] answers;
        public Question(string answer1, string answer2, string answer3, string answer4, string riddle, string correctAnswer)
        {
            answers = new string[4];
            answers[0] = answer1;
            answers[1] = answer2;
            answers[2] = answer3;
            answers[3] = answer4;
            Riddle = riddle;
            CorrectAnswer = correctAnswer;
        }
        public string CorrectAnswer { get; private set; }
        public string Riddle { get; private set; }
        public bool CheckAnswer(string answer)
        {
            if (answer == CorrectAnswer)
                return true;
            else
                return false;
        }
    }
}
