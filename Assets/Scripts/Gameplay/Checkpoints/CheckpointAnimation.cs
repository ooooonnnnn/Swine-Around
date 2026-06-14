using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CheckpointAnimation : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerVisual;

    [SerializeField] private Image SaveIcon;
    
    [SerializeField] private CharacterTurnToMoveDir playerRotatorScript;
    
    public void PlaySequence(Checkpoint checkpoint)
    {
        StartCoroutine(Sequence(checkpoint));
    }

    private IEnumerator Sequence(Checkpoint checkpoint)
    {
        Vector3 originalPos = playerVisual.position;
        Quaternion originalRot = playerVisual.rotation;
        
        playerInput.DeactivateInput();
        playerRotatorScript.enabled = false;

        Tween saveTween = PlaySaveIconAnimation();

        Sequence seq = DOTween.Sequence();

        seq.Append(
            playerVisual.DOMove(
                checkpoint.SleepPos.position,
                0.4f
            )
        );

        seq.Join(
            playerVisual.DORotateQuaternion(
                checkpoint.SleepPos.rotation,
                0.4f
            )
        );

        seq.AppendInterval(0.5f);

        seq.Append(
            playerVisual.DOMove(
                originalPos,
                0.3f
            )
        );

        seq.Join(
            playerVisual.DORotateQuaternion(
                originalRot,
                0.3f
            )
        );

        yield return seq.WaitForCompletion();
        yield return saveTween.WaitForCompletion();

        yield return new WaitForSeconds(0.5f);

        playerInput.ActivateInput();
        playerRotatorScript.enabled = true;
    }
    
    private Tween PlaySaveIconAnimation()
    {
        SaveIcon.gameObject.SetActive(true);

        RectTransform rt = SaveIcon.rectTransform;

        Vector2 finalPos = rt.anchoredPosition;
        Vector2 startPos = finalPos + new Vector2(0, -80f); // start below

        rt.anchoredPosition = startPos;

        Color c = SaveIcon.color;
        c.a = 0f;
        SaveIcon.color = c;

        Sequence seq = DOTween.Sequence();

        seq.Append(
            rt.DOAnchorPos(finalPos, 0.35f)
                .SetEase(Ease.OutCubic)
        );

        seq.Join(
            SaveIcon.DOFade(1f, 0.2f)
        );

        seq.AppendInterval(0.5f);

        seq.Append(
            SaveIcon.DOFade(0f, 0.2f)
        );

        seq.OnComplete(() =>
        {
            SaveIcon.gameObject.SetActive(false);
        });

        return seq;
    }
    
}