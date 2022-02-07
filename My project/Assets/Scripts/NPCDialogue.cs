
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    
    public TMP_Text npcInteractText;
    public Canvas npcDialogueMenu;
    public Canvas rumorsDialogue;
    public Canvas waresDialogue;
    public GameObject cam1;
    public GameObject cam2;


    void Start() 
    
    {
        npcDialogueMenu.enabled = false;
        npcInteractText.enabled = false;

    }


    void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.tag == "Player")
        {
        Debug.Log("Test");
        npcInteractText.enabled = true;
        cam1.SetActive(false);
        cam2.SetActive(true);
        
        }


    }

    void OnTriggerExit2D(Collider2D other)
    
    {

        npcInteractText.enabled = false;
        cam1.SetActive(true);
        cam2.SetActive(false);
        npcDialogueMenu.enabled = false;
        rumorsDialogue.enabled = false;
        waresDialogue.enabled = false;

    }

    void OnTriggerStay2D(Collider2D other) 
    {

    if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Ayyy");
            npcDialogueMenu.enabled = true;
            npcInteractText.enabled = false;
            
        }

    }


}
