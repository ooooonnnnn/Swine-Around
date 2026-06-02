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
        
        
        //TODO
        /*
         * list doesnt work coz new scene = new objects
         *  give food ids?
         *  compare names?
         *  if food is eaten, its removed from dnd list aswell -> needs fix aswell
         * maybe best idea is actually keeping their ids... or make food spawner?
         * like, not have pre-spawned food, but have spawn points and food manager, that trackes consumed/not and destroyed/not?
         */
        
    }
}