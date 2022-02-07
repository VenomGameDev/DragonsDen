using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    PlayerMovement playerMovement;
    PlayerAttack playerAttack;

    public TMP_Text attackText;
    public TMP_Text defenseText;

    public int maxHealth = 100;
    public int currentHealth;
    public int playerStrength = 30;
    public int playerDefense = 0;

    public Animator animator;
    CapsuleCollider2D playerCollider;


    public TMP_Text Hitpoints;

    public Canvas mainScreen;
    public Canvas deathScreen;

    public HealthBar healthBar;


    

    void Start()
    {
        deathScreen.enabled = false;
        currentHealth = maxHealth;
        Hitpoints.text = currentHealth.ToString();
        playerCollider = GetComponent<CapsuleCollider2D>();


        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }


    public void TakeDamage(int damage)

    {
        animator.SetTrigger("TakeDamage");
        currentHealth -= damage;
        GameOver();
    }


        void Update()
    {

        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        Hitpoints.text = currentHealth.ToString();
        attackText.text = playerStrength.ToString();

    }


    void GameOver()
    {

        if (currentHealth <= 0)
        {


            animator.SetTrigger("Death");
            this.enabled = false;
            playerMovement.enabled = false;
            playerAttack.enabled = false;
            playerCollider.enabled = false;
            mainScreen.enabled = false;
            deathScreen.enabled = true;
            

        }


    }


}
