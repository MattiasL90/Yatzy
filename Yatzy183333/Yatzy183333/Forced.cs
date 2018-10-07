using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
    public class Forced : Game
    {
        bool checko6;
        public override void putScore(int type)
        {
            Array.Sort(dices);
            round = 0;
            foreach (Player y in player)
            {
                if (y.id == turn)
                {
                    if (type == 1 || y.fsave== 1)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 1)
                            {
                                score++;
                            }
                        }
                        y.ones = score;
                    }
                    else if (type == 2 || y.fsave == 2)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 2)
                            {
                                score = score + 2;
                            }
                        }
                        y.twos = score;
                    }
                    else if (type == 3 || y.fsave == 3)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 3)
                            {
                                score = score + 3;
                            }
                        }
                        y.threes = score;
                    }
                    else if (type == 4 || y.fsave == 4)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 4)
                            {
                                score = score + 4;
                            }
                        }
                        y.fours = score;
                    }
                    else if (type == 5 || y.fsave == 5)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 5)
                            {
                                score = score + 5;
                            }
                        }
                        y.fives = score;
                    }
                    else if (type == 6 || y.fsave == 6)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 6)
                            {
                                score = score + 6;
                            }
                        }
                        y.sixes = score;
                    }
                    else if (type == 7 || y.fsave == 7)
                    {

                        if (dices[4] == dices[3])
                        {
                            score = dices[4] + dices[3];
                        }
                        else if (dices[3] == dices[2])
                        {
                            score = dices[3] + dices[2];
                        }
                        else if (dices[2] == dices[1])
                        {
                            score = dices[2] + dices[1];
                        }
                        else if (dices[1] == dices[0])
                        {
                            score = dices[1] + dices[0];
                        }
                        y.pair = score;
                    }
                    else if (type == 8 || y.fsave == 8)
                    {
                        if (dices[4] == dices[3] && dices[2] == dices[1])
                        {
                            score = dices[4] + dices[3] + dices[2] + dices[1];
                        }
                        else if (dices[4] == dices[3] && dices[1] == dices[0])
                        {
                            score = dices[4] + dices[3] + dices[1] + dices[0];
                        }
                        else if (dices[3] == dices[2] && dices[1] == dices[0])
                        {
                            score = dices[3] + dices[2] + dices[1] + dices[0];
                        }
                        y.twopair = score;
                    }
                    else if (type == 9 || y.fsave == 9)
                    {
                        if (dices[4] == dices[3] && dices[3] == dices[2])
                        {
                            score = dices[4] + dices[3] + dices[2];
                        }
                        else if (dices[3] == dices[2] && dices[2] == dices[1])
                        {
                            score = dices[3] + dices[2] + dices[1];
                        }
                        else if (dices[2] == dices[1] && dices[1] == dices[0])
                        {
                            score = dices[2] + dices[1] + dices[0];
                        }
                        y.triads = score;
                    }
                    else if (type == 10 || y.fsave == 10)
                    {
                        if (dices[4] == dices[3] && dices[3] == dices[2] && dices[2] == dices[1])
                        {
                            score = dices[4] + dices[3] + dices[2] + dices[1];
                        }
                        else if (dices[3] == dices[2] && dices[2] == dices[1] && dices[1] == dices[0])
                        {
                            score = dices[3] + dices[2] + dices[1] + dices[0];
                        }
                        y.quads = score;
                    }
                    else if ((type == 11 && checko6 == true) || (y.fsave == 11 && checko6 == true))
                    {
                     
                            score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                      
                        y.house = score;
                    }
                    else if ((type == 12 && checko6 == true) || (y.fsave == 12 && checko6 == true))
                    {
                    
                            score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                     
                            
                        y.ladderl = score;
                    }
                    else if ((type == 13 && checko6 == true) || (y.fsave == 13 && checko6 == true))
                    {
                       
                            score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                      
                            
                        y.ladderb = score;
                    }
                    else if (type == 14  || y.fsave == 14)
                    {
                      
                            score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                       
                            
                        y.chance = score;
                    }
                    else if ((type == 15 && checko6 == true) || (y.fsave == 15 && checko6 == true))
                    {
                        score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                        y.yatzy = 50;
                    }
                    y.total = y.total + score;
                    bonusCheck();
                    resetDices();
                    score = 0;
                }
            }
        }

        public override void bonusCheck()
        {
            foreach (Player y in player)
            {
                if (y.ones >= 2 && y.twos >= 4 && y.threes >= 6 && y.fours >= 8 && y.fives >= 10 && y.sixes >= 12 && y.bonus == 0)

                {
                    y.bonus = 42;
                }
            }

        }


        public override Boolean checkScore(int type)
        {
            Array.Sort(dices);
            bool check = true;
            checko6 = false;
            foreach (Player y in player)
            {
                if (y.id == turn)
                {

                    if (type == 1)
                    {
                        if (y.fsave == 0)
                        {
                            y.fsave = 1;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 2)
                    {
                        if (y.fsave == 1)

                        {
                            y.fsave = 2;

                        }
                        else
                        {
                            check = false;
                        }

                    }
                    else if (type == 3)
                    {
                        if (y.fsave == 2)
                        {
                            y.fsave = 3;
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 4)
                    {
                        if (y.fsave == 3)

                        {
                            y.fsave = 4;

                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 5)
                    {
                        if (y.fsave == 4)

                        {
                            y.fsave = 5;

                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 6)
                    {
                        if (y.fsave == 5)

                        {
                            y.fsave = 6;

                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 7)
                    {
                        if (y.fsave == 6)

                        {
                            y.fsave = 7;
                                                                                        
                            

                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 8)
                    {
                        if (y.fsave == 7)

                        {
                            y.fsave = 8;

                           
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 9)
                    {
                        if (y.fsave == 8)

                        {
                            y.fsave = 9;

                            
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 10)
                    {
                        if (y.fsave == 9)

                        {
                            y.fsave = 10;
                                                       
                        }
                        else
                        {
                            check = false;
                        }
                    }

                    else if (type == 11)
                    {
                        if (y.fsave == 10)

                        {
                            y.fsave = 11;

                            if (dices[4] == dices[3] && dices[3] == dices[2] && dices[1] == dices[0])
                            {
                                checko6 = true;
                            }
                            else if (dices[4] == dices[3] && dices[2] == dices[1] && dices[1] == dices[0])
                            {
                                checko6 = true;
                            }

                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 12)
                    {
                        if (y.fsave == 11)

                        {
                            y.fsave = 12;
                            if (dices[4] == 5 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                            {
                                checko6 = true;
                            }
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 13)
                    {
                        if (y.fsave == 12)

                        {
                            y.fsave = 13;
                            if (dices[4] == 6 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                            {
                                checko6 = true;
                            }
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 14)
                    {
                        if (y.fsave == 13)

                        {
                            y.fsave = 14;
                            
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else if (type == 15)
                    {
                        if (y.fsave == 14)

                        {
                            y.fsave = 15;
                            if (dices[4] == dices[3] && dices[3] == dices[2] && dices[2] == dices[1] && dices[1] == dices[0])
                            {
                                checko6 = true;
                            }
                        }
                        else
                        {
                            check = false;
                        }
                    }
                    else
                    {
                        y.fsave++;
                    }
                }
            }
            return check;
        }
        public override bool CheckFinnish(int ppl, SQL s)
        {
            bool fin = false;
            foreach (Player y in player)
            {
                if (y.id == ppl && y.fsave == 15)
                {
                    fin = true;
                }  
            }
            return fin;
        }
    }
}
        
    

