using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;





public class TestTest : MonoBehaviour

{

public bool isTriggered = false;

public NPCShop npcShop;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Test()
    {
        Debug.Log("Before Boolean");
        isTriggered = true;
        Debug.Log(npcShop.playerBuyCount + " item purchased from shop!");


    }



}
