using NUnit.Framework;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class EmailManager : MonoBehaviour
{
    [Header("Email Info")]
    public string emailTitle;
    public string emailHeader;
    public string emailText;

    public List<Email> emails = new List<Email>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
