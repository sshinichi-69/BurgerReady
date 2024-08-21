using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Counter
{
    public class Counter : MonoBehaviour
    {
        private RestaurantController m_restaurant;
        [SerializeField] private GameObject tray;
        [SerializeField] private GameObject sellCounterSlot;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init(RestaurantController restaurant)
        {
            m_restaurant = restaurant;
        }

        public void SellBurger()
        {
            int nBurgerSell = m_restaurant.GetFirstCustomerBurgerQuantity();
            List<GameObject> burgersSell = tray.GetComponent<CounterTray>().SellBurger(nBurgerSell);
            m_restaurant.SellBurger(burgersSell);
        }
    }
}
