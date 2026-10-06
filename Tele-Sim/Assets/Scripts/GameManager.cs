using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Events")]
    //public List<BigProblemEvent> bigEvents = new List<BigProblemEvent>();
    //public List<SmallProblemEvent> smallEvents = new List<SmallProblemEvent>();
    public List<Tower> Towers = new List<Tower>();
    public List<Tower> brokenTowers = new List<Tower>();

    public GameObject endIMG;

    /*
    [Header("Windows")]
    public GameObject smallProblemWindow;
    public GameObject bigProblemWindow;
    public GameObject mapWindow;
    public GameObject emailWindow;
    */

    [Header("Timers")]
    public float minEventTime = 10f;
    public float maxEventTime = 30f;


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
        StartCoroutine(RandomEventTimer());
    }

    IEnumerator RandomEventTimer()
    {
        while (true)
        {
            float randomTime = Random.Range(minEventTime, maxEventTime);

            yield return new WaitForSeconds(randomTime);

            TriggerEvent();
        }
    }

    public void TriggerEvent()
    {
        if (Towers.Count <= 1)
        {
            AudioManager.Instance.PlayGameEndSound();
            Debug.Log("You lost");
            endIMG.SetActive(true);
            return;
        }

        int num = Random.Range(0, Towers.Count);

        Tower currentMapObject = Towers[num];
        Towers.Remove(currentMapObject);
        brokenTowers.Add(currentMapObject);

        currentMapObject.SetAlert(true);
        AudioManager.Instance.PlayBigAlertSound();


        /*
        int randomNumber = Random.Range(0, 5);

        if (randomNumber < 4)
        {
            //TriggerSmallEvent();
        }
        else
        {
            //TriggerBigEvent();
        }
        */

    }
}

  

    /*public void TriggerSmallEvent()
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
                if (smallProblemWindow.activeSelf)
                {
                    listedEvent.Trigger(true);
                }
                else
                {
                    listedEvent.Trigger(false);
                }
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
                if (bigProblemWindow.activeSelf)
                {
                    listedEvent.Trigger(true);
                }
                else
                {
                    listedEvent.Trigger(false);
                }
                break;
            }

            roll -= listedEvent.weight;
        }
    }

}*/