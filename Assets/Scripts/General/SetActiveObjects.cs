using System;
using UnityEngine;

namespace General
{
    public class SetActiveObjects : MonoBehaviour
    {
        [SerializeField] private GameObject[] objectsToSetActive;
        [SerializeField] private bool[] initialStates;

        private void OnValidate()
        {
            initialStates = new bool[objectsToSetActive.Length];
            for (int i = 0; i < objectsToSetActive.Length; i++)
            {
                initialStates[i] = objectsToSetActive[i].activeSelf;
            }
        }

        public void SetActives(bool state)
        {
            for (int i = 0; i < objectsToSetActive.Length; i++)
            {
                objectsToSetActive[i].SetActive(state ^ initialStates[i]);
            }
        }
    }
}