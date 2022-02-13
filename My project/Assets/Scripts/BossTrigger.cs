
using UnityEngine;





public class BossTrigger : MonoBehaviour
{
    
    public GameObject bossCam;
    public GameObject mainCam;
    public AudioSource audioSource;
    public BoxCollider2D boxCollider2D;
    public BanditBoss banditBoss;
    public AudioSource audioSourceWorldMusic;

void Start()

{
    boxCollider2D = boxCollider2D.GetComponent<BoxCollider2D>();
    banditBoss = banditBoss.GetComponent<BanditBoss>();

    bossCam.SetActive(false);
    boxCollider2D.enabled = false;
}

    void OnTriggerEnter2D(Collider2D other) 
    
    {
        if(other.tag == "Player" && banditBoss.banBossCurrentHP > 0)
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

        if (banditBoss.banBossCurrentHP <= 0)
        {

        mainCam.SetActive(true);
        bossCam.SetActive(false);
        audioSource.Stop();
        boxCollider2D.enabled = false;



        }




    }

}
