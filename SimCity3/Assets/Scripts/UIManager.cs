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

   //------ส่วนที่เพิ่มเข้ามา---------
    public TextMeshProUGUI dateText;
    public TimeManager timeManager;
   //-------------------------//

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

        //----- ส่วนที่เพิ่มเข้ามา-----
        if(timeManager !=null && dateText != null)
        {
            dateText.text = "Date: "+ timeManager.GetDateString();
        }
        //-------------//
       
    }
}
