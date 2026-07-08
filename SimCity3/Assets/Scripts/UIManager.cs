using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /*TODO
    ประกาศตัวแปร moneyText เป็นแบบ TextMeshProUGUI
    ประกาศตัวแปร dateText เป็นแบบ TextMeshProUGUI
    ประกาศตัวแปร resourceManager เป็นแบบ ResourceManager
    ประกาศตัวแปร timeManager เป็นแบบ TimeManager

    */
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dateText;
    private ResourceManager resourceManager;
    private TimeManager timeManger; 

    void Start()
    {
        resourceManager = FindFirstObjectByType<ResourceManager>();
        timeManger = FindFirstObjectByType<TimeManager>();
    }

    void Update()
    {
        /*TODO
        1.เช็คตัวแปร resourceManager และ moneyText ไม่ใช่ค่าว่าง ให้ moneyText แสดงค่า "Gold: "
        2. เช็คตัวแปร timeManager และ dateText ไม่ใช่ค่าว่าง ให้ dataText แสดงค่า "Date :"
        */

        if(resourceManager != null && moneyText != null)
        {
            moneyText.text  = "Gold: " + resourceManager.gold.ToString();

        }     

        if(timeManger != null && dateText != null)
        {
            dateText.text = timeManger.GetDateString();
        }       
       
    }
}
