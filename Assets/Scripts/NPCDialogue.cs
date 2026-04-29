
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    
    public TMP_Text npcInteractText;
    public GameObject npcDialogueMenu;
    public GameObject rumorsDialogue;
    public GameObject waresDialogue;
    public GameObject dualBladeDialogue;
    public GameObject cam1;
    public GameObject cam2;
    public NPCMenu npcMenu;

    public AudioSource audioSourceWorldMusic;
    public AudioSource audioSourceMerchant;
    
    
    void Start() 
    
    {

        dualBladeDialogue.SetActive(false);
        npcDialogueMenu.SetActive(false);
        npcInteractText.enabled = false;
        
    }


    void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.tag == "Player")
        {
        audioSourceWorldMusic.Stop();
        audioSourceMerchant.Play();
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
        npcDialogueMenu.SetActive(false);
        rumorsDialogue.SetActive(false);
        waresDialogue.SetActive(false);
        dualBladeDialogue.SetActive(false);
        audioSourceMerchant.Stop();
        audioSourceWorldMusic.Play();

    }

    void OnTriggerStay2D(Collider2D other) 
    {

    if (Input.GetKey(KeyCode.F))
        {
            
            npcDialogueMenu.SetActive(true);
            npcInteractText.enabled = false;
            
        }

    }


}
