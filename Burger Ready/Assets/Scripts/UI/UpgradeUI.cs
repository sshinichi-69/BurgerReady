using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.UI
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_upgradeRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarryRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_iconRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_descriptionRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_levelRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_buttonRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_button_goldRt;
        [SerializeField] private RectTransform m_upgrade_burgerCarry_button_textRt;
        [SerializeField] private RectTransform m_upgrade_exitRt;

        private void Awake()
        {
            m_upgradeRt.sizeDelta = new Vector2(Screen.width, Screen.height / 2);

            m_upgrade_burgerCarryRt.sizeDelta = new Vector2(Screen.width * 0.3f, m_upgradeRt.sizeDelta.y * 0.85f);

            m_upgrade_burgerCarry_iconRt.anchoredPosition = new Vector2(0, m_upgrade_burgerCarryRt.sizeDelta.y / 4);
            m_upgrade_burgerCarry_iconRt.sizeDelta = new Vector2(
                m_upgrade_burgerCarryRt.sizeDelta.y * 0.15f,
                m_upgrade_burgerCarryRt.sizeDelta.y * 0.15f
            );

            m_upgrade_burgerCarry_descriptionRt.anchoredPosition = new Vector2(0, m_upgrade_burgerCarryRt.sizeDelta.y / 12);
            m_upgrade_burgerCarry_descriptionRt.sizeDelta = new Vector2(
                m_upgrade_burgerCarryRt.sizeDelta.x,
                m_upgrade_burgerCarryRt.sizeDelta.y / 12
            );
            m_upgrade_burgerCarry_descriptionRt.GetComponent<Text>().fontSize = Screen.height / 33;

            m_upgrade_burgerCarry_levelRt.anchoredPosition = new Vector2(0, -m_upgrade_burgerCarryRt.sizeDelta.y / 12);
            m_upgrade_burgerCarry_levelRt.sizeDelta = new Vector2(
                m_upgrade_burgerCarryRt.sizeDelta.x,
                m_upgrade_burgerCarryRt.sizeDelta.y / 12
            );
            m_upgrade_burgerCarry_levelRt.GetComponent<Text>().fontSize = Screen.height / 33;

            m_upgrade_burgerCarry_buttonRt.anchoredPosition = new Vector2(0, -m_upgrade_burgerCarryRt.sizeDelta.y / 4);
            m_upgrade_burgerCarry_buttonRt.sizeDelta = new Vector2(
                m_upgrade_burgerCarryRt.sizeDelta.x * 0.7f,
                m_upgrade_burgerCarryRt.sizeDelta.y * 0.15f
            );

            m_upgrade_burgerCarry_button_goldRt.anchoredPosition = new Vector2(-m_upgrade_burgerCarry_buttonRt.sizeDelta.x / 4, 0);
            m_upgrade_burgerCarry_button_goldRt.sizeDelta = new Vector2(
                m_upgrade_burgerCarry_buttonRt.sizeDelta.y * 0.7f,
                m_upgrade_burgerCarry_buttonRt.sizeDelta.y * 0.7f
            );

            m_upgrade_burgerCarry_button_textRt.anchoredPosition = new Vector2(m_upgrade_burgerCarry_button_goldRt.sizeDelta.x / 2, 0);
            m_upgrade_burgerCarry_button_textRt.sizeDelta = m_upgrade_burgerCarry_buttonRt.sizeDelta;
            m_upgrade_burgerCarry_button_textRt.GetComponent<Text>().fontSize = Screen.height / 33;

        }
    }
}
