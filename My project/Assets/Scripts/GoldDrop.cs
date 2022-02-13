
using UnityEngine;

public class GoldDrop : MonoBehaviour
{
   

    public GameObject GoldSpriteImage;
    public Transform goldDropLocation1;
    public Transform goldDropLocation2;


    
    

    public void DropGold()  
    {

        var goldSpriteImage = Instantiate(GoldSpriteImage, goldDropLocation1);
        
        var goldDrop = goldSpriteImage.GetComponent<PlayerInventory>();

        GoldSpriteImage = GameObject.FindGameObjectWithTag("Gold");



    }
}
