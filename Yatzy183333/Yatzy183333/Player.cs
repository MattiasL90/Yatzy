using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
    public class Player
    {
        
        public int id { get; set; }
        public string name { get; set; }
        public int ones { get; set; }
        public int twos { get; set; }
        public int threes { get; set; }
        public int fours { get; set; }
        public int fives { get; set; }
        public int sixes { get; set; }
        public int bonus { get; set; }
        public int pair { get; set; }
        public int twopair { get; set; }
        public int triads { get; set; }
        public int quads { get; set; }
        public int house { get; set; }
        public int ladderl { get; set; }
        public int ladderb { get; set; }
        public int chance { get; set; }
        public int yatzy { get; set; }
        public int total { get; set; }
        public int fsave { get; set; }


        public override string ToString()
        {
            //return $"{name} {ones} {twos} {threes} {fours} {fives} {sixes} {bonus} {pair} {twopair} {triads} {quads} {house} {ladderl} {chance} {yatzy} {total}";
            //return String.Format("Namn:{0}, Ettor:{1}, Tvåor:{2}, Treor:{3}, Fyror:{3}, Femmor:{3}, Sexor:{3}, bonus:{3}, Par:{3}, Två par:{3}, Triss:{3}, Fyrtal:{3}, Kåk:{3}, Liten stege:{3}, Stor stege:{3}, Chans:{3}, Yatzy:{3}, Total:{3}", name, ones, twos, threes, fours, fives, sixes, bonus, pair, twopair, triads, quads, house, ladderl, ladderb, chance, yatzy, total);
            return $"Namn:{name}, Ettor:{ones}, Tvåor:{twos}, Treor:{threes}";
        }

        //public void FinLista()
        //{
            
        //    foreach (Player y in Game.player)
        //    {
        //        Finnish f = new Finnish()
        //        {
        //            name = y.name,
        //            total = y.total
        //        };
        //        f.fin.Add(f);
        //    }
        //}
    }
}
