using BurgerReady.Restaurant.Customer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerReady.Restaurant.Counter;
using BurgerReady.Restaurant.Table;

namespace BurgerReady.Restaurant
{
    public class RestaurantController : MonoBehaviour
    {
        [SerializeField] private TableManager m_tableManager;
        [SerializeField] private CustomerQueue customerQueue;
        private List<BurgerMaker> burgerMakers;
        private List<Counter.Counter> counters;

        [SerializeField] private List<Vector3> burgerMakersPos;
        [SerializeField] private List<Vector3> countersPos;

        [SerializeField] private GameObject burgerMakerContainer;
        [SerializeField] private GameObject burgerMakerPrefab;
        [SerializeField] private GameObject counterContainer;
        [SerializeField] private GameObject counterPrefab;
        // Start is called before the first frame update
        void Start()
        {
            burgerMakers = new List<BurgerMaker>();
            counters = new List<Counter.Counter>();

            GameObject burgerMaker = Instantiate(burgerMakerPrefab, burgerMakersPos[0], Quaternion.identity);
            burgerMaker.transform.parent = burgerMakerContainer.transform;
            burgerMakers.Add(burgerMaker.GetComponent<BurgerMaker>());

            GameObject counter = Instantiate(counterPrefab, countersPos[0], Quaternion.identity);
            counter.transform.parent = counterContainer.transform;
            counter.GetComponent<Counter.Counter>().Init(this);
            counters.Add(counter.GetComponent<Counter.Counter>());
        }

        public int GetFirstCustomerBurgerQuantity()
        {
            return customerQueue.GetFirstCustomerBurgerQuantity();
        }

        public void AddNewCustomer()
        {
            customerQueue.AddNewCustomer();
        }

        public void SellBurger(List<GameObject> burgers)
        {
            customerQueue.SellBurger(burgers);
        }

        public Table.Table FindTableForCustomer()
        {
            return m_tableManager.FindTableForCustomer();
        }

        public bool GiveTableToCustomer(Table.Table table)
        {
            return customerQueue.GiveTableToCustomer(table);
        }

        public TableManager TableManager { get { return m_tableManager; } }
    }
}
