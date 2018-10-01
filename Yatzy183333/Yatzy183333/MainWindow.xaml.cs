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

        bool[] savedDice = new bool[5];
        Player p = new Player();
        Game g;
        

        public MainWindow(Game game)
        {
            InitializeComponent();
            g = game;
            updateDg();
            playerLb.Content = g.nameCount(g.players());
        }


        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            checkDices();
            g.rollDices(savedDice);
            setLabels();
            rollLb.Content = "slag nr "+ (g.round);
            if (g.round == 3)
            {
                btnRoll.IsEnabled = false;
                btnSave.IsEnabled = true;
            }
            updateDg();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int type = checkSave();
            ////int score = checkScore();
            //g.putScore(type);
            ////if (players < 3)    //Game
            ////{
            ////    players++;
            ////}
            ////else if (players == 3)
            ////{
            ////    players = 1;
            ////}
            //g.resetDices();
            //btnSave.IsEnabled = false;
            //btnRoll.IsEnabled = true;
            //resetCb();
            //rollLb.Content = "slag nr " + g.round;
            //playerLb.Content = g.nameCount(g.players());
            //setLabels();
            //g.bonusCheck();
            //updateDg();
            int type = checkSave();
            if (g.checkScore(type))
            {
                g.putScore(type);
                g.resetDices();
                btnSave.IsEnabled = false;
                btnRoll.IsEnabled = true;
                resetCb();
                rollLb.Content = "Slag nr: " + g.round;
                playerLb.Content = g.nameCount(g.players());
                setLabels();
                g.bonusCheck();
                updateDg();
            }
            else
            {
                MessageBox.Show("Det fungerar inte.");
            }
        }

        //public void trueScore()
        //{
        //    int type = checkSave();
        //    bool check = false;
        //    if (g.checkScore(type) == true)
        //    {
        //        int type = checkSave();
        //        g.putScore(type);
        //        g.resetDices();
        //        btnSave.IsEnabled = false;
        //        btnRoll.IsEnabled = true;
        //        resetCb();
        //        rollLb.Content = "slag nr " + g.round;
        //        playerLb.Content = g.nameCount(g.players());
        //        setLabels();
        //        g.bonusCheck();
        //        updateDg();
        //    }
            
        //}

        public void resetCb()
        {
            if (cbOne.IsChecked == true)
            {
                cbOne.IsChecked = false;
            }
            if (cbTwo.IsChecked == true)
            {
                cbTwo.IsChecked = false;
            }
            if (cbThree.IsChecked == true)
            {
                cbThree.IsChecked = false;
            }
            if (cbFour.IsChecked == true)
            {
                cbFour.IsChecked = false;
            }
            if (cbFive.IsChecked == true)
            {
                cbFive.IsChecked = false;
            }
        }

        //public int checkScore()   //Game
        //{
        //    int score = 0;
        //    if (cbOne.IsChecked == true)
        //    {
        //        int s = g.dices[0];
        //        score = score + s;
        //    }
        //    if (cbTwo.IsChecked == true)
        //    {
        //        int s = g.dices[1];
        //        score = score + s;
        //    }
        //    if (cbThree.IsChecked == true)
        //    {
        //        int s = g.dices[2];
        //        score = score + s;
        //    }
        //    if (cbFour.IsChecked == true)
        //    {
        //        int s = g.dices[3];
        //        score = score + s;
        //    }
        //    if (cbFive.IsChecked == true)
        //    {
        //        int s = g.dices[4];
        //        score = score + s;
        //    }
        //    return score;
        //}

        public int checkSave()
        {
            int saved = 0;
            if (rbOnes.IsChecked == true)
            {
                saved = 1;
            }
            else if (rbTwos.IsChecked == true)
            {
                saved = 2;
            }
            else if (rbThrees.IsChecked == true)
            {
                saved = 3;
            }
            else if (rbFours.IsChecked == true)
            {
                saved = 4;
            }
            else if (rbFives.IsChecked == true)
            {
                saved = 5;
            }
            else if (rbSixes.IsChecked == true)
            {
                saved = 6;
            }
            else if (rbPair.IsChecked == true)
            {
                saved = 7;
            }
            else if (rbTwopair.IsChecked == true)
            {
                saved = 8;
            }
            else if (rbTriads.IsChecked == true)
            {
                saved = 9;
            }
            else if (rbQuads.IsChecked == true)
            {
                saved = 10;
            }
            else if (rbHouse.IsChecked == true)
            {
                saved = 11;
            }
            else if (rbLadderl.IsChecked == true)
            {
                saved = 12;
            }
            else if (rbLadderb.IsChecked == true)
            {
                saved = 13;
            }
            else if (rbChance.IsChecked == true)
            {
                saved = 14;
            }
            else if (rbYatzy.IsChecked == true)
            {
                saved = 15;
            }
            return saved;
        }

        public void updateDg()
        {
            dgList.ItemsSource = null;
            dgList.ItemsSource = g.player;
        }

        public void setLabels()
        {
            lblOne.Content = g.dices[0];
            lblTwo.Content = g.dices[1];
            lblThree.Content = g.dices[2];
            lblFour.Content = g.dices[3];
            lblFive.Content = g.dices[4];
        }

        //public void setDices()
        //{
        //    savedDice[0] = false;
        //    savedDice[1] = false;
        //    savedDice[2] = false;
        //    savedDice[3] = false;
        //    savedDice[4] = false;
        //}

        public void checkDices()
        {
            //if (round > 0)
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

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ettor, tvåor, treor, fyror etc." + "\n" + "Här får du poäng för alla ettor, tvåor och så vidare. Till exempel om du får fyra femmor så har du har du fått ihop 20 poäng." + "\n" +"\n" + "Bonus" + "\n" + "Om du lyckats få ihop 63 poäng på den övre kolumnen på protokollet med ettor, tvåor etc. då får du 50 bonuspoäng." + "\n" +"\n" + "Par" + "\n" + "Du ska få två likadana tärningar.Till exempel två treor som ger 6 poäng." + "\n" + "\n" + "Två par" + "\n" + "Som det låter ska du få två olika par. Till exempel två treor och och två femmor som tillsammans då skulle ge 16 poäng." + "\n" + "\n" + "Tretal" + "\n" + "Här ska du få tre lika tärningar. Till exempel tre sexor som ger 24 poäng." + "\n" + "\n" + "Fyrtal" + "\n" + "Fyra lika tärningar. Till exempel fyra tvåor som ger 8 poäng." + "\n" + "\n" + "Liten stege" + "\n" + "Siffrorna 1, 2, 3, 4 och 5 på tärningarna ger en liten straight och ger 15 poäng." + "\n" + "\n" + "Stor stege" + "\n" +  "Siffrorna 2, 3, 4, 5 och 6 på tärningarna ger en stor straight och ger 20 poäng." + "\n" + "\n" + "Kåk" + "\n" + "Här gäller det att få ett par och ett tretal. Till exempel två treor och tre femmor." + "\n" + "\n" + "Chans" + "\n" + "På chans kan du ta vad som helst. Poängen blir summan av alla tärningar. Du kan till exempel använda chans när du inte får ihop någon annan tärningskombination som passar." + "\n" + "\n" + "Yatzy" + "\n" + "Yatzy innebär att du ska få fem lika. Till exempel fem fyror.");
        }


   
    }
}
