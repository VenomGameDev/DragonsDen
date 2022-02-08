using UnityEngine;


public class GoldPickup : MonoBehaviour
{
    
public PlayerInventory playerInventory;
public GameObject goldImage;
public BanditEnemy banditGoldDrop;
public int banditGoldAcquired;

public bool isPickedUp;



void Start()

{

banditGoldAcquired = banditGoldDrop.banditGold;


}

void Update()
{

isPickedUp = false;

}

void OnTriggerEnter2D(Collider2D other) 


{

    if (isPickedUp) return;
    else if (other.tag == "Gold" && !isPickedUp)
    {
    isPickedUp = true;
    FindObjectOfType<AudioManager>().Play("CoinPickup");
    playerInventory.goldCount += banditGoldAcquired;
    Destroy(other.gameObject);
    }

}




}
