using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KvízJáték
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> questionNubers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int qNum = 0;
        int i;
        int score;


        public MainWindow()
        {
            InitializeComponent();
            StartGame();
            NextQuestion();
        }

        
        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            MessageBox.Show(senderButton.Tag.ToString());
            if (senderButton.Tag.ToString() == "1")
            {
                score++;
                scoreText.Content = "Jól válaszoltál!" + score + "/" + questionNubers.Count;
            }
            qNum++;
            if (score == 10)
            {
                MessageBox.Show("Sikeresen oldottad meg a kvízt!" + Environment.NewLine + "Nyomd meg az OK gombot az újrakezdéshez!");
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            else if (qNum == 10)
            {
                MessageBox.Show("Hibás, próbáld újra!" + Environment.NewLine + "Nyomd meg az OK gombot az újrakezdéshez!");
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
            NextQuestion();

        }

        private void NextQuestion()
        {
            if (qNum < questionNubers.Count)
            {
                i = questionNubers[qNum];
            }
            else
            {
                RestartGame();
            }


            foreach (var x in mycanvas.Children.OfType<Button>()) 
            {
                x.Tag = "0";
                x.Background = Brushes.Black;
            }

            switch (i)
            {
                case 1:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Peugeot 206";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans2.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/206.jpg"));

                    break;

                case 2:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Volkswagen Golf MK V";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans2.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/golf5.jpg"));

                    break;

                case 3:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Answer2";
                    ans3.Content = "Lamborghini Huracan Performante";
                    ans4.Content = "Answer4";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/huracan.jpg"));

                    break;

                case 4:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Answer2";
                    ans3.Content = "Answer3";
                    ans4.Content = "Opel Insignia";

                    ans4.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/insignia.jpg"));

                    break;

                case 5:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Tesla Model 3";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans2.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/model3.jpg"));

                    break;

                case 6:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Skoda Octavia";
                    ans2.Content = "Answer2 ";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans1.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/octavia.jpg"));

                    break;

                case 7:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Answer2 ";
                    ans3.Content = "Answer3";
                    ans4.Content = "Fiat Polski";

                    ans4.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/polski.jpg"));

                    break;

                case 8:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Toyota Pryus";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans2.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/pryus.jpg"));

                    break;

                case 9:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "Answer1";
                    ans2.Content = "Answer2 ";
                    ans3.Content = "Audi RS6 avant";
                    ans4.Content = "Answer4";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/rs6.jpg"));

                    break;

                case 10:

                    txtQuestion.Text = "Milyen tipusú autó látható a képen?";

                    ans1.Content = "BMW x5";
                    ans2.Content = "Answer2 ";
                    ans3.Content = "Answer3";
                    ans4.Content = "Answer4";

                    ans1.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/képek/x5.jpg"));

                    break;
            }
            
        }
    private void RestartGame()
        {
            score = 0;
            qNum = 0;
            StartGame();
        }

        private void StartGame()
        {
            var randomList = questionNubers.OrderBy(ans1 => Guid.NewGuid()).ToList();

            questionNubers = randomList;

            questionOrder.Content = null;

            for (int i = 0; i < questionNubers.Count; i++)
            {
                questionOrder.Content += " " + questionNubers[i].ToString();
            }
        }
    }
}
