using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "BigProblemEvent", menuName = "Scriptable Objects/BigProblemEvent")]
public class BigProblemEvent : ScriptableObject
{
    [Header("Problem Info")]
    public string problemName;
    public string problemDescription;

    [Header("Notifications")]
    public GameObject notificationBanner;
    public TextMeshProUGUI notificationText;

    public int weight = 1;

    public void Trigger()
    {
        Debug.Log("BigProblemEvent Triggered: " + problemDescription);
    }
}
