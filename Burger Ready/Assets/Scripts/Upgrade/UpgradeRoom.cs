using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.Upgrade
{
    public class UpgradeRoom : MonoBehaviour
    {
        [SerializeField] private GameObject upgradeUi;

        [SerializeField] private Text capacityLevel;
        [SerializeField] private Text capacityUpgradeCost;

        [SerializeField] private Button upgradeButton;
        [SerializeField] private Color enableButtonColor;
        [SerializeField] private Color disableButtonColor;

        // Start is called before the first frame update
        void Start()
        {
            int playerCapacityLevel = 1;
            capacityLevel.text = "Level: " + playerCapacityLevel.ToString();
            capacityUpgradeCost.text = Constant.upgradeCost[playerCapacityLevel - 1].ToString();
            HideUpgradeUi();
        }

        public void ShowUpgradeUi()
        {
            upgradeUi.SetActive(true);
            if (int.TryParse(capacityUpgradeCost.text, out int upgradeCost))
            {
                if (GameManager.Instance.PlayerGold >= upgradeCost)
                {
                    upgradeButton.GetComponent<Image>().color = enableButtonColor;
                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.GetComponent<Image>().color = disableButtonColor;
                    upgradeButton.interactable = false;
                }
            }
            else
            {
                upgradeButton.GetComponent<Image>().color = disableButtonColor;
                upgradeButton.interactable = false;
            }
        }

        public void HideUpgradeUi()
        {
            upgradeUi.SetActive(false);
        }

        public void UpgradeCapacity()
        {
            int playerCapacityLevel = GameManager.Instance.UpgradePlayerCapacity();
            capacityLevel.text = "Level: " + playerCapacityLevel.ToString();
            if (playerCapacityLevel <= Constant.upgradeCost.Count)
            {
                capacityUpgradeCost.text = Constant.upgradeCost[playerCapacityLevel - 1].ToString();
            }
            else
            {
                capacityUpgradeCost.text = "MAX";
            }
            ShowUpgradeUi();
        }
    }
}
