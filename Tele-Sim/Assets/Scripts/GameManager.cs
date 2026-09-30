using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

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

    }
}
