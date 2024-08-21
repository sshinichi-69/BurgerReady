using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.Restaurant.Table
{
    public class TableUnlockSlot : MonoBehaviour
    {
        [SerializeField] private Text m_unlockCostText;

        public void Init(int unlockCost)
        {
            m_unlockCostText.text = unlockCost.ToString();
        }

        public void AllowUnlock()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }

        public void Unlock()
        {
            // minus cash
            Destroy(gameObject);
        }

        public void ConfigUnlock()
        {
            Destroy(gameObject);
        }
    }
}
