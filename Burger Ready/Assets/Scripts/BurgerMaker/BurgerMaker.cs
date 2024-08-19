using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Restaurant
{
    public class BurgerMaker : MonoBehaviour
    {
        private int nMaxBurger = 4;
        private int nBurger;
        // Start is called before the first frame update
        void Start()
        {
            nBurger = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CookBurger()
        {

        }

        public void CompleteBurger()
        {

        }

        public int GiveBurger(int quantity)
        {
            int result = quantity <= nBurger ? quantity : nBurger;
            nBurger -= result;
            return result;
        }
    }
}
