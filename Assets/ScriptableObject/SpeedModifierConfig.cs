using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedModifierConfig", menuName = "Configs/Speed Modifier")]
public class SpeedModifierConfig : ScriptableObject
{
    public SpeedModifierEntry[] entries;
}

[Serializable]
public class SpeedModifierEntry
{
    public int fullnessState;
    [Range(0f, 1f)]
    public float speedMultiplier = 1f;
}