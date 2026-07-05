using UnityEngine;

[CreateAssetMenu(fileName = "FoodObject", menuName = "Food")]
public class FoodObject : ScriptableObject
{
    [SerializeField] public GameObject mesh;
    [SerializeField] public int score;
}