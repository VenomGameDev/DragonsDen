using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;



    public PlayerStats playerStrength;

    public int attackDamage;
    public float attackRange = 0.5f;


    public LayerMask enemyLayers;

    public float timeBetweenAttacks, cooldown;

    void Start()
    {
        cooldown = .5f;
        timeBetweenAttacks = cooldown;
        
    }

    void Update()
    {
        attackDamage = playerStrength.playerStrength;
        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Attack();
                FindObjectOfType<AudioManager>().Play("Swing1");
                Debug.Log("You hit the bandit for " + attackDamage);
            }
           
        }

    }

     void Attack()
    {
        //Animation for attack + CD period
        animator.SetTrigger("Attack");
        timeBetweenAttacks = cooldown;
        animator.SetBool("isAttacking", false);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        { 
                enemy.GetComponent<BanditEnemy>().TakeDamage(attackDamage);
            FindObjectOfType<AudioManager>().Play("Slice");
        }
    }



    //Function that shows the attack radius of the attack point.
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }


}
