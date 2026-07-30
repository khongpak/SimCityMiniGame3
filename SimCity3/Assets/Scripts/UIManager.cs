using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /*TODO
    1. ประกาศตัวแปร moneyText เป็นแบบ TextMeshProUGUI
    2. ประกาศตัวแปร dateText เป็นแบบ TextMeshProUGUI
    3. ประกาศตัวแปร resourceManager เป็นแบบ ResourceManager
    4. ประกาศตัวแปร timeManager เป็นแบบ TimeManager
    5. ในเมธอด Start()
        5.1 ให้ resourceManager ใช้ FindFirstObjectByType<>()
        5.2 ให้ timeManager ใช้ FindFirstObjectByType<>()
    6. ในเมธอด Update()
        6.1. เช็คตัวแปร resourceManager และ moneyText ไม่ใช่ค่าว่าง ให้ moneyText แสดงค่า "Gold: "
        6.2. เช็คตัวแปร timeManager และ dateText ไม่ใช่ค่าว่าง ให้ dataText แสดงค่า "Date :"

    */

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI dateText;
    private ResourceManager resourceManager;
    private TimeManager timeManager;

    void Start()
    {
        resourceManager = FindFirstObjectByType<ResourceManager>();
        timeManager = FindFirstObjectByType<TimeManager>();
    }

    void Update()
    {
        if(resourceManager != null && moneyText != null)
        {
            moneyText.text = "Gold :"+resourceManager.gold.ToString();
        }

        if(timeManager != null & dateText != null)
        {
            dateText.text = timeManager.GetDataString();
        }
    }

}
