using TMPro;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Sprite workingSprite;
    public Sprite brokenSprite;

    [Header("Information")]
    public string objectName;
    public string workingText;
    public string problemText;

    public bool working = true;

    private void Awake()
    {
        nameText.text = objectName;
        descriptionText.text = workingText;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakObject()
    {
        working = false;

        descriptionText.text = problemText;
    }

    public void FixObject()
    {
        working = true;

        descriptionText.text = workingText;
    }
}
