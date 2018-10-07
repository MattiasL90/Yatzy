﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy183333
{
    public abstract class Game
    {
        public int round { get; set; }
        public int turn { get; set; }
        public int score { get; set; }
        public int matchid { get; set; }
        public int ranked { get; set; }
        public List<Player> player { get; set; }

        public int[] dices = new int[5];

        public Game()
        {
            player = new List<Player>();
        }


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
                    name = y.name;
            }
            return name;
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
                total = 0,
                fsave = 0
            };
            player.Add(d);
        } 
        

        public virtual void bonusCheck()
        {
            foreach (Player y in player)
            {
                int bScore = 0;
                if (y.ones < 100)
                {
                    bScore = bScore + y.ones;
                }
                if (y.twos < 100)
                {
                    bScore = bScore + y.twos;
                }
                if (y.threes < 100)
                {
                    bScore = bScore + y.threes;
                }
                if (y.fours < 100)
                {
                    bScore = bScore + y.fours;
                }
                if (y.fives < 100)
                {
                    bScore = bScore + y.fives;
                }
                if (y.sixes < 100)
                {
                    bScore = bScore + y.sixes;
                }
                if (y.bonus == 0 && bScore >= 63)
                {
                    y.bonus = 50;
                }
            }
        }

        public int players(int ppl)
        {
            if (turn < ppl)    //Game
            {
                turn++;
            }
            else if (turn == ppl)
            {
                turn = 1;
            }
            return turn;
        }

        public virtual void putScore(int type)
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
                                score = score + 2;
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
                                score = score + 3;
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
                                score = score + 4;
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
                                score = score + 5;
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
                                score = score + 6;
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

        public virtual Boolean checkScore(int type)
        {
            Array.Sort(dices);
            bool check = false;
            int scores = 0;
            foreach (Player y in player)
            {
                if (y.id == turn)
                {
                    if (type == 1 && y.ones < 1)
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
                    else if (type == 2 && y.twos < 1)
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
                    else if (type == 3 && y.threes < 1)
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
                    else if (type == 4 && y.fours < 1)
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
                    else if (type == 5 && y.fives < 1)
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
                    else if (type == 6 && y.sixes < 1)
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
                    else if (type == 7 && y.pair < 1)
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
                    else if (type == 8 && y.twopair < 1)
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
                    else if (type == 9 && y.triads < 1)
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
                    else if (type == 10 && y.quads < 1)
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
                    else if (type == 11 && y.house < 1)
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
                    else if (type == 12 && y.ladderl < 1)
                    {
                        if (dices[4] == 5 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                        {
                            check = true;
                        }
                    }
                    else if (type == 13 && y.ladderb < 1)
                    {
                        if (dices[4] == 6 && dices[4] > dices[3] && dices[3] > dices[2] && dices[2] > dices[1] && dices[1] > dices[0])
                        {
                            check = true;
                        }
                    }
                    else if (type == 14 && y.chance < 1)
                    {
                        check = true;
                    }
                    else if (type == 15 && y.yatzy < 1)
                    {
                        if (dices[4] == dices[3] && dices[3] == dices[2] && dices[2] == dices[1] && dices[1] == dices[0])
                        {
                            check = true;
                        }
                    }
                }
            }
            return check;
        }

        public virtual bool CheckFinnish(int ppl, SQL s)
        {
            bool fin = false;
            foreach (Player y in player)
            {
                if (y.id == turn)
                {
                    if (y.id == ppl && y.fsave == 14)
                    {
                        fin = true;
                    }
                    else
                    {
                        y.fsave++;
                    }
                }
            }
            return fin; 
        }

        public void RegPlayer()
        {
            SQL s = new SQL();
            if (matchid > 0)
            {
                foreach (Player p in player)
                {
                    int pid = s.GetId(p.name);
                    s.SendScore(pid, p.total, matchid);
                }
                s.EndGame(matchid);
            }
        }

        public void SkipScore(int type)
        {
                foreach (Player y in player)
                {
                    if (y.id == turn)
                    {
                        if (type == 1)
                        {
                            y.ones = 999;
                        }
                        else if (type == 2)
                        {
                            y.twos = 999;
                        }
                        else if (type == 3)
                        {
                            y.threes = 999;
                        }
                        else if (type == 4)
                        {
                            y.fours = 999;
                        }
                        else if (type == 5)
                        {
                            y.fives = 999;
                        }
                        else if (type == 6)
                        {
                            y.sixes = 999;
                        }
                        else if (type == 7)
                        {
                            y.pair = 999;
                        }
                        else if (type == 8)
                        {
                            y.twopair = 999;
                        }
                        else if (type == 9)
                        {
                            y.triads = 999;
                        }
                        else if (type == 10)
                        {
                            y.quads = 999;
                        }
                        else if (type == 11)
                        {
                            y.house = 999;
                        }
                        else if (type == 12)
                        {
                            y.ladderl = 999;
                        }
                        else if (type == 13)
                        {
                            y.ladderb = 999;
                        }
                        else if (type == 14)
                        {
                            y.chance = 999;
                        }
                        else if (type == 15)
                        {
                            y.yatzy = 999;
                        }
                    }
                }
        }

        public void InsertRelationTable()
        {
            SQL s = new SQL();
            if (matchid > 0)
            {
                matchid = s.GetMatchId();
                foreach (Player p in player)
                {
                    int pid = s.GetId(p.name);
                    s.InsertPlayerGame(pid, matchid);
                }
            }
        }

        public bool CheckOngoing(string nicke)
        {
            SQL s = new SQL();
            bool isIt = s.OngoingGame(s.GetId(nicke));
            return isIt;
        }

    }
}
