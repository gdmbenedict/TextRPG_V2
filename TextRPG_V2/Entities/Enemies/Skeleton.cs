﻿using System;

namespace TextRPG_V2
{
    public class Skeleton : Entity
    {
        private bool moveRight;

        public Skeleton() : base()
        {
            SetName("Skeleton");
            SetSymbol('s');
            SetColor(ConsoleColor.White);
            SetFaction(Faction.undead);
            SetMagic(false);

            health = new HealthSystem(13);
            atk = new Stat(8);
            def = new Stat(16);
            mag = new Stat(2);
            res = new Stat(4);
            spd = new Stat(6);
            skl = new Stat(5);
            luc = new Stat(2);
        }

        public override string ChooseAction(Map map, int[] startPos)
        {
            //check move right
            if (moveRight)
            {
                int[] rightPos = { startPos[0], startPos[1] + 1 };

                //check for impassible tile or entity with same faction
                if (map.GetTile(rightPos).GetImpassable() || map.GetEntity(rightPos).GetFaction() == Faction.undead)
                {
                    moveRight = false;
                    int[] leftPos = { startPos[0], startPos[1] - 1 };

                    //attempt move left
                    return Move(map, startPos, leftPos);
                }
                else
                {
                    //attempt move right
                    return Move(map, startPos, rightPos);
                }
            }
            //check move left
            else
            {
                int[] leftPos = { startPos[0], startPos[1] - 1 };

                //check for impassible tile or entity with same faction
                if (map.GetTile(leftPos).GetImpassable() || map.GetEntity(leftPos).GetFaction() == Faction.undead)
                {
                    moveRight = true;
                    int[] rightPos = { startPos[0], startPos[1] + 1 };

                    //attempt move right
                    return Move(map, startPos, rightPos);
                }
                else
                {
                    //attempt move left
                    return Move(map, startPos, leftPos);
                }
            }
        }
    }
}