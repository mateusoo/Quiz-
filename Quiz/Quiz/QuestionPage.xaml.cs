using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        CapitalsQuiz capitalsQuiz;
        Question[] questions;
        DispatcherTimer timer;
        public QuestionPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            startGame();   
        }

        private void startGame()
        {
            questions = new Question[10];
            questions[0] = new Question("Warszawa", "Lublin", "Gdańsk", "Kraków",
                "Stolica Polski to ", "Warszawa");
            questions[1] = new Question("Rio de Janeiro", "Rio Bravo", "Brasilia",
                "Sao Paulo", "Stolica Brazylii to ", "Brasilia");
            questions[2] = new Question("Istambuł", "Antalya", "Stambuł", "Ankara",
                "Stolica Turcji to ", "Ankara");
            questions[3] = new Question("Male", "Dżakarta", "Singapur", "Kuala Lumpur",
                "Stolica Indonezji to ", "Dżakarta");
            questions[4] = new Question("Sydney", "Melbourne", "Brisbane", "Canberra",
                "Stolica Australii to ", "Canberra");
            questions[5] = new Question("Marsylia", "Lyon", "Paryż", "Nicea",
                "Stolica Francji to ", "Paryż");
            questions[6] = new Question("Ottawa", "Toronto", "Montreal", "Quebec",
                "Stolica Kanady to ", "Ottawa");
            questions[7] = new Question("Koszyce", "Preszów", "Żylina", "Bratysława",
                "Stolica Słowacji to ", "Bratysława");
            questions[8] = new Question("Brno", "Ostrawa", "Praga", "Pilzno",
                "Stolica Czech to ", "Praga");
            questions[9] = new Question("Skopje", "Kumanowo", "Bitola", "Tetowo",
                "Stolica Macedonii to ", "Skopje");

            capitalsQuiz = new CapitalsQuiz(questions)
            {
                Answer1Button = answer1,
                Answer2Button = answer2,
                Answer3Button = answer3,
                Answer4Button = answer4,
                QuestionTextBlock = questionTextBlock,
                ResultTextBlock = resultTextBlock,
                RestartButton = restartButton,
                MenuButton = menuButton,
                Timer = timer
            };

            capitalsQuiz.ShowButtons();


            timer.Start();
            capitalsQuiz.UpdateQuiz();
        }

        private void timer_Tick(object sender, object e)
        {
            capitalsQuiz.Time++;
        }

        private void answer1_Click(object sender, RoutedEventArgs e)
        {
            capitalsQuiz.Test(answer1.Content.ToString());
            capitalsQuiz.UpdateQuiz();
        }

        private void answer2_Click(object sender, RoutedEventArgs e)
        {
            capitalsQuiz.Test(answer2.Content.ToString());
            capitalsQuiz.UpdateQuiz();
        }

        private void answer3_Click(object sender, RoutedEventArgs e)
        {
            capitalsQuiz.Test(answer3.Content.ToString());
            capitalsQuiz.UpdateQuiz();
        }

        private void answer4_Click(object sender, RoutedEventArgs e)
        {
            capitalsQuiz.Test(answer4.Content.ToString());
            capitalsQuiz.UpdateQuiz();
        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            startGame();
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
