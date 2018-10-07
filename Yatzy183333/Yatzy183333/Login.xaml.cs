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
            HighScore();
        }

        public int ppl { get; set; }
        public int type { get; set; }
        int sure = 0;
        SQL s = new SQL();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nameOne = tbOne.Text;
            string nameTwo = tbTwo.Text;
            string nameThree = tbThree.Text;
            int type = GetStyle();
            if (IsIt(nameOne, nameTwo, nameThree) == false)
            {
                if (rbClassic.IsChecked == true)
                {
                    Classic g = new Classic();
                    CheckGame(nameOne, nameTwo, nameThree, type, g);
                    if (sure == 1)
                    {
                        btnLogin.Content = "Fortsätt";

                    }
                    else if (sure == 2)
                    {
                        this.Hide();
                        ppl = CheckCbthree(g, nameOne, nameTwo, nameThree);
                        g.InsertRelationTable();
                        MainWindow w1 = new MainWindow(g, ppl, s, type);
                        w1.ShowDialog();
                    }

                }
                else if (rbForced.IsChecked == true)
                {
                    Forced g = new Forced();
                    CheckGame(nameOne, nameTwo, nameThree, type, g);
                    if (sure == 1)
                    {
                        btnLogin.Content = "Fortsätt";

                    }
                    else if (sure == 2)
                    {
                        this.Hide();
                        ppl = CheckCbthree(g, nameOne, nameTwo, nameThree);
                        g.InsertRelationTable();
                        MainWindow w1 = new MainWindow(g, ppl, s, type);
                        w1.ShowDialog();
                    }

                }
            }
            else
            {
                MessageBox.Show("Du har redan ett spel igång!");
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            string name = tbAddName.Text;
            string nick = tbAddNick.Text;
            s.AddPlayer(name, nick);
            tbAddName.Text = "";
            tbAddNick.Text = "";
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
                    sure = 2;
                }
                else
                {
                    if( one == false)
                    {
                        dbl1.Content = "spelare finns ej i databas";
                    }
                    if (two == false)
                    {
                        dbl2.Content = "spelare finns ej i databas";
                    }
                    sure ++;

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
                    sure = 2;
                }
                else
                {
                    if (one == false)
                    {
                        dbl1.Content = "spelare finns ej i databas";
                    }
                    if (two == false)
                    {
                        dbl2.Content = "spelare finns ej i databas";
                    }
                    if (three == false)
                    {
                        dbl3.Content = "spelare finns ej i databas";
                    }
                    sure ++;
                }
            }
        }

        private int GetStyle()
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

        private int CheckCbthree(Game g, string nameOne, string nameTwo, string nameThree)
        {
            if (cbThree.IsChecked == true)
            {
                g.addPlayer(nameOne, 1);
                g.addPlayer(nameTwo, 2);
                g.addPlayer(nameThree, 3);
                ppl = 3;
            }
            else
            {
                g.addPlayer(nameOne, 1);
                g.addPlayer(nameTwo, 2);
                ppl = 2;
            }
            return ppl;
        }


        private void HighScore()
        {
            dgHighScore.ItemsSource = s.GetHighScore(type);
        }

        private void rbClassic_Checked(object sender, RoutedEventArgs e)
        {
            type = 1;
            HighScore();
        }

        private void rbForced_Checked(object sender, RoutedEventArgs e)
        {
            type = 2;
            HighScore();
        }

        private bool IsIt(string name1, string name2, string name3)
        {
            Classic g = new Classic();
            bool isit = false;
            int p1 = s.GetId(name1);
            int p2 = s.GetId(name2);
            if (p1 > 0 && p2 > 0)
            {
                bool ongoing1 = s.OngoingGame(p1);
                bool ongoing2 = s.OngoingGame(p2);
                if (cbThree.IsChecked == true)
                {
                    int p3 = s.GetId(name3);
                    if (p3 > 0)
                    {
                        bool ongoing3 = s.OngoingGame(p3);
                        if (ongoing1 == true || ongoing2 == true || ongoing3 == true)
                        {
                            isit = true;
                        }
                    }
                }
                else

                if (ongoing1 == true || ongoing2 == true)
                {
                    isit = true;
                }
            }
        
            return isit;
        }

    }
}
