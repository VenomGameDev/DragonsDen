using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BanditBoss : MonoBehaviour
{
    
    [SerializeField] Animator animator;
    [SerializeField] GoldDrop goldDrop;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Transform goldDropLocation;
    [SerializeField] Transform banditBossAttackPoint;
    [SerializeField] GameObject healthBar;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text banBossHPText;

    [SerializeField] int banBossMaxHP;
    [SerializeField] public int banBossCurrentHP;
    [SerializeField] int banBossAttackDamage;
    [SerializeField] int banBossEXP;
    [SerializeField] float attackRange = 0.5f;
    [SerializeField] float timeBetweenAttacks = 1.5f;
    [SerializeField] float cooldown = 3f;


    [SerializeField] bool isDead;


    void Start()
    {
        healthBar.SetActive(false);
        slider.maxValue = banBossMaxHP;
        banBossHPText.text = banBossMaxHP.ToString();
        banBossCurrentHP = banBossMaxHP;
    }
    void Update()
    {
        slider.value = banBossCurrentHP;
        if (timeBetweenAttacks > 0)
        {
            timeBetweenAttacks -= Time.deltaTime;
        }
        else if (timeBetweenAttacks <= 0 && !isDead)
        {
            banditBossAttack();
        }
    }
    void banditBossAttack()
    {
        
            animator.SetTrigger("BanditAttack");
            timeBetweenAttacks = cooldown;

            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(banditBossAttackPoint.position, attackRange, playerLayer);

            //Damage the Player
            foreach (Collider2D player in hitPlayer)
            {
                player.GetComponent<PlayerStats>().TakeDamage(banBossAttackDamage);
                FindObjectOfType<AudioManager>().Play("Slice");
            }
        
    }

    public void TakeDamage(int damage)

    {
        banBossCurrentHP -= damage;
        healthBar.SetActive(true);
        banBossHPText.text = banBossCurrentHP.ToString();

        animator.SetTrigger("TakeDamage");

        if (banBossCurrentHP <= 0)
        {
            FindObjectOfType<PlayerLevel>().GainExp(banBossEXP);
            Die();
        }

        void Die()
        {
            isDead = true;
            animator.SetTrigger("BanditKilled");
            healthBar.SetActive(false);
            goldDrop.DropGold();
            goldDropLocation.transform.parent = null;
            Invoke("DisableEnemy", 1.5f);

        }
    }

    private void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

void OnDrawGizmosSelected()
    {
        if (banditBossAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(banditBossAttackPoint.position, attackRange);

    }


}
