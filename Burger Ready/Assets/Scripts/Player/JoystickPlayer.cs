using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Player
{
    public class JoystickPlayer : MonoBehaviour
    {
        [SerializeField] private float speed = 100;
        [SerializeField] private VariableJoystick variableJoystick;

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            if (direction != Vector3.zero)
            {
                transform.LookAt(transform.position + direction);
                transform.Translate(speed * Time.deltaTime * direction.magnitude * Vector3.forward);
            }
        }
    }
}
