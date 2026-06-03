using UnityEngine;
using UnityEngine.UI;

public class AIStateIconBillboard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image stateIconImage;

    [Header("State Icons")]
    [SerializeField] private Sprite suspicionIcon;
    [SerializeField] private Sprite chaseIcon;

    private void Awake()
    {
        HideIcon();
    }

    public void HandleStateChanged(IPoliceState state)
    {
        if (!stateIconImage || state == null)
        {
            return;
        }

        Sprite icon = GetIconForState(state);

        if (!icon)
        {
            HideIcon();
            return;
        }

        stateIconImage.sprite = icon;
        stateIconImage.enabled = true;
    }

    private void HideIcon()
    {
        if (!stateIconImage)
        {
            return;
        }

        stateIconImage.enabled = false;
        stateIconImage.sprite = null;
    }

    private Sprite GetIconForState(IPoliceState state)
    {
        if (state is PoliceSuspicionState)
        {
            return suspicionIcon;
        }

        if (state is PoliceChaseState)
        {
            return chaseIcon;
        }
        
        return null;
    }
}