using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite alertSprite;

    [SerializeField] private float pulseAmount = 1.08f;
    [SerializeField] private float pulseSpeed = 0.15f;

    private Vector3 originalScale;
    private Coroutine pulseCoroutine;
    public GameObject infoPage;
    public GameObject fixButton;
    public bool isBroken;

    [Header("Tekstit")]
    public TextMeshProUGUI descriptionText;
    public string workingText;
    public string brokenText;

    private void Awake()
    {
        originalScale = buttonImage.transform.localScale;
    }

    private void Start()
    {
        descriptionText.text = workingText;
    }

    public void SetAlert(bool alert)
    {
        if(alert)
        {
            isBroken = true;
            fixButton.SetActive(true);
            if(infoPage.activeSelf == false)
            {
                infoPage.SetActive(true);
            }
            descriptionText.text = brokenText;
            buttonImage.sprite = alertSprite;
            if (pulseCoroutine == null)
            {
                pulseCoroutine = StartCoroutine(Pulse());
            }
        }
        else
        {
            isBroken = false;
            fixButton.SetActive(false);
            descriptionText.text = workingText;
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

        GameManager.instance.brokenTowers.Remove(this);
        GameManager.instance.Towers.Add(this);
    }
}
