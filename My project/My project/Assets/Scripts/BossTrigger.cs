
using UnityEngine;





public class BossTrigger : MonoBehaviour
{
    
    public GameObject bossCam;
    public GameObject mainCam;
    public AudioSource audioSource;
    public BoxCollider2D boxCollider2D;
    public BanditEnemy banditEnemy;
    public AudioSource audioSourceWorldMusic;

void Start()

{
    boxCollider2D = boxCollider2D.GetComponent<BoxCollider2D>();
    banditEnemy = banditEnemy.GetComponent<BanditEnemy>();

    bossCam.SetActive(false);
    boxCollider2D.enabled = false;
}

    void OnTriggerEnter2D(Collider2D other) 
    
    {
        if(other.tag == "Player" && banditEnemy.currentHealth > 0)
        {
        audioSourceWorldMusic.enabled = false;
        audioSource.Play();
        mainCam.SetActive(false);
        bossCam.SetActive(true);
        boxCollider2D.enabled = true;
        }
    }


    void Update()
    {

        if (banditEnemy.currentHealth <= 0 && banditEnemy.isBanditBoss)
        {

        mainCam.SetActive(true);
        bossCam.SetActive(false);
        audioSource.Stop();
        boxCollider2D.enabled = false;



        }




    }

}
