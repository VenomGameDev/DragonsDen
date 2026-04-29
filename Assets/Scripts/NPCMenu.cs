using UnityEngine;
using UnityEngine.UI;

public class NPCMenu : MonoBehaviour
{

public GameObject npcDialogueIntro;
public GameObject rumorsMenu;
public GameObject waresMenu;
public GameObject dualBlade;
public GameObject gameEnd;

public bool isGameEnded = false;

public NPCDialogue npcDialogue;
public PlayerInventory playerInventory;
public EndGame endGame;


public void RumorsDialogue()
{
    if (playerInventory.hasDualBlade)
    {
    dualBlade.SetActive(true);
    npcDialogueIntro.SetActive(false);
    }
    else
    {
    rumorsMenu.SetActive(true);
    npcDialogueIntro.SetActive(false);
    }

}

public void WaresDialogue()
{
waresMenu.SetActive(true);
rumorsMenu.SetActive(false);
npcDialogueIntro.SetActive(false);



}


public void HandOverDualBlade()
{


gameEnd.SetActive(true);
isGameEnded = true;

npcDialogue.audioSourceMerchant.Stop();
endGame.audioSource.Play();
}


public void Back()
{

dualBlade.SetActive(false);
waresMenu.SetActive(false);
npcDialogueIntro.SetActive(true);



}


}
