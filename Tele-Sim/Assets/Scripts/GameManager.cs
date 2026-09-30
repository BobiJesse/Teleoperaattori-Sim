using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Events")]
    public List<BigProblemEvent> bigEvents = new List<BigProblemEvent>();
    public List<SmallProblemEvent> smallEvents = new List<SmallProblemEvent>();

    [Header("Windows")]
    public GameObject smallProblemWindow;
    public GameObject bigProblemWindow;
    public GameObject mapWindow;
    public GameObject emailWindow;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEvent()
    {
        int randomNumber = Random.Range(0, 5);

        if (randomNumber < 4)
        {
            TriggerSmallEvent();
        }
        else
        {
            TriggerBigEvent();
        }
    }

    public void TriggerSmallEvent()
    {
        int weight = 0;

        foreach (var smallProblemEvent in smallEvents)
        {
            weight += smallProblemEvent.weight;
        }

        int roll = Random.Range(0, weight);

        foreach (var listedEvent in smallEvents)
        {
            if (roll < listedEvent.weight)
            {
                listedEvent.Trigger();
                break;
            }

            roll -= listedEvent.weight;
        }
    }

    public void TriggerBigEvent()
    {
        int weight = 0;

        foreach (var bigProblemEvent in bigEvents)
        {
            weight += bigProblemEvent.weight;
        }

        int roll = Random.Range(0, weight);

        foreach (var listedEvent in bigEvents)
        {
            if (roll < listedEvent.weight)
            {
                listedEvent.Trigger();
                break;
            }

            roll -= listedEvent.weight;
        }
    }
}
