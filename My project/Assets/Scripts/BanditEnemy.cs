using UnityEngine;
using TMPro;

public class BanditEnemy : MonoBehaviour
{

    public GameObject FloatingTextPrefab;
    public Animator animator;
    EnemyGFX textFlip;
   
    public PlayerLevel expGain;


    public int banditMaxHealth = 100;
    public int currentHealth;
    public int banditExp = 40;

    public int damageTaken;

    public Transform banditAttackPoint;
    public Transform floatingTextPosition;

    public int banditAttackDamage = 20;
    public float attackRange = 0.5f;
    public float timeBetweenAttacks, cooldown;


    public LayerMask playerLayer;

    public void Start()
    {
        banditExp = 40;
        textFlip = GetComponent<EnemyGFX>();
        cooldown = 2;
        currentHealth = banditMaxHealth;
        timeBetweenAttacks = cooldown;

    }

    private void Update()
    {

        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0)
        {
            banditAttack();
        }

    }

    public void TakeDamage(int damage)

    {
        damageTaken = damage;
        currentHealth -= damage;
        animator.SetTrigger("TakeDamage");

        //Populates floating text if appliable
        if (FloatingTextPrefab)
        {
            ShowFloatingText();
        }

        if (currentHealth <= 0)
        {
            expGain.GainExp();
            Die();
            
            
        }

        void Die()
        {
           
            animator.SetTrigger("BanditKilled");
            
            Destroy(gameObject, 1);

        }


    }


    void banditAttack()
    {

        animator.SetTrigger("BanditAttack");
        timeBetweenAttacks = cooldown;

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(banditAttackPoint.position, attackRange, playerLayer);

        //Damage the Player
        foreach (Collider2D player in hitPlayer)
        {
                player.GetComponent<PlayerStats>().TakeDamage(banditAttackDamage);
            FindObjectOfType<AudioManager>().Play("Slice");
        }


    }

    //Function that populates floating damage text
    void ShowFloatingText()
    {


        if (textFlip.lookingRight == true)
        {
            var go = Instantiate(FloatingTextPrefab, floatingTextPosition.position, Quaternion.identity, transform);
            go.GetComponent<TextMeshPro>().text = damageTaken.ToString();
        }
        else if (textFlip.lookingRight == false)
        {
            var go = Instantiate(FloatingTextPrefab, floatingTextPosition.position, Quaternion.Euler(0,180,0), transform);
            go.GetComponent<TextMeshPro>().text = damageTaken.ToString();


        }

        
    
    }


}
