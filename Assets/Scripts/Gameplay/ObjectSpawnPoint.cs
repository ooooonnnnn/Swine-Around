using System;
using UnityEngine;

namespace Gameplay
{
    public enum ObjectType
    {
        Food,
        Destructable
    }
    public class ObjectSpawnPoint : MonoBehaviour
    {
        private LevelStateManager levelStateManager;
        [SerializeField] public ObjectType spawnObjectType;
        [HideInInspector] public string id;

        private void Start()
        {
            id = gameObject.name;
            levelStateManager = LevelStateManager.Instance;
            if (!levelStateManager.destroyed.Contains(id))
                SpawnObject();
        }

        private void SpawnObject()
        {
            NonRespawnable temp = null;
            if (spawnObjectType == ObjectType.Food)
                temp = Instantiate(
                        levelStateManager.prefabFood, gameObject.transform)
                    .GetComponent<NonRespawnable>();
            else if (spawnObjectType == ObjectType.Destructable)
                temp = Instantiate(
                        levelStateManager.prefabDestructable, gameObject.transform)
                    .GetComponent<NonRespawnable>();
            if(temp)
                temp.id = id;
        }
    }
}