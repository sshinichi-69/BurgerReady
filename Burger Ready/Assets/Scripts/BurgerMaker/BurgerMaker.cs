using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant
{
    enum BurgerMakerState
    {
        IDLE,
        COOKING
    }

    public class BurgerMaker : MonoBehaviour
    {
        private int nMaxBurger = 6;
        private BurgerMakerState state;
        private Stack<GameObject> burgersCompleted;

        [SerializeField] private Animator burgerMakerAnimator;

        [SerializeField] private GameObject tray;
        [SerializeField] private GameObject burgerPrefab;
        // Start is called before the first frame update
        void Start()
        {
            state = BurgerMakerState.IDLE;
            burgersCompleted = new Stack<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {
            if (state == BurgerMakerState.IDLE)
            {
                if (burgersCompleted.Count < nMaxBurger)
                {
                    CookBurger();
                }
            }
        }

        public void CookBurger()
        {
            state = BurgerMakerState.COOKING;
            burgerMakerAnimator.Play("Base Layer.BurgerMakerCook");
            StartCoroutine(CompleteBurger());
        }

        IEnumerator CompleteBurger()
        {
            yield return new WaitForSeconds(3);
            Vector3 burgerPosition = tray.transform.position + Vector3.up * burgersCompleted.Count * Constant.burgerHeight;
            GameObject burger = Instantiate(burgerPrefab, burgerPosition, Quaternion.identity);
            burger.transform.parent = tray.transform;
            burgersCompleted.Push(burger);
            state = BurgerMakerState.IDLE;
            burgerMakerAnimator.Play("Base Layer.BurgerMakerIdle");
        }

        public List<GameObject> GiveBurger(int quantity)
        {
            int n = quantity <= burgersCompleted.Count ? quantity : burgersCompleted.Count;
            List<GameObject> result = new List<GameObject>();
            for (int i = 0; i < n; i++)
            {
                GameObject burger = burgersCompleted.Peek();
                result.Add(burger);
                burger.transform.SetParent(null, false);
                burgersCompleted.Pop();
            }
            return result;
        }
    }
}
