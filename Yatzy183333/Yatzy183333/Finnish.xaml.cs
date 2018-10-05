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
        SQL s;
        Game g;
        public int total { get; set; }
        public string name { get; set; }
        public List<Finnish> fin { get; set; }

        public Finnish(SQL c, Game game)
        {
            InitializeComponent();
            s = c;
            g = game;
            FinLista();
            dgGscore.ItemsSource = null;
            dgGscore.ItemsSource = fin;
            dgHscore.ItemsSource = null;
            dgHscore.ItemsSource = s.GetHighScore(); 
        }

        public Finnish()
        {
            fin = new List<Finnish>();
        }
        public void FinLista()
        {
            foreach (Player y in g.player)
            {
                Finnish f = new Finnish()
                {

                    name = y.name,
                    total = y.total,

                };

                fin.Add(f);
            }
        }
    }
       
}
