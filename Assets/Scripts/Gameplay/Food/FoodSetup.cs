using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Food
{
    public class FoodSetup : MonoBehaviour
    {
        [SerializeField] private FoodObject[] FoodScriptableObjects;
        [SerializeField] private MagnetizableFood foodScript;
        [SerializeField] private Transform root;
        [SerializeField] private MeshRenderer previewMeshRenderer;
        

        private void Awake()
        {
            previewMeshRenderer.enabled = false;
            int currentFoodIndex = Random.Range(0, FoodScriptableObjects.Length);

            Instantiate(FoodScriptableObjects[currentFoodIndex].mesh, root);
            foodScript.foodValue = FoodScriptableObjects[currentFoodIndex].score;
        }
    }
}