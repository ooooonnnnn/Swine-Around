using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    [SerializeField] private SpeedModifierConfig config;
    [SerializeField] private CharacterMoveTangent movement;

    public void HandleFullnessChanged(int fullnessState)
    {
        float multiplier = 1f;

        foreach (var entry in config.entries)
        {
            if (entry.fullnessState == fullnessState)
            {
                multiplier = entry.speedMultiplier;
                break;
            }
        }

        movement.SetSpeedMultiplier(multiplier);
    }
}