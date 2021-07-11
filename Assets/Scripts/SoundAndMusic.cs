using DG.Tweening;
using MyColors;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class SoundAndMusic : MonoBehaviour
{
    [SerializeField] protected Image backgroundToggle;
    [SerializeField] protected RectTransform toggleRect;

    [SerializeField] protected Toggle toggle;

    [SerializeField] private float switchDuration = 0.5f;
    protected abstract string PlayerPrefsKey { get; }

    private Vector2 endPosition = new Vector2(60, 0);
    private Vector2 startPosition = new Vector2(0, 0);

    protected void Start()
    {
        SetState();
    }

    public virtual void Switching(bool check)
    {
        if (check)
        {
            backgroundToggle.DOColor(MyColor.Orange, switchDuration).From(MyColor.White);
            StartCoroutine(MoveAnchoredPosition(endPosition, switchDuration));
        }
        else
        {
            backgroundToggle.DOColor(MyColor.White, switchDuration).From(MyColor.Orange);
            StartCoroutine(MoveAnchoredPosition(startPosition, switchDuration));
        }
        SaveState(check);
    }

    protected void SaveState(bool state)
    {
        PlayerPrefs.SetInt(PlayerPrefsKey, BoolToInt(state));
    }

    protected void SetState()
    {
        bool state = IntToBool(PlayerPrefs.GetInt(PlayerPrefsKey, 1));
        toggle.isOn = state;
        if (state)
        {
            backgroundToggle.color = MyColor.Orange;
            toggleRect.anchoredPosition = endPosition;
        }
        else
        {
            backgroundToggle.color = MyColor.White;
            toggleRect.anchoredPosition = startPosition;
        }
    }
    protected IEnumerator MoveAnchoredPosition(Vector2 target, float duration)
    {
        float t = 0;
        while (t < 1)
        {
            toggleRect.anchoredPosition = Vector2.Lerp(toggleRect.anchoredPosition, target, t * t);
            t += Time.deltaTime / duration;
            yield return null;
        }
    }



    protected int BoolToInt(bool state)
    {
        if (state)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    protected bool IntToBool(int state)
    {
        if (state == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
