using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    
[SerializeField] public int goldCount = 12;
[SerializeField] public int potionCount = 0;

public bool hasDualBlade = false;

public TMP_Text goldInventoryText;
public TMP_Text goldInvMerchantText;
public TMP_Text potionCountText;



void Update() 

{
    
    goldInventoryText.text = goldCount.ToString();
    goldInvMerchantText.text = goldCount.ToString();
    potionCountText.text = potionCount.ToString();


}





}
