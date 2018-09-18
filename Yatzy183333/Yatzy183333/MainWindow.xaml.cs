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

namespace Yatzy183333
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] dices = new int[5];
        bool[] savedDice = new bool[5];
        int round = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();

            if (round > 0)
            {
                if (cbOne.IsChecked == true)
                {
                    savedDice[0] = true;
                }
                if (cbTwo.IsChecked == true)
                {
                    savedDice[1] = true;
                }
                if (cbThree.IsChecked == true)
                {
                    savedDice[2] = true;
                }
                if (cbFour.IsChecked == true)
                {
                    savedDice[3] = true;
                }
                if (cbFive.IsChecked == true)
                {
                    savedDice[4] = true;
                }
            }
            dices = g.rollDices(savedDice, dices);
            lblOne.Content = dices[0];
            lblTwo.Content = dices[1];
            lblThree.Content = dices[2];
            lblFour.Content = dices[3];
            lblFive.Content = dices[4];
            round++;
            if (round == 2)
            {
                round = 0;
            }
        }
    }
}
