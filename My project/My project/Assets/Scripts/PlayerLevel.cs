using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{

    public int playerLevel = 1;
    public int expRequired = 20;
    public int currentExp = 0;

    public TMP_Text levelText;
    public TMP_Text expRequiredTxt;
    public TMP_Text currentExpTxt;
    public PlayerStats playerStats;

    public BanditEnemy banditExpPoints;

    void Start()
    {
        levelText.text = playerLevel.ToString();
        
        currentExpTxt.text = (currentExp.ToString() + "/" + expRequired.ToString()); 

        

    }

    
    void Update()

    {
        LevelUp();
        levelText.text = playerLevel.ToString();
    }


    public void GainExp()
    {
 
        currentExp += banditExpPoints.banditExp;
        currentExpTxt.text = (currentExp.ToString() + "/" + expRequired.ToString()); 
    }

    public void LevelUp()
    {

        if (currentExp >= expRequired  && playerLevel == 1)
        {
            playerLevel++;
            expRequired = 120;
            currentExpTxt.text = (currentExp.ToString() + "/" + expRequired.ToString()); 
            playerStats.playerStrength += 2;
            playerStats.maxHealth += 20;
            playerStats.currentHealth = playerStats.maxHealth;
            FindObjectOfType<AudioManager>().Play("LevelUp");
        }

        if (currentExp >= expRequired && playerLevel == 2)
        {
            playerLevel++;
            expRequired = 420;
            currentExpTxt.text = (currentExp.ToString() + "/" + expRequired.ToString()); 
            playerStats.playerStrength += 3;
            playerStats.maxHealth += 25;
            playerStats.currentHealth = playerStats.maxHealth;
            FindObjectOfType<AudioManager>().Play("LevelUp");

        }    

        if (currentExp >= expRequired && playerLevel == 3)
        {
            playerLevel++;
            expRequired = 1000;
            currentExpTxt.text = (currentExp.ToString() + "/" + expRequired.ToString()); 
            playerStats.playerStrength += 5;
            playerStats.maxHealth += 30;
            playerStats.currentHealth = playerStats.maxHealth;
            FindObjectOfType<AudioManager>().Play("LevelUp");

        }    

    }


}
