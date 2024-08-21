using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

namespace BurgerReady.UnlockBT
{
    public class UnlockBT : BehaviorTree.BehaviorTree
    {
        protected override Node SetupTree()
        {
            StartCoroutine(_SetupTree());
            return null;
        }

        private IEnumerator _SetupTree()
        {
            yield return new WaitForSeconds(0.01f);
            if (GameManager.Instance == null)
            {
                StartCoroutine(_SetupTree());
            }
            else
            {
                _root = new Selector(new List<Node>()
                {
                    new Sequence(new List<Node>()
                    {
                        new CheckLevelUp(GameManager.Instance.Level, 1),
                        new TaskUnlockSlot(GameManager.Instance.Restaurant.TableManager)
                    }),
                    new Sequence(new List<Node>()
                    {
                        new CheckLevelUp(GameManager.Instance.Level, 3),
                        new TaskUnlockSlot(GameManager.Instance.Restaurant.TableManager)
                    }),
                    new Sequence(new List<Node>()
                    {
                        new CheckLevelUp(GameManager.Instance.Level, 3),
                        new TaskUnlockSlot(GameManager.Instance.Restaurant.TableManager)
                    }),
                    new Sequence(new List<Node>()
                    {
                        new CheckLevelUp(GameManager.Instance.Level),
                        new TaskUnlockSlot(GameManager.Instance.Restaurant.TableManager)
                    }),
                });
            }
        }
    }
}
