using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tower : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite alertSprite;

    [SerializeField] private float pulseAmount = 1.08f;
    [SerializeField] private float pulseSpeed = 0.15f;

    private Vector3 originalScale;
    private Coroutine pulseCoroutine;

    private void Awake()
    {
        originalScale = buttonImage.transform.localScale;
    }

    public void SetAlert(bool alert)
    {
        if(alert)
        {
            buttonImage.sprite = alertSprite;
            if (pulseCoroutine == null)
            {
                pulseCoroutine = StartCoroutine(Pulse());
            }
        }
        else
        {
            buttonImage.sprite = defaultSprite;
            if (pulseCoroutine != null)
            {
                StopCoroutine(pulseCoroutine);
                pulseCoroutine = null;
                buttonImage.transform.localScale = originalScale;
            }
        }
    }

    private IEnumerator Pulse()
    {
        while (true)
        {
            yield return ScaleTo(originalScale * pulseAmount);

            yield return ScaleTo(originalScale);
        }
    }

    private IEnumerator ScaleTo(Vector3 target)
    {
        Vector3 start = transform.localScale;
        float time = 0f;

        while(time < pulseSpeed)
        {
            transform.localScale = Vector3.Lerp(start, target, time / pulseSpeed);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }

    public void fixTower()
    {
        SetAlert(false);
    }
}
