using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.UI
{
    public class VariableJoystickUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_variableJoystickRt;
        [SerializeField] private RectTransform m_variableJoystick_backgroundRt;
        [SerializeField] private RectTransform m_variableJoystick_background_handleRt;

        void Awake()
        {
            m_variableJoystickRt.sizeDelta = new Vector2(Screen.width, Screen.height / 2);

            m_variableJoystick_backgroundRt.sizeDelta = new Vector2(
                m_variableJoystick_backgroundRt.sizeDelta.y * 0.4f,
                m_variableJoystick_backgroundRt.sizeDelta.y * 0.4f
            );

            m_variableJoystick_background_handleRt.sizeDelta = m_variableJoystick_backgroundRt.sizeDelta * 0.67f;
        }
    }
}
