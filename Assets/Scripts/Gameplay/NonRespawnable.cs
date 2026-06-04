using System;
using UnityEngine;

namespace Gameplay
{
    public class NonRespawnable : MonoBehaviour
    {
        [HideInInspector] public string id;
        private void Awake()
        {
            if(LevelStateManager.Instance.destroyed.Contains(id))
                Destroy(gameObject);
        }

        public void DestroyObject()
        {
            var eatenFood = LevelStateManager.Instance.destroyed;
            if (!eatenFood.Contains(id))
                eatenFood.Add(id);
        }
    }
}