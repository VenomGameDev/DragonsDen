using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BanditEnemy : MonoBehaviour
{

    public Animator animator;
    public LayerMask playerLayer;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    [SerializeField] GoldDrop goldDrop;
    private EnemyPatrol enemyPatrol;

    [SerializeField] GameObject healthBar;

    [SerializeField] Slider slider;
    [SerializeField] TMP_Text banditHealth;

    [SerializeField] Transform banditAttackPoint;
    [SerializeField] Transform goldDropLocation;
    
    [SerializeField] float colliderDistance;
    [SerializeField] float range;
    public int maxHealth = 100;
    public int currentHealth;
    public int banditExp = 40;
    public int banditAttackDamage = 20;
    public float attackRange = 0.5f;
    [SerializeField] float timeBetweenAttacks = 3f;
    [SerializeField] float cooldown = 3f;

    public bool isDead = false;

    void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void OnDisable() 
    {
        animator.SetBool("move", false);
    }

    void Start()
    {
        healthBar.SetActive(false);
        slider.maxValue = maxHealth;
        banditHealth.text = maxHealth.ToString();
        currentHealth = maxHealth;

    }

     void Update()
    {

        slider.value = currentHealth;
        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0 && !isDead)
        {
            banditAttack();
        }
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

    }
    public void TakeDamage(int damage)

    {
        
        currentHealth -= damage;
        healthBar.SetActive(true);
        banditHealth.text = currentHealth.ToString();
        
        animator.SetTrigger("TakeDamage");

        if (currentHealth <= 0)
        {
            FindObjectOfType<PlayerLevel>().GainExp(banditExp);
            Die();
        }

        void Die()
        {
            isDead = true;
            animator.SetTrigger("BanditKilled");
            healthBar.SetActive(false);
            goldDrop.DropGold();
            goldDropLocation.transform.parent =null;
            enemyPatrol.speed = 0f;
            Invoke("DisableEnemy", 1f);

        }
    }
    void banditAttack()
    {
        if (PlayerInSight())
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
    }

private bool PlayerInSight()
{

    RaycastHit2D hit = Physics2D.BoxCast(capsuleCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
    new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z),
    0, Vector2.left, 0, playerLayer);

    return hit.collider !=null;

}

private void OnDrawGizmos() 
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(capsuleCollider.bounds.center + transform.right * range * transform.localScale.x *colliderDistance, new Vector3(capsuleCollider.bounds.size.x * range, 
    capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z));
}

private void DisableEnemy()
{
    gameObject.SetActive(false);
}

}

