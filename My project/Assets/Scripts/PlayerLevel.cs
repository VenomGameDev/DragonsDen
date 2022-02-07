using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{

    public int playerLevel = 1;
    public int expRequired = 20;
    public int currentExp = 0;

    public TMP_Text currentExpTxt;
    public TMP_Text expRequiredTxt;
    public PlayerStats playerStats;

    public BanditEnemy banditExpPoints;

    void Start()
    {
        
        expRequiredTxt.text = expRequired.ToString();

        

    }

    
    void Update()

    {
        LevelUp();
    }


    public void GainExp()
    {
 
        currentExp += banditExpPoints.banditExp;
        currentExpTxt.text = currentExp.ToString();
    }

    public void LevelUp()
    {

        if (currentExp >= expRequired  && playerLevel == 1)
        {
            playerLevel++;
            expRequired = 120;
            expRequiredTxt.text = expRequired.ToString();
            playerStats.playerStrength += 2;
            playerStats.maxHealth += 20;
            playerStats.currentHealth = playerStats.maxHealth;
        }

        if (currentExp >= expRequired && playerLevel == 2)
        {
            playerLevel++;
            expRequired = 420;
            expRequiredTxt.text = expRequired.ToString();
            playerStats.playerStrength += 3;
            playerStats.maxHealth += 30;
            playerStats.currentHealth = playerStats.maxHealth;

        }    


    }


}
