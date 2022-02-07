using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    
[SerializeField] int goldCount = 0;

public TMP_Text goldInventoryText;
public TMP_Text goldInvMerchantText;



void Update() 

{
    
    goldInventoryText.text = goldCount.ToString();
    goldInvMerchantText.text = goldCount.ToString();


}





}
