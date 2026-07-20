using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Transform livesContainer;
    [SerializeField] private GameObject fullHeartPrefab, emptyHeartPrefab;

    private void Start()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        if (!ScoreManager.Instance)
        {
            Debug.LogWarning("Can't update lives UI, ScoreManager not found");
            return;
        }
        
        ClearContainer();

        for (int i = 0; i < ScoreManager.Instance.LivesLeft; i++)
        {
            Instantiate(fullHeartPrefab, livesContainer);
        }

        for (int i = 0; i < ScoreManager.Instance.LivesLost; i++)
        {
            Instantiate(emptyHeartPrefab, livesContainer);
        }
    }

    private void ClearContainer()
    {
        List<Transform> childrenToKill = new();
        foreach (Transform child in livesContainer)
        {
            childrenToKill.Add(child);
        }

        childrenToKill.ForEach(c => Destroy(c.gameObject));
    }
}
