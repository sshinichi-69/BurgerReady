using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Counter
{
    public class SellCounterSlot : MonoBehaviour
    {
        [SerializeField] private Counter m_counter;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SellBurger()
        {
            m_counter.SellBurger();
        }
    }
}
