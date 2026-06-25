using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /*TODO
    ประกาศตัวแปร moneyText เป็นแบบ TextMeshProUGUI
    ประกาศตัวแปร resourceManager
    */
    public TextMeshProUGUI moneyText;
    public ResourceManager resourceManager;



    void Update()
    {
        /*TODO
        เช็คตัวแปร resourceManager และ moneyText ไม่ใช่ค่าว่าง
        ให้ moneyText แสดงค่า "Gold: "
        */
        if(resourceManager != null && moneyText != null)
        {
            moneyText.text = "Gold :" + resourceManager.gold.ToString();
        }

       
    }
}
