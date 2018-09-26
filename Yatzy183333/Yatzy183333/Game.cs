using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
   public class Game
    {
        public int round { get; set; }
        public int turn { get; set; }
        public List<Player> player = new List<Player>(); //prop

        public int[] dices = new int[5]; 

        public void rollDices(bool[] savedDices)
        {
            Random random = new Random();
            for (int i = 0; i < dices.Count(); i++)
            {
                if (!savedDices[i])
                {
                    dices[i] = random.Next(1, 7);
                }
            }
            round++;
        }

        public void resetDices()
        {
            Random random = new Random();
            for (int i = 0; i < dices.Count(); i++)
            {                
                    dices[i] = 0;
            }
        }
        
        public string nameCount(int players)
        {
            string name = null;
            foreach (Player y in player)
            {
                if (y.id == players)
                    name= y.name;
            }
            return name;
        }

        public void saveScore(int score, int type, int id)
        {
            foreach (Player y in player)
            {
                if (type == 1)
            {

                        y.ones = score;
                
            }
            else if (type == 2)
            {


                        y.twos = score;
                
            }
            else if (type == 3)
            {


                        y.threes = score;
                
            }
            else if (type == 4)
            {


                        y.fours = score;
                
            }
            else if (type == 5)
            {
                        y.fives = score;
            }
            else if (type == 6)
            {
                        y.sixes = score;
            }
            else if (type == 7)
            {

                    if (y.id == id)
                        y.pair = score;
                
            }
            else if (type == 8)
            {

                    if (y.id == id)
                        y.twopair = score;
                
            }
            else if (type == 9)
            {

                    if (y.id == id)
                        y.triads = score;
                
            }
            else if (type == 10)
            {

                    if (y.id == id)
                        y.quads = score;
                
            }
            else if (type == 11)
            {

                    if (y.id == id)
                        y.house = score;
                
            }
            else if (type == 12)
            {
                foreach (Player y in player)
                {
                    if (y.id == id)
                        y.ladderl = score;
                }
            }
            else if (type == 13)
            {
                foreach (Player y in player)
                {
                    if (y.id == id)
                        y.ladderb = score;
                }
            }
            else if (type == 14)
            {
                foreach (Player y in player)
                {
                    if (y.id == id)
                        y.chance = score;
                }
            }
            else if (type == 15)
            {
                foreach (Player y in player)
                {
                    if (y.id == id)
                        y.yatzy = 50;
                }
            }

            foreach (Player y in player)
            {
                if (y.id == id)
                    y.total = y.total + score;
            }
        }
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

        public void bonusCheck()
        {
            foreach (Player y in player)
            {
                int bScore = y.ones + y.twos + y.threes + y.fours + y.fives + y.sixes;
                if (y.bonus == 0 && bScore >= 63)
                {
                    y.bonus = 50;
                }
            }
        }
    }
}
