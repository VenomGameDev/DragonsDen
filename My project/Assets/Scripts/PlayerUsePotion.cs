
using UnityEngine;

public class PlayerUsePotion : MonoBehaviour
{

    public PlayerInventory pLayerInventory;
    public PlayerStats playerStats;



    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && pLayerInventory.potionCount >= 1)
        {

            pLayerInventory.potionCount -= 1;
            playerStats.currentHealth += 30;



        }



    }
}
