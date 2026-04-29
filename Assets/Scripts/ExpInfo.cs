using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography.X509Certificates;


public class ExpInfo : MonoBehaviour
{
 


    public GameObject expInfoPanel;


    public bool isOpened = false;

    void Start()
    {
        
    }

   
    void Update()
    {
    

    }


    public void OpenPanel ()
    {
        
        if (!isOpened)
        {
            
            expInfoPanel.SetActive(true);
            isOpened = true;

        }

        else
        {
            isOpened = false;
            expInfoPanel.SetActive(false);
        }

    }





}
