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
        
        public int score = 999;
        public float popUpDuration = 2.0f;
        public float upMovementDistance = 3.0f;
        
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