using Restaurant;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerReady.Restaurant;
using BurgerReady.Restaurant.Counter;
using UnityEngine.UI;
using BurgerReady.Restaurant.Table;
using BurgerReady.Upgrade;

namespace BurgerReady.Player
{
    public class Player : MonoBehaviour
    {
        // logic variable
        private Level m_level;
        private int m_gold = 10;
        private Stack<GameObject> burgersCarrying;

        // const variable
        private int m_capacityLevel = 1;
        private int m_capacity = 1;

        // variable for display
        private Animator animator;

        [SerializeField] private GameObject tray;
        // Start is called before the first frame update
        void Start()
        {
            m_level = GetComponent<Level>();
            burgersCarrying = new Stack<GameObject>();

            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<SellCounterSlot>() != null)
            {
                other.gameObject.GetComponent<SellCounterSlot>().SellBurger();
            }
            else if (other.gameObject.GetComponent<TableSlot>() != null)
            {
                var tableSlot = other.gameObject.GetComponent<TableSlot>();
                if (m_gold >= tableSlot.UnlockCost)
                {
                    tableSlot.SetToTableSlot();
                    m_gold -= tableSlot.UnlockCost;
                    SetGoldUi();
                }
            }
            else if (other.gameObject.GetComponent<UpgradeRoom>() != null)
            {
                other.gameObject.GetComponent<UpgradeRoom>().ShowUpgradeUi();
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BurgerMaker>() != null)
            {
                PickBurgersFromBurgerMaker(collision.gameObject.GetComponent<BurgerMaker>());
            }
            else if (collision.gameObject.GetComponent<CounterTray>() != null)
            {
                GiveBurgersToCounter(collision.gameObject.GetComponent<CounterTray>());
            }
        }

        public void GainGold(int gold)
        {
            m_gold += gold;
            SetGoldUi();
        }

        public void GainExp(int exp)
        {
            int oldLevel = m_level.Value;
            m_level.GainExp(exp);
            int newLevel = m_level.Value;
            if (newLevel > oldLevel)
            {
                m_gold += Constant.goinGainByLevelUp[oldLevel - 1];
                SetGoldUi();
            }
        }

        public void PickBurgersFromBurgerMaker(BurgerMaker burgerMaker)
        {
            List<GameObject> burgers = burgerMaker.GiveBurger(m_capacity - burgersCarrying.Count);
            if (burgers.Count > 0) {
                animator.Play("Base Layer.PlayerCarryBurgers");
            }
            for (int i = 0; i < burgers.Count; i++) {
                burgers[i].transform.position = tray.transform.position + burgersCarrying.Count * Constant.burgerHeight * Vector3.up;
                burgers[i].transform.parent = tray.transform.parent;
                burgersCarrying.Push(burgers[i]);
            }
            Debug.Log("Player picked " + burgers.Count + " burgers from Burger Maker and is carrying " + burgersCarrying.Count + " burgers");
        }

        public void GiveBurgersToCounter(CounterTray counterTray)
        {
            List<GameObject> burgers = new List<GameObject>();
            while (burgersCarrying.Count > 0)
            {
                GameObject burger = burgersCarrying.Peek();
                burger.transform.SetParent(null, false);
                burgers.Add(burger);
                burgersCarrying.Pop();
            }
            counterTray.TakeBurger(burgers);
            animator.Play("Base Layer.PlayerIdle");
            Debug.Log("Player gave " + burgers.Count + " burgers to Counter Tray");
        }

        public int UpgradeCapacity()
        {
            Debug.LogWarning("Player::UpgradeCapacity");
            if (m_capacityLevel - 1 < Constant.upgradeCost.Count && m_gold >= Constant.upgradeCost[m_capacityLevel - 1])
            {
                m_capacityLevel++;
                m_capacity++;
            }
            return m_capacityLevel;
        }

        private void SetGoldUi()
        {
            GameManager.Instance.SetGold(m_gold);
        }

        private IEnumerator Init()
        {
            yield return new WaitForSeconds(0.01f);
            if (GameManager.Instance == null)
            {
                StartCoroutine(Init());
            }
            else
            {
                SetGoldUi();
            }
        }

        public Level Level { get { return m_level; } }
    }
}
