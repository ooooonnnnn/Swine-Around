using UnityEngine;
using UnityEngine.UI;

public class AIStateIconBillboard : MonoBehaviour
{
    [SerializeField] private Image stateIconImage;

    [Header("State Icons")]
    [SerializeField] private Sprite suspicionIcon;
    [SerializeField] private Sprite chaseIcon;

    private void Awake()
    {
        Hide();
    }

    public void ShowState(IPoliceState state)
    {
        if (!stateIconImage || state == null)
        {
            return;
        }

        Sprite icon = GetIconForState(state);

        if (!icon)
        {
            Hide();
            return;
        }

        stateIconImage.sprite = icon;
        stateIconImage.enabled = true;
    }

    public void Hide()
    {
        if (stateIconImage)
        {
            stateIconImage.enabled = false;
            stateIconImage.sprite = null;
        }
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