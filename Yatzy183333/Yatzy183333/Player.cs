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
        public int pair { get; set; }
        public int twopair { get; set; }
        public int triads { get; set; }
        public int quads { get; set; }
        public int house { get; set; }
        public int ladderl { get; set; }
        public int ladderb { get; set; }
        public int chance { get; set; }
        public int yatzy { get; set; }
        public int bonus { get; set; }
        public int total { get; set; }

        public List<Player> player = new List<Player>();


        public override string ToString()
        {
            return $"{name} {ones} {twos} {threes} {fours} {fives} {sixes} {bonus} {pair} {twopair} {triads} {quads} {house} {ladderl} {chance} {yatzy} {total}";
        }

        public void addPlayer(string namee, int idd)
        {
            Player d = new Player()
            {
                id = idd,
                name = namee,
                ones = 0,
                twos = 0,
                threes = 0,
                fours = 0,
                fives = 0,
                sixes = 0,
                pair = 0,
                twopair = 0,
                triads = 0,
                quads = 0,
                house = 0,
                ladderl = 0,
                ladderb = 0,
                chance = 0,
                yatzy = 0,
                bonus = 0,
                total = 0
            };
            player.Add(d);
        }
    }
}
