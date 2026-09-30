using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "SmallProblemEvent", menuName = "Scriptable Objects/SmallProblemEvent")]
public class SmallProblemEvent : ScriptableObject
{
    [Header("Problem Info")]
    public string problemName;
    public string problemDescription;

    [Header("Notifications")]
    public GameObject notificationBanner;
    public TextMeshProUGUI notificationText;

    public int weight = 1;

    public void Trigger(bool notification)
    {
        if (notification)
        {
            notificationBanner.SetActive(false);
        }
        Debug.Log("SmallProblemEvent Triggered: " + problemDescription);
    }
}
