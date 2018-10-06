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
    /// Interaction logic for Finnish.xaml
    /// </summary>
    public partial class Finnish : Window
    {
        SQL s = new SQL();
        Game g;
        int logType;
        public int total { get; set; }
        public string name { get; set; }
        public List<Finnish> fins = new List<Finnish>();
        


        public Finnish(Game game, int t)
        {
            Player p = new Player();
            InitializeComponent();
            g = game;
            logType = t;
            FinLista(g.player);
            SortList();
            dgGscore.ItemsSource = null;
            dgGscore.ItemsSource = fins;
            dgHscore.ItemsSource = null;
            dgHscore.ItemsSource = s.GetHighScore(logType); 
        }

        public Finnish()
        {
            //fin = new List<Finnish>();
        }

        public void FinLista(List<Player> player)
        {
            foreach (Player y in player)
            {
                Finnish f = new Finnish()
                {
                    name = y.name,
                    total = y.total
                };
                fins.Add(f);
                
            }
            
        }
      
        public void SortList()
        {

            fins= fins.OrderByDescending(x => x.total).ToList();


       
        }
    }
       
}
