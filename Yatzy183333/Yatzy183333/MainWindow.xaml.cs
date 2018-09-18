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
            checkDices();
            dices = g.rollDices(savedDice, dices);
            setLabels();
            round++;
            if (round == 2)
            {
                round = 0;
                setDices();
            }
        }
        public void updateDg()
        {
            Player p = new Player();
            dgList.ItemsSource = null;
            dgList.ItemsSource = p.player;
        }

        public void setLabels()
        {
            lblOne.Content = dices[0];
            lblTwo.Content = dices[1];
            lblThree.Content = dices[2];
            lblFour.Content = dices[3];
            lblFive.Content = dices[4];
        }

        public void setDices()
        {
            savedDice[0] = false;
            savedDice[1] = false;
            savedDice[2] = false;
            savedDice[3] = false;
            savedDice[4] = false;
        }

        public void checkDices()
        {
            if (round > 0)
            {
                if (cbOne.IsChecked == true)
                {
                    savedDice[0] = true;
                }
                else
                {
                    savedDice[0] = false;
                }
                if (cbTwo.IsChecked == true)
                {
                    savedDice[1] = true;
                }
                else
                {
                    savedDice[1] = false;
                }
                if (cbThree.IsChecked == true)
                {
                    savedDice[2] = true;
                }
                else
                {
                    savedDice[2] = false;
                }
                if (cbFour.IsChecked == true)
                {
                    savedDice[3] = true;
                }
                else
                {
                    savedDice[3] = false;
                }
                if (cbFive.IsChecked == true)
                {
                    savedDice[4] = true;
                }
                else
                {
                    savedDice[4] = false;
                }
            }
        }
    }
}
