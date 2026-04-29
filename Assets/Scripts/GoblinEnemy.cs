using TMPro;
using UnityEngine;

public class GoblinEnemy : MonoBehaviour
{
    
 public GameObject FloatingTextPrefab;
    public Animator animator;
    public EnemyAI textFlip;
   
    public PlayerLevel expGain;
    public GoldDrop goldDrop;

    public int goblinMaxHealth = 60;
    public int currentHealth;
    public int goblinExp = 10;
    public int goblinGold = 1;
    public bool isDead = false;

    public int damageTaken;

    public Transform banditAttackPoint;
    public Transform floatingTextPosition;

    public int goblinAttackDamage = 10;
    public float attackRange = 0.5f;
    public float timeBetweenAttacks, cooldown;


    public LayerMask playerLayer;

    public void Start()
    {
        
        
        cooldown = 2;
        currentHealth = goblinMaxHealth;
        timeBetweenAttacks = cooldown;

    }

    private void Update()
    {

        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0 && !isDead)
        {
            goblinAttack();
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
            isDead = true;
            expGain.GainExp(10);
            Die();
            
            
        }

        void Die()
        {
           
            animator.SetTrigger("GoblinKilled");
            animator.SetBool("isDead", true);
            goldDrop.DropGold();
            Destroy(gameObject, 2);

        }


    }


    void goblinAttack()
    {

        animator.SetTrigger("GoblinAttack");
        timeBetweenAttacks = cooldown;

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(banditAttackPoint.position, attackRange, playerLayer);

        //Damage the Player
        foreach (Collider2D player in hitPlayer)
        {
                player.GetComponent<PlayerStats>().TakeDamage(goblinAttackDamage);
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
