using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Gameplay.Effects
{
    
    // just instantiate this in right position, and set its parameters (just score is enough)
    
    public class ScorePopup : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmpAsset;

        [SerializeField] private int score = 999;
        [SerializeField] private float popUpDuration = 2.0f;
        [SerializeField] private float upMovementDistance = 3.0f;

        private void OnValidate()
        {
            tmpAsset = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetScore(int score)
        {
            this.score = score;
            tmpAsset.text = $"+{score}";
        }

        private void Awake()
        {
            tmpAsset.text = $"+{score}";
            
            Sequence seq = DOTween.Sequence();

            seq.Join(transform.DOMove(transform.position + Vector3.up * upMovementDistance, popUpDuration));
            seq.Join(tmpAsset.DOFade(0f, popUpDuration));

            seq.OnComplete(() => Destroy(gameObject));
        }
        
    }
}