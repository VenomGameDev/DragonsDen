using UnityEngine;


public class GoldPickup : MonoBehaviour
{
    
public PlayerInventory playerInventory;
public GameObject goldImage;
BanditEnemy banditEnemy;

public bool isPickedUp;



void Start()

{

banditEnemy = GetComponent<BanditEnemy>();

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
    Destroy(other.gameObject);
    GainGold();
    }

}

void GainGold(int gold = 1)
{

    playerInventory.goldCount += gold;


}


}
