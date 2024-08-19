using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private Level m_level;
        private int m_cash = 10;
        private int m_nBurgerCarrying;

        private int nMaxBurgerPickOnce = 2;
        // Start is called before the first frame update
        void Start()
        {
            m_level = new Level();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GainCash(int cash)
        {
            m_cash += cash;
        }

        public void GainExp(int exp)
        {
            m_level.GainExp(exp);
        }

        public void PickBurgersFromBurgerMachine()
        {

        }

        public void GiveBurgersToCounter()
        {

        }

        public void SellBurgers()
        {

        }
    }
}
