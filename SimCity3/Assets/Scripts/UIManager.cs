using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public TextMeshProUGUI moneyText;
   public ResourceManager resourceManager;

    void Update()
    {
        if(resourceManager != null && moneyText != null)
        {
            moneyText.text = "Gold: " + resourceManager.gold.ToString();
        }
    }
}
