using UnityEngine;
using UnityEngine.UI;

public class NPCMenu : MonoBehaviour
{

public Canvas npcDialogueIntro;
public Canvas rumorsMenu;
public Canvas waresMenu;


void Start()

{
    rumorsMenu.enabled = false;
    waresMenu.enabled = false;



}






public void RumorsDialogue()
{

rumorsMenu.enabled = true;
npcDialogueIntro.enabled =false;


}

public void WaresDialogue()
{

rumorsMenu.enabled = false;
npcDialogueIntro.enabled = false;
waresMenu.enabled = true;


}

public void Back()
{

waresMenu.enabled = false;
npcDialogueIntro.enabled = true;



}


}
