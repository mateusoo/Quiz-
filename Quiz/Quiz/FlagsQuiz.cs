using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Quiz
{
    public class FlagsQuiz : CapitalsQuiz
    {
        Image Image;
        FlagQuestion[] flagsQuestions;
        public FlagsQuiz(Question[] baseQuestions, Image image, FlagQuestion[] flagsQuestions) : base(baseQuestions)
        {
            Image = image;
            this.flagsQuestions = flagsQuestions;
        }

        public override void IsQuestionNull()
        {
            Question = flagsQuestions[NumberOfQuestion];
            if (Question != null)
            {
                ShowQuestionAndAnswers();
            }
        }
        public override void ShowQuestionAndAnswers()
        {
            K = Randomizer.Next(0, 4);
            QuestionTextBlock.Text = flagsQuestions[NumberOfQuestion].Riddle;
            Answer1Button.Content = flagsQuestions[NumberOfQuestion].answers[K];
            Answer2Button.Content = flagsQuestions[NumberOfQuestion].answers[K];
            Answer3Button.Content = flagsQuestions[NumberOfQuestion].answers[K];
            Answer4Button.Content = flagsQuestions[NumberOfQuestion].answers[K];
            Image.Source = flagsQuestions[NumberOfQuestion].Image;
        }
        public override void Test(string answer)
        {
            if (Counter < 10)
            {
                if (flagsQuestions[NumberOfQuestion].CheckAnswer(answer))
                    AmountOfRightAnswers++;
                else
                {
                    WrongAnswers[AmountOfWrongAnswers] = flagsQuestions[NumberOfQuestion].Riddle + flagsQuestions[NumberOfQuestion].CorrectAnswer;
                    AmountOfWrongAnswers++;
                }

                flagsQuestions[NumberOfQuestion] = null;
            }
            Counter++;
        }
        public override void End()
        {
            ResultTextBlock.Text = "Ilość prawidłowych odpowiedzi: " + AmountOfRightAnswers + "/10"
                + "\nCzas: " + Time + "s";
            ShowResult();
        }
        public override void ShowResult()
        {
            ResultTextBlock.Visibility = Visibility.Visible;
            RestartButton.Visibility = Visibility.Visible;
            MenuButton.Visibility = Visibility.Visible;
            QuestionTextBlock.Visibility = Visibility.Collapsed;
            Answer1Button.Visibility = Visibility.Collapsed;
            Answer2Button.Visibility = Visibility.Collapsed;
            Answer3Button.Visibility = Visibility.Collapsed;
            Answer4Button.Visibility = Visibility.Collapsed;
            Image.Visibility = Visibility.Collapsed;
        }
        public override void ShowButtons()
        {
            ResultTextBlock.Visibility = Visibility.Collapsed;
            RestartButton.Visibility = Visibility.Collapsed;
            MenuButton.Visibility = Visibility.Collapsed;
            QuestionTextBlock.Visibility = Visibility.Visible;
            Answer1Button.Visibility = Visibility.Visible;
            Answer2Button.Visibility = Visibility.Visible;
            Answer3Button.Visibility = Visibility.Visible;
            Answer4Button.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Visible;
        }
    }
}
