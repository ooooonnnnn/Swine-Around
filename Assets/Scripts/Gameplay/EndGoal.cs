using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public void EndGoalReached()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.WinGame();
        }
    }
}
