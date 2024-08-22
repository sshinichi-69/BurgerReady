using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady
{
    public static class Constant
    {
        public static readonly float burgerHeight = 0.3f;

        public static readonly float customerDistance = 1.5f;
        public static readonly int expGainByCustomerAte = 1;
        public static readonly int minGoldPerPizza = 8;
        public static readonly int maxGoldPerPizza = 10;

        public static readonly List<int> expToLevelUp = new List<int>() { 15, 25, 40, 65, 85, 115 };
        public static readonly List<int> goinGainByLevelUp = new List<int>() { 70, 80, 90, 100, 110, 120 };
        public static readonly List<int> unlockTableCost = new List<int>() { 0, 50, 400, 550, 750, 1000, 1300, 1650 };

        public static readonly List<int> upgradeCost = new List<int>() { 250, 450, 700, 1000, 1350 };
    }
}
