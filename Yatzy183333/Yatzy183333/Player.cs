using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
    class Player
    {
        public int id { get; set; }
        public int ones { get; set; }
        public int twos { get; set; }
        public int trees { get; set; }
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
    }
}
