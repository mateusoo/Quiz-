using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Quiz
{
    public class FlagQuestion : Question
    {
        public BitmapImage Image;
        public FlagQuestion(string answer1, string answer2, string answer3, string answer4, string riddle, 
            string correctAnswer, BitmapImage image) : base(answer1, answer2, answer3, answer4, 
                riddle, correctAnswer)
        {
            Image = image;
        }
    }
}
