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
        SQL s = new SQL();

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nameOne = tbOne.Text;
            string nameTwo = tbTwo.Text;
            string nameThree = tbThree.Text;
            //SQL s = new SQL();
            int type = GetStyle();
            if (rbClassic.IsChecked == true)
            {
                Classic g = new Classic();
                CheckGame(nameOne, nameTwo, nameThree, type, g);
                this.Hide();
                ppl = CheckCbthree(g, nameOne, nameTwo, nameThree);
                MainWindow w1 = new MainWindow(g, ppl, s);
                w1.ShowDialog();
            }
            else if (rbForced.IsChecked == true)
            {
                Forced g = new Forced();
                CheckGame(nameOne, nameTwo, nameThree, type, g);
                this.Hide();
                ppl = CheckCbthree(g, nameOne, nameTwo, nameThree);
                MainWindow w1 = new MainWindow(g, ppl, s);
                w1.ShowDialog();
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
                    g.matchid = s.GetMatchId();
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
                    g.matchid = s.GetMatchId();
                }
            }
        }

        private int GetStyle()
        {
            int type = 0;
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
            dgHighScore.ItemsSource = s.GetHighScore();
        }
    }
}
