using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
   class Game
    {
        
        public int[] rollDices(bool[] savedDices, int[] dices)
        {
            Random random = new Random();
            for (int i = 0; i < dices.Count(); i++)
            {
                if (!savedDices[i])
                {
                    dices[i] = random.Next(1, 7);
                }

            }
            return dices;
        }


        public List<Player> saveScore(int score, int type, int id, List<Player> player)
        {
            Player p = new Player();
            if (type == 1)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.ones = score;
                }
            }
            else if (type == 2)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.twos = score;
                }
            }
            else if (type == 3)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.threes = score;
                }
            }
            else if (type == 4)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.fours = score;
                }
            }
            else if (type == 5)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.fives = score;
                }
            }
            else if (type == 6)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.sixes = score;
                }
            }
            else if (type == 7)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                    { p.pair = score; }

                }
            }
            else if (type == 8)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.twopair = score;
                }
            }
            else if (type == 9)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.triads = score;
                }
            }
            else if (type == 10)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.quads = score;
                }
            }
            else if (type == 11)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.house = score;
                }
            }
            else if (type == 12)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.ladderl = score;
                }
            }
            else if (type == 13)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.ladderb = score;
                }
            }
            else if (type == 14)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.chance = score;
                }
            }
            else if (type == 15)
            {
                foreach (Player y in player)
                {
                    if (p.id == id)
                        p.yatzy = score;
                }
            }

            foreach (Player y in player)
            {
                if (p.id == id)
                    p.total = p.total + score;
            }
            return player;
        }
    }
}
