using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    
public PlayerInventory PlayerInventory;
int playerGoldCount = 0;


void Start() 

{

   
   

}


void Update()
{
    
playerGoldCount = PlayerInventory.goldCount;


}

public void BuyPotion()


{

    if (playerGoldCount >= 10)

    {

        Debug.Log("Potion purchased!");
        PlayerInventory.goldCount -= 10;
        PlayerInventory.potionCount += 1;

    }

    else 
        Debug.Log("DIdn't work");


}





}
