using UnityEngine;

public class Building : MonoBehaviour
{
    /* TODO
    ประกาศตัวแปร incomePerTick และ ตัวแปร resourceManager สำหรับเก็บค่า Object ResourceManager
    */
    public int incomePerTick = 5;
    private ResourceManager resourceManager;

    //เพิ่มเข้ามา//
    [HideInInspector] public int constructionCost;

  

    void Start()
    {
        /*TODO
        กำหนดค่า resourceManager ให้ไปค้นหา Object แรกที่มีสคลิป ResourceManager โดยใช้ method 
        FindFirstObjectByType
        */
        resourceManager = FindFirstObjectByType<ResourceManager>();

    }

    /*TODO
    สร้าง OnEnble และ OnDisable เพื่อรับสมัคร OnDayPassed หรือ OnMonthPassed 
    จาก TimeManager เพื่อสั่งให้ ProduceResources ทำงาน
    */
    void OnEnable()
    {
        TimeManager.OnDayPassed += ProduceResources;
    }

    void OnDisable()
    {
        TimeManager.OnDayPassed -= ProduceResources;
    }

    void ProduceResources()
    {
        /*TODO
        ทำการเช็ค resourceManager ว่าไม่ใช่ค่า null 
        แล้วให้ resouceManager เรียก method AddGold แล้วส่งค่า incomePerTick ออกไป
        */
        if(resourceManager != null)
        {
            resourceManager.AddGold(incomePerTick);
        }
       
    }
}
