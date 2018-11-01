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
        int ppl;
        SQL s;
        int logType;



        public MainWindow(Game game ,int x , SQL c, int t)
        {
            InitializeComponent();
            g = game;
            s = c;
            logType = t;
            ppl = x;
            UpdateDg();
            playerLb.Content = g.WhichPlayer(g.CountRolls(ppl));
            SetRankedLabel();
            SetDgColumns();
        }


        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            CheckDices();
            g.RollDices(savedDice);
            SetLabels();
            rollLb.Content = "Slag nr: "+ (g.round);
            if (g.round == 3)
            {
                btnRoll.IsEnabled = false;
            }
            UpdateDg();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int type = SetType();
            if (g.CheckScore(type))
            {
                g.SetScore(type);
                btnRoll.IsEnabled = true;
                ResetCb();
                rollLb.Content = "Slag nr: " + g.round;
                FinnishGame();
                playerLb.Content = g.WhichPlayer(g.CountRolls(ppl));
                SetLabels();
                UpdateDg();
            }
            else
            {
                MessageBox.Show("Det fungerar inte.");
            }
        }

        private void SetRankedLabel()
        {
            if (g.matchid > 0)
            {
                lblRanked.Content = "Spelet är rankat!";
            }
            else if (g.matchid == 0)
            {
                lblRanked.Content = "Spelet är orankat!";
            }
        }

        private void ResetCb()
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


            if (rbOnes.IsChecked == true)
            {
                rbOnes.IsChecked = false;
            }
            if (rbTwos.IsChecked == true)
            {
                rbTwos.IsChecked = false;
            }
            if (rbThrees.IsChecked == true)
            {
                rbThrees.IsChecked = false;
            }
            if (rbFours.IsChecked == true)
            {
                rbFours.IsChecked = false;
            }
            if (rbFives.IsChecked == true)
            {
                rbFives.IsChecked = false;
            }
            if (rbSixes.IsChecked == true)
            {
                rbSixes.IsChecked = false;
            }
            if (rbPair.IsChecked == true)
            {
                rbPair.IsChecked = false;
            }
            if (rbTwopair.IsChecked == true)
            {
                rbTwopair.IsChecked = false;
            }
            if (rbTriads.IsChecked == true)
            {
                rbTriads.IsChecked = false;
            }
            if (rbQuads.IsChecked == true)
            {
                rbQuads.IsChecked = false;
            }
            if (rbHouse.IsChecked == true)
            {
                rbHouse.IsChecked = false;
            }
            if (rbLadderl.IsChecked == true)
            {
                rbLadderl.IsChecked = false;
            }
            if (rbLadderb.IsChecked == true)
            {
                rbLadderb.IsChecked = false;
            }
            if (rbChance.IsChecked == true)
            {
                rbChance.IsChecked = false;
            }
            if (rbYatzy.IsChecked == true)
            {
                rbYatzy.IsChecked = false;
            }
        }

        private int SetType()
        {
            int setType = 0;
            if (rbOnes.IsChecked == true)
            {
                setType = 1;
            }
            else if (rbTwos.IsChecked == true)
            {
                setType = 2;
            }
            else if (rbThrees.IsChecked == true)
            {
                setType = 3;
            }
            else if (rbFours.IsChecked == true)
            {
                setType = 4;
            }
            else if (rbFives.IsChecked == true)
            {
                setType = 5;
            }
            else if (rbSixes.IsChecked == true)
            {
                setType = 6;
            }
            else if (rbPair.IsChecked == true)
            {
                setType = 7;
            }
            else if (rbTwopair.IsChecked == true)
            {
                setType = 8;
            }
            else if (rbTriads.IsChecked == true)
            {
                setType = 9;
            }
            else if (rbQuads.IsChecked == true)
            {
                setType = 10;
            }
            else if (rbHouse.IsChecked == true)
            {
                setType = 11;
            }
            else if (rbLadderl.IsChecked == true)
            {
                setType = 12;
            }
            else if (rbLadderb.IsChecked == true)
            {
                setType = 13;
            }
            else if (rbChance.IsChecked == true)
            {
                setType = 14;
            }
            else if (rbYatzy.IsChecked == true)
            {
                setType = 15;
            }
            return setType;
        }
        
        private void UpdateDg()
        {
            dgList.ItemsSource = null;
            dgList.ItemsSource = g.player;
        }

        private void SetLabels()
        {
            lblOne.Content = g.dices[0];
            lblTwo.Content = g.dices[1];
            lblThree.Content = g.dices[2];
            lblFour.Content = g.dices[3];
            lblFive.Content = g.dices[4];
        }

        private void CheckDices()
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

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ettor, tvåor, treor, fyror etc." + "\n" + "Här får du poäng för alla ettor, tvåor och så vidare. Till exempel om du får fyra femmor så har du har du fått ihop 20 poäng." + "\n" +"\n" + "Bonus" + "\n" + "Om du lyckats få ihop 63 poäng på den övre kolumnen på protokollet med ettor, tvåor etc. då får du 50 bonuspoäng." + "\n" +"\n" + "Par" + "\n" + "Du ska få två likadana tärningar.Till exempel två treor som ger 6 poäng." + "\n" + "\n" + "Två par" + "\n" + "Som det låter ska du få två olika par. Till exempel två treor och och två femmor som tillsammans då skulle ge 16 poäng." + "\n" + "\n" + "Tretal" + "\n" + "Här ska du få tre lika tärningar. Till exempel tre sexor som ger 24 poäng." + "\n" + "\n" + "Fyrtal" + "\n" + "Fyra lika tärningar. Till exempel fyra tvåor som ger 8 poäng." + "\n" + "\n" + "Liten stege" + "\n" + "Siffrorna 1, 2, 3, 4 och 5 på tärningarna ger en liten straight och ger 15 poäng." + "\n" + "\n" + "Stor stege" + "\n" +  "Siffrorna 2, 3, 4, 5 och 6 på tärningarna ger en stor straight och ger 20 poäng." + "\n" + "\n" + "Kåk" + "\n" + "Här gäller det att få ett par och ett tretal. Till exempel två treor och tre femmor." + "\n" + "\n" + "Chans" + "\n" + "På chans kan du ta vad som helst. Poängen blir summan av alla tärningar. Du kan till exempel använda chans när du inte får ihop någon annan tärningskombination som passar." + "\n" + "\n" + "Yatzy" + "\n" + "Yatzy innebär att du ska få fem lika. Till exempel fem fyror.");
        }

        private void btnSkip_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfSkipChecked(SetType()) == true)
            {
                g.SkipScore(SetType());
                btnRoll.IsEnabled = true;
                ResetCb();
                g.round = 0;
                rollLb.Content = "Slag nr: " + g.round;
                FinnishGame();
                playerLb.Content = g.WhichPlayer(g.CountRolls(ppl));
                g.ResetDices();
                SetLabels();
                UpdateDg();
            }
            else if (CheckIfSkipChecked(SetType()) == false)
            {
                MessageBox.Show("Du måste välja vad du vill stryka.");
            }
        }
        private void FinnishGame()
        {
            if (g.IsGameOver(ppl, s) == true)
            {
                g.RegPlayer();
                this.Hide();
                Finnish f = new Finnish(g, logType);
                f.ShowDialog();
            }
        }

        private bool CheckIfSkipChecked(int type)
        {
            bool checkIfSkipChecked;
            if (logType == 1)
            {
                if (type > 0 && g.CheckSkip(type) == true)
                {
                    checkIfSkipChecked = true;
                }
                else
                {
                    checkIfSkipChecked = false;
                }
                return checkIfSkipChecked;
            }
            else
            {
                checkIfSkipChecked = true;
            }
            return checkIfSkipChecked;
        }

        private void SetDgColumns()
        {
            dgList.AutoGeneratedColumns += datagrid1_AutoGeneratedColumns;

            void datagrid1_AutoGeneratedColumns(object sender, EventArgs e)
            {
                dgList.Columns[0].Header = "Id";
                dgList.Columns[1].Header = "Namn";
                dgList.Columns[2].Header = "Ettor";
                dgList.Columns[3].Header = "Tvåor";
                dgList.Columns[4].Header = "Treor";
                dgList.Columns[5].Header = "Fryror";
                dgList.Columns[6].Header = "Femmor";
                dgList.Columns[7].Header = "Sexor";
                dgList.Columns[8].Header = "Bonus";
                dgList.Columns[9].Header = "Par";
                dgList.Columns[10].Header = "Två Par";
                dgList.Columns[11].Header = "Triss";
                dgList.Columns[12].Header = "Fyrtal";
                dgList.Columns[13].Header = "Kåk";
                dgList.Columns[14].Header = "Liten Stege";
                dgList.Columns[15].Header = "Stor Stege";
                dgList.Columns[16].Header = "Chans";
                dgList.Columns[17].Header = "Yatzy";
                dgList.Columns[18].Header = "Total";
                dgList.Columns[19].Header = "Slag";
            }
        }
    }
}
