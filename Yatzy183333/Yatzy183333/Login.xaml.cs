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
            
            Player p = new Player();
            //p.addPlayer(nameOne, 1);

            //p.addPlayer(nameTwo, 2);
            //p.addPlayer(nameThree, 3);
            
            this.Hide();
            MainWindow w1 = new MainWindow(nameOne, nameTwo, nameThree);
            w1.ShowDialog();
        }

    }
}
