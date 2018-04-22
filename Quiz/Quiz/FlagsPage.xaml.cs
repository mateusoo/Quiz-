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
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlagsPage : Page
    {
        FlagQuestion[] flagsQuestions;
        FlagsQuiz flagsQuiz;
        DispatcherTimer timer;
        string riddle = "Którego państwa jest to flaga?";
        public FlagsPage()
        {
            this.InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            startGame();
        }

        private void timer_Tick(object sender, object e)
        {
            flagsQuiz.Time++;
        }

        private void startGame()
        {
            BitmapImage boliwia = new BitmapImage(new Uri("ms-appx:///Images/flaga-boliwii.png"));
            BitmapImage bosnia = new BitmapImage(new Uri("ms-appx:///Images/flaga-bosnii-i-hercegowiny.png"));
            BitmapImage bulgaria = new BitmapImage(new Uri("ms-appx:///Images/flaga-bulgarii.png"));
            BitmapImage kanada = new BitmapImage(new Uri("ms-appx:///Images/flaga-kanady.png"));
            BitmapImage katar = new BitmapImage(new Uri("ms-appx:///Images/flaga-kataru.png"));
            BitmapImage macedonia = new BitmapImage(new Uri("ms-appx:///Images/flaga-macedonii.png"));
            BitmapImage monako = new BitmapImage(new Uri("ms-appx:///Images/flaga-monako.png"));
            BitmapImage nowaZelandia = new BitmapImage(new Uri("ms-appx:///Images/flaga-nowej-zelandii.png"));
            BitmapImage wegry = new BitmapImage(new Uri("ms-appx:///Images/flaga-wegier.png"));
            BitmapImage wenezuela = new BitmapImage(new Uri("ms-appx:///Images/flaga-wenezueli.png"));

            flagsQuestions = new FlagQuestion[10];
            flagsQuestions[0] = new FlagQuestion("Boliwii", "Meksyku", "Ekwadoru", "Kolumbii", riddle, "Boliwii", boliwia);
            flagsQuestions[1] = new FlagQuestion("Czarnogóry", "Białorusii", "Bośni i Hercegowiny", "Serbii", riddle, "Bośni i Hercegowiny", bosnia);
            flagsQuestions[2] = new FlagQuestion("Rumunii", "Bułgarii", "Chorwacji", "Węgier", riddle, "Bułgarii", bulgaria);
            flagsQuestions[3] = new FlagQuestion("Kanady", "Meksyku", "Stanów Zjednoczonych", "Kostaryki", riddle, "Kanady", kanada);
            flagsQuestions[4] = new FlagQuestion("Armenii", "Afganistanu", "Iraku", "Kataru", riddle, "Kataru", katar);
            flagsQuestions[5] = new FlagQuestion("Norwegii", "Macedonii", "Luksemburga", "Albanii", riddle, "Macedonii", macedonia);
            flagsQuestions[6] = new FlagQuestion("Monako", "Portugalii", "Polski", "Słowenii", riddle, "Monako", monako);
            flagsQuestions[7] = new FlagQuestion("Australii", "Stanów Zjednoczonych", "Fidżi", "Nowej Zelandii", riddle, "Nowej Zelandii", nowaZelandia);
            flagsQuestions[8] = new FlagQuestion("Włoch", "Węgier", "Litwy", "Irlandii", riddle, "Węgier", wegry);
            flagsQuestions[9] = new FlagQuestion("Wenezuelii", "Kolumbii", "Ekwadoru", "Boliwii", riddle, "Wenezuelii", wenezuela);

            flagsQuiz = new FlagsQuiz(null, image, flagsQuestions)
            {
                Answer1Button = answer1,
                Answer2Button = answer2,
                Answer3Button = answer3,
                Answer4Button = answer4,
                QuestionTextBlock = questionTextBlock,
                RestartButton = restartButton,
                ResultTextBlock = resultTextBlock,
                MenuButton = menuButton,
                Timer = timer
                
            };

            flagsQuiz.ShowButtons();
            timer.Start();
            flagsQuiz.UpdateQuiz();
        }

        private void answer1_Click(object sender, RoutedEventArgs e)
        {
            flagsQuiz.Test(answer1.Content.ToString());
            flagsQuiz.UpdateQuiz();
        }

        private void answer2_Click(object sender, RoutedEventArgs e)
        {
            flagsQuiz.Test(answer2.Content.ToString());
            flagsQuiz.UpdateQuiz();
        }

        private void answer3_Click(object sender, RoutedEventArgs e)
        {
            flagsQuiz.Test(answer3.Content.ToString());
            flagsQuiz.UpdateQuiz();
        }

        private void answer4_Click(object sender, RoutedEventArgs e)
        {
            flagsQuiz.Test(answer4.Content.ToString());
            flagsQuiz.UpdateQuiz();
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
