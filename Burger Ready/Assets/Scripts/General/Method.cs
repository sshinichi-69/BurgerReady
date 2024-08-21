using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady
{
    public static class Method
    {
        public static bool IsEqual(Vector3 a, Vector3 b)
        {
            return (a - b).magnitude < 0.1f;
        }
    }
}
