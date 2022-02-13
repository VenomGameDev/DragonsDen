using UnityEngine;
using UnityEngine.UI;

public class NPCMenu : MonoBehaviour
{

public Canvas npcDialogueIntro;
public Canvas rumorsMenu;
public Canvas waresMenu;
public Canvas dualBlade;
public Canvas gameEnd;

public bool isGameEnded = false;

public NPCDialogue npcDialogue;
public PlayerInventory playerInventory;
public EndGame endGame;

void Start()

{
    rumorsMenu.enabled = false;
    waresMenu.enabled = false;
    gameEnd.enabled = false;
    


}






public void RumorsDialogue()
{
    if (playerInventory.hasDualBlade)
    {
    dualBlade.enabled = true;
    npcDialogueIntro.enabled =false;
    }
    else
    rumorsMenu.enabled = true;
    npcDialogueIntro.enabled =false;


}

public void WaresDialogue()
{

rumorsMenu.enabled = false;
npcDialogueIntro.enabled = false;
waresMenu.enabled = true;


}


public void HandOverDualBlade()
{


gameEnd.enabled = true;
isGameEnded = true;

npcDialogue.audioSourceMerchant.Stop();
endGame.audioSource.Play();
}


public void Back()
{

dualBlade.enabled = false;
waresMenu.enabled = false;
npcDialogueIntro.enabled = true;



}


}
