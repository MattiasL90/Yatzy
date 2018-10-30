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
using System.Windows.Shapes;

namespace Yatzy183333
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            SetHighscoreLogin();
        }

        public int ppl { get; set; }
        public int type { get; set; }
        bool sure;
        SQL s = new SQL();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nameOne = tbOne.Text;
            string nameTwo = tbTwo.Text;
            string nameThree = tbThree.Text;
            int type = GetGameType();
            if (DoesOngoingGameExist(nameOne, nameTwo, nameThree) == false)
            {
                if (rbClassic.IsChecked == true)
                {
                    Classic g = new Classic();
                    CheckPlayer(nameOne, nameTwo, nameThree, type, g);
                    if (sure == true)
                    {
                        PlayGame(nameOne, nameTwo, nameThree, type, g);

                    }
                    else if (sure == false)
                    {
                        if (MessageBox.Show("Någon utav spelarna finns inte med i databasen. Vill du ändå fortsätta och spela orankat ? ", "Säkert?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            //do no stuff
                        }
                        else
                        {
                            PlayGame(nameOne, nameTwo, nameThree, type, g);
                        }
                    }

                }
                else if (rbForced.IsChecked == true)
                {
                    Forced g = new Forced();
                    CheckPlayer(nameOne, nameTwo, nameThree, type, g);
                    if (sure == true)
                    {
                        PlayGame(nameOne, nameTwo, nameThree, type, g);

                    }
                    else if (sure == false)
                    {
                        if (MessageBox.Show("Någon utav spelarna finns inte med i databasen. Vill du ändå fortsätta och spela orankat ? ", "Säkert?", MessageBoxButton.YesNo) == MessageBoxResult.No)
                        {
                            //do no stuff
                        }
                        else
                        {
                            PlayGame(nameOne, nameTwo, nameThree, type, g);
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Du har redan ett spel igång!");
            }
        }
        private void PlayGame(string nameOne, string nameTwo, string nameThree, int type, Game g)
        {
            this.Hide();
            ppl = CheckPlayerCount(g, nameOne, nameTwo, nameThree);
            CheckGame(nameOne, nameTwo, nameThree, type, g);
            g.InsertRelationTable();
            MainWindow w1 = new MainWindow(g, ppl, s, type);
            w1.ShowDialog();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string name = tbAddName.Text;
            string nick = tbAddNick.Text;
            s.AddPlayer(name, nick);
            tbAddName.Text = "";
            tbAddNick.Text = "";
        }

        private void CheckPlayer(string nameOne, string nameTwo, string nameThree, int type, Game g)
        {
            bool one = false;
            bool two = false;
            bool three = false;
            if (cbThree.IsChecked == false)
            {
                one = s.CheckName(nameOne);
                two = s.CheckName(nameTwo);
                if (one == true && two == true)
                {
                    sure = true;
                }
                else
                {
                    if( one == false)
                    {
                        dbl1.Content = "Spelare finns ej i databas";
                    }
                    else
                    {
                        dbl1.Content = "";
                    }
                    if (two == false)
                    {
                        dbl2.Content = "Spelare finns ej i databas";
                    }
                    else
                    {
                        dbl2.Content = "";
                    }
                    sure = false;
                }
            }
            else if (cbThree.IsChecked == true)
            {
                one = s.CheckName(nameOne);
                two = s.CheckName(nameTwo);
                three = s.CheckName(nameThree);
                if (one == true && two == true && three == true)
                {
                    sure = true;
                }
                else
                {
                    if (one == false)
                    {
                        dbl1.Content = "Spelare finns ej i databas";
                    }
                    else
                    {
                        dbl1.Content = "";
                    }
                    if (two == false)
                    {
                        dbl2.Content = "Spelare finns ej i databas";
                    }
                    else
                    {
                        dbl2.Content = "";
                    }
                    if (three == false)
                    {
                        dbl3.Content = "Spelare finns ej i databas";
                    }
                    else
                    {
                        dbl3.Content = "";
                    }
                    sure = false;
                }
            }
        }

        private void CheckGame(string nameOne, string nameTwo, string nameThree, int type, Game g)
        {
            bool one = false;
            bool two = false;
            bool three = false;
            if (cbThree.IsChecked == false)
            {
                one = s.CheckName(nameOne);
                two = s.CheckName(nameTwo);
                if (one == true && two == true)
                {
                    s.MakeGame(type); 
                }
            }
            else if (cbThree.IsChecked == true)
            {
                one = s.CheckName(nameOne);
                two = s.CheckName(nameTwo);
                three = s.CheckName(nameThree);
                if (one == true && two == true && three == true)
                {
                    s.MakeGame(type);
                }
            }
        }

        private int GetGameType()
        {
            if (rbClassic.IsChecked == true)
            {
                type = 1;
            }
            else if  (rbForced.IsChecked == true)
            {
                type = 2;
            }
            return type;
        }

        private int CheckPlayerCount(Game g, string nameOne, string nameTwo, string nameThree)
        {
            if (cbThree.IsChecked == true)
            {
                g.AddPlayer(nameOne, 1);
                g.AddPlayer(nameTwo, 2);
                g.AddPlayer(nameThree, 3);
                ppl = 3;
            }
            else
            {
                g.AddPlayer(nameOne, 1);
                g.AddPlayer(nameTwo, 2);
                ppl = 2;
            }
            return ppl;
        }

        private void SetHighscoreLogin()
        {
            dgHighScore.ItemsSource = s.GetHighScore(type);
        }

        private void rbClassic_Checked(object sender, RoutedEventArgs e)
        {
            type = 1;
            SetHighscoreLogin();
        }

        private void rbForced_Checked(object sender, RoutedEventArgs e)
        {
            type = 2;
            SetHighscoreLogin();
        }

        private bool DoesOngoingGameExist(string name1, string name2, string name3)
        {
            Classic g = new Classic();
            bool isit = false;
            bool ongoing1 = g.CheckOngoing(name1);
            bool ongoing2 = g.CheckOngoing(name2);

            if (cbThree.IsChecked == true)
            {
                bool ongoing3 = g.CheckOngoing(name3);
                if (ongoing1 == true || ongoing2 == true || ongoing3 == true)
                {
                    isit = true;
                }
            }
            else
            {
                if (ongoing1 == true || ongoing2 == true)
                {
                    isit = true;
                }
            }
            return isit;
        }
    }
}
