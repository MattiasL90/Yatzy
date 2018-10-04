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
        }
     

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string nameOne = tbOne.Text;
            string nameTwo = tbTwo.Text;
            string nameThree = tbThree.Text;
            SQL s = new SQL();
            int type = GetStyle();
            //if (rbTwoPlayers.IsChecked == true)
            //{
            //    bool one = s.CheckName(nameOne);
            //    bool two = s.CheckName(nameTwo);
            //}
            //else if (rbThreePlayers.IsChecked == true)
            //{
            //    bool one = s.CheckName(nameOne);
            //    bool two = s.CheckName(nameTwo);
            //    bool three = s.CheckName(nameThree);
            //}

            //Classic g = new Classic();
            //Forced f = new Forced();
            if (rbClassic.IsChecked == true)
            {
                Classic g = new Classic();
                CheckGame(nameOne, nameTwo, nameThree, type);
                this.Hide();
                g.addPlayer(nameOne, 1);
                g.addPlayer(nameTwo, 2);
                g.addPlayer(nameThree, 3);
                MainWindow w1 = new MainWindow(g);
                w1.ShowDialog();
                
            }
            else if (rbForced.IsChecked == true)
            {
                Forced g = new Forced();
                CheckGame(nameOne, nameTwo, nameThree, type);
                this.Hide();
                g.addPlayer(nameOne, 1);
                g.addPlayer(nameTwo, 2);
                g.addPlayer(nameThree, 3);
                MainWindow w1 = new MainWindow(g);
                w1.ShowDialog();

            }
        }

        private void CheckGame(string nameOne, string nameTwo, string nameThree, int type)
        {
            SQL s = new SQL();
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

        private void cbThree_Checked(object sender, RoutedEventArgs e)
        {
            if (cbThree.IsChecked == true)
            {
                tbThree.IsEnabled = true;
            }
            else
            {
                tbThree.IsEnabled = false;
            }
        }
    }
}
