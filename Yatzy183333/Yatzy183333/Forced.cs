using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
    public class Forced : Game
    {
        Game g;
        public override void putScore(int type)
        {
            Array.Sort(dices);
            round = 0;
            foreach (Player y in player)
            {
                if (y.id == turn)
                {
                    if (type == 1)
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
                    else if (type == 2)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 2)
                            {
                                score = +2;
                            }
                        }
                        y.twos = score;
                    }
                    else if (type == 3)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 3)
                            {
                                score = +3;
                            }
                        }
                        y.threes = score;
                    }
                    else if (type == 4)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 4)
                            {
                                score = +4;
                            }
                        }
                        y.fours = score;
                    }
                    else if (type == 5)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 5)
                            {
                                score = +5;
                            }
                        }
                        y.fives = score;
                    }
                    else if (type == 6)
                    {
                        foreach (int i in dices)
                        {
                            if (i == 6)
                            {
                                score = +6;
                            }
                        }
                        y.sixes = score;
                    }
                    else if (type == 7)
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
                    else if (type == 8)
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
                    else if (type == 9)
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
                    else if (type == 10)
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
                    else if (type == 11)
                    {
                        score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                        y.house = score;
                    }
                    else if (type == 12)
                    {
                        score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                        y.ladderl = score;
                    }
                    else if (type == 13)
                    {
                        score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                        y.ladderb = score;
                    }
                    else if (type == 14)
                    {
                        score = dices[4] + dices[3] + dices[2] + dices[1] + dices[0];
                        y.chance = score;
                    }
                    else if (type == 15)
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
              public override Boolean checkScore(int type)
        {
            Array.Sort(dices);
            bool check = false;
            int scores = 0;
            foreach (Player y in player)
            {
                if (type == 1)
                {
                    foreach (int i in dices)
                    {
                        if (i == 1)
                        {
                            scores++;
                        }
                    }
                    if (scores >= 1)
                    {
                        check = true;
                    }
                }
                else if (type == 2)
                {
                    foreach (int i in dices)
                    {
                        if (i == 2)
                        {
                            scores = +2;
                        }
                    }
                    if (scores >= 1)
                    {
                        check = true;
                    }
                }
                else if (type == 3)
                {
                    foreach (int i in dices)
                    {
                        if (i == 3)
                        {
                            scores = +3;
                        }
                    }
                    if (scores > 0)
                    {
                        check = true;
                    }
                }
                else if (type == 4)
                {
                    foreach (int i in dices)
                    {
                        if (i == 4)
                        {
                            scores = +4;
                        }
                    }
                    if (scores > 0)
                    {
                        check = true;
                    }
                }
                else if (type == 5)
                {
                    foreach (int i in dices)
                    {
                        if (i == 5)
                        {
                            scores = +5;
                        }
                    }
                    if (scores > 0)
                    {
                        check = true;
                    }
                }
                else if (type == 6)
                {
                    foreach (int i in dices)
                    {
                        if (i == 6)
                        {
                            scores = +6;
                        }
                    }
                    if (scores > 0)
                    {
                        check = true;
                    }
                }
                else if (type == 7)
                {
                    if (dices[4] == dices[3])
                    {
                        check = true;
                    }
                    else if (dices[3] == dices[2])
                    {
                        check = true;
                    }
                    else if (dices[2] == dices[1])
                    {
                        check = true;
                    }
                    else if (dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 8)
                {
                    if (dices[4] == dices[3] && dices[2] == dices[1])
                    {
                        check = true;
                    }
                    else if (dices[3] == dices[2] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 9)
                {
                    if (dices[4] == dices[3] && dices[3] == dices[2])
                    {
                        check = true;
                    }
                    else if (dices[3] == dices[2] && dices[2] == dices[1])
                    {
                        check = true;
                    }
                    else if (dices[2] == dices[1] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 10)
                {
                    if (dices[4] == dices[3] && dices[3] == dices[2] && dices[2] == dices[1])
                    {
                        check = true;
                    }
                    else if (dices[3] == dices[2] && dices[2] == dices[1] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 11)
                {
                    if (dices[4] == dices[3] && dices[3] == dices[2] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                    else if (dices[4] == dices[3] && dices[2] == dices[1] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 12)
                {
                    if (dices[4] == 5 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 13)
                {
                    if (dices[4] == 6 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                    {
                        check = true;
                    }
                }
                else if (type == 14)
                {
                    check = true;
                }
                else if (type == 15)
                {
                    if (dices[4] == dices[3] && dices[3] == dices[2] && dices[2] == dices[1] && dices[1] == dices[0])
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
    }
}
        
    

