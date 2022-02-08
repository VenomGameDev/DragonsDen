using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    
public TMP_Text interactText;
public TMP_Text holyArmorText;

public bool chestOpened = false;
public PlayerStats playerStats;

public Animator animator;


void Start()
{

holyArmorText.enabled = false;

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
    animator.SetBool("chestOpened", true);
    FindObjectOfType<AudioManager>().Play("ItemAcquired");
    playerStats.playerDefense = 5;
    playerStats.defenseText.text = playerStats.playerDefense.ToString();
    holyArmorText.enabled = true;
}

}

void OnTriggerExit2D()
{
interactText.enabled = false;
holyArmorText.enabled = false;
}

}
