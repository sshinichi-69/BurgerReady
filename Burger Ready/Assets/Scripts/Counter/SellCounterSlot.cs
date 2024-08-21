using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Counter
{
    public class SellCounterSlot : MonoBehaviour
    {
        [SerializeField] private Counter m_counter;

        public void SellBurger()
        {
            m_counter.SellBurger();
        }
    }
}
