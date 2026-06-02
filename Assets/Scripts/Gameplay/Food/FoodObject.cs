using System;
using UnityEngine;

namespace Gameplay.Food
{
    public class FoodObject : MonoBehaviour
    {
        // private void Awake()
        // {
        //     if (!LevelReseting.Instance)
        //         return;
        //     if (!LevelReseting.Instance.AddToDoNotDestroy(gameObject))
        //     {
        //         Destroy(gameObject);
        //     }
        //     Debug.Log($"Object {gameObject.name} added to DND");
        // }
        
        
        // this idea did not work... try mapping all food with this bool
        // isEaten = false;
        // and just not spawn it if it is eaten

        // private void Awake()
        // {
        //     if (isEaten)
        //         Destroy(gameObject);
        // }

     
    }
}