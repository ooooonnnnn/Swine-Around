using UnityEngine;

public class ReadMeFood : MonoBehaviour
{
    [TextArea(10, 30)]
    public string notes =
        @"Food setup:

- Food Prefab (mesh can be changed later if needed)
- Preferably will be added to Pooling system when not in prototype
- Add Empty GameObject on player, add Trigger Collider to it, add ItemMagnet script to it
- Add PlayerFoodScript to player with Trigger Collider on it

Scale changes happen in PlayerFoodScript

";
}