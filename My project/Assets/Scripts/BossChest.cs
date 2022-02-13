using UnityEngine;
using TMPro;

public class BossChest : MonoBehaviour
{

public TMP_Text dualBladeText;
public TMP_Text interactText;
public Animator animator;
public PlayerStats playerStats;
public bool chestOpened = false;
public PlayerInventory playerInventory;

public AudioSource audioSourceWorldMusic;

    
void Start(){

dualBladeText.enabled = false;

}


void OnTriggerEnter2D()
{

if (!chestOpened)
interactText.enabled = true;


}
void OnTriggerStay2D()
{


if (Input.GetKey(KeyCode.Q))
{

    interactText.enabled = false;
    chestOpened = true;
    animator.SetBool("isOpened", true);
    FindObjectOfType<AudioManager>().Play("ItemAcquired");
    playerStats.playerStrength += 40;
    playerStats.defenseText.text = playerStats.playerDefense.ToString();
    dualBladeText.enabled = true;
    playerInventory.hasDualBlade = true;

    audioSourceWorldMusic.enabled = true;
}

}

void OnTriggerExit2D()
{
interactText.enabled = false;
dualBladeText.enabled = false;
}


}
