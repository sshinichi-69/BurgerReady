using BurgerReady.Player;
using BurgerReady.Restaurant;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Player.Player m_player;
        [SerializeField] private RestaurantController m_restaurant;

        [SerializeField] private Text m_levelText;
        [SerializeField] private Text m_expText;
        [SerializeField] private Slider m_expSlider;
        [SerializeField] private Text m_goldText;
        public static GameManager Instance { get; set; }
        // Start is called before the first frame update
        void Awake()
        {
            StartCoroutine(AddNewCustomer());
            Instance = FindObjectOfType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                    activity.Call<bool>("moveTaskToBack", true);
                }
                else
                {
                    Application.Quit();
                }
            }
        }

        public IEnumerator AddNewCustomer()
        {
            yield return new WaitForSeconds(5);
            m_restaurant.AddNewCustomer();
            StartCoroutine(AddNewCustomer());
        }

        public void GainExpPerCustomerAte(int exp)
        {
            m_player.GainExp(exp);
        }

        public void GainGoldByBurgerSell(int nBurger)
        {
            int gold = 0;
            for (int i = 0; i < nBurger; i++)
            {
                gold += Random.Range(Constant.minGoldPerPizza, Constant.maxGoldPerPizza + 1);
            }
            m_player.GainGold(gold);
        }

        public int UpgradePlayerCapacity()
        {
            return m_player.UpgradeCapacity();
        }

        public void SetLevelUi(int level)
        {
            m_levelText.text = level.ToString();
        }

        public void SetExpUi(int exp, int maxExp)
        {
            m_expText.text = exp + " / " + maxExp;
            m_expSlider.value = exp;
        }

        public void SetMaxExpUi(int maxExp, int exp)
        {
            m_expText.text = exp + " / " + maxExp;
            m_expSlider.maxValue = maxExp;
        }

        public void SetGold(int gold)
        {
            m_goldText.text = gold.ToString();
        }

        public Level Level { get { return m_player.Level; } }
        public RestaurantController Restaurant { get { return m_restaurant; } }
    }
}
