using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Quiz
{
    public class CapitalsQuiz
    {
        public Random Randomizer;
        public string[] WrongAnswers;
        public int AmountOfWrongAnswers;
        public Question Question;
        public TextBlock QuestionTextBlock;
        public Button Answer1Button;
        public Button Answer2Button;
        public Button Answer3Button;
        public Button Answer4Button;
        public Button RestartButton;
        public Button MenuButton;
        public TextBlock ResultTextBlock;
        public DispatcherTimer Timer;
        int k;
        Question[] questions;

        public CapitalsQuiz(Question[] questions)
        {
            this.questions = questions;
            Randomizer = new Random();
            AmountOfRightAnswers = 0;
            Counter = 0;
            Question = null;
            Time = 0;
            WrongAnswers = new string[10];
            AmountOfWrongAnswers = 0;
        }

        public int NumberOfQuestion { get; set; }
        public int AmountOfRightAnswers { get; set; }
        public int Counter { get; set; }  // licznik wyświetlonych pytań
        public int Time { get; set; }
        public int K                // właściwość potrzebna do zmiany kolejności wyświetlania odpowiedzi
        {
            get
            {
                k++;
                if (k > 3)
                    k = 0;
                return k;
            }
            set
            {
                k = value;
            }
        }

        public void UpdateQuiz()
        {
            if (Counter > 9) // gdy wszystkie pytania zostały wyświetlone, wyświetla wynik
            {
                Timer.Stop();
                End();
            }
            else
            {
                do
                {
                    // losowe pytanie, szuka pytania dopóki wszystkie pytania nie zostaną użyte
                    NumberOfQuestion = Randomizer.Next(0, 10);
                    IsQuestionNull();
                } while ((Question == null) && (Counter < 10));
            }
        }

        public virtual void IsQuestionNull()
        {
            Question = questions[NumberOfQuestion];
            if (Question != null)
            {
                ShowQuestionAndAnswers();
            }
        }

        public virtual void ShowQuestionAndAnswers()
        {
            K = Randomizer.Next(0, 4);
            QuestionTextBlock.Text = questions[NumberOfQuestion].Riddle;
            Answer1Button.Content = questions[NumberOfQuestion].answers[K];
            Answer2Button.Content = questions[NumberOfQuestion].answers[K];
            Answer3Button.Content = questions[NumberOfQuestion].answers[K];
            Answer4Button.Content = questions[NumberOfQuestion].answers[K];
        }

        public virtual void Test(string answer)
        {
            if (Counter < 10)
            {
                if (questions[NumberOfQuestion].CheckAnswer(answer))
                    AmountOfRightAnswers++;
                else
                {
                    WrongAnswers[AmountOfWrongAnswers] = questions[NumberOfQuestion].Riddle + questions[NumberOfQuestion].CorrectAnswer;
                    AmountOfWrongAnswers++;
                }

                questions[NumberOfQuestion] = null;
            }
            Counter++;
        }
        public virtual void End()
        {
            ResultTextBlock.Text = "Ilość prawidłowych odpowiedzi: " + AmountOfRightAnswers + "/10" 
                + "\nCzas: " + Time +"s";
            if (AmountOfRightAnswers < 10)
            {
                ResultTextBlock.Text += "\n\nIlość nieprawidłowych odpowiedzi: " + AmountOfWrongAnswers;
                ResultTextBlock.Text += "\n\nPrawidłowe odpowiedzi to:";
                for (int i = 0; i < AmountOfWrongAnswers; i++)
                {
                    ResultTextBlock.Text += "\n" + WrongAnswers[i];
                }
            }
            ShowResult();
        }
        public virtual void ShowResult()
        {
            ResultTextBlock.Visibility = Visibility.Visible;
            RestartButton.Visibility = Visibility.Visible;
            MenuButton.Visibility = Visibility.Visible;
            QuestionTextBlock.Visibility = Visibility.Collapsed;
            Answer1Button.Visibility = Visibility.Collapsed;
            Answer2Button.Visibility = Visibility.Collapsed;
            Answer3Button.Visibility = Visibility.Collapsed;
            Answer4Button.Visibility = Visibility.Collapsed;
        }
        public virtual void ShowButtons()
        {
            ResultTextBlock.Visibility = Visibility.Collapsed;
            RestartButton.Visibility = Visibility.Collapsed;
            MenuButton.Visibility = Visibility.Collapsed;
            QuestionTextBlock.Visibility = Visibility.Visible;
            Answer1Button.Visibility = Visibility.Visible;
            Answer2Button.Visibility = Visibility.Visible;
            Answer3Button.Visibility = Visibility.Visible;
            Answer4Button.Visibility = Visibility.Visible;
        }
    }
}
