using UnityEngine;

public class Building : MonoBehaviour
{
    /* TODO
        ประกาศตัวแปร 
        1.incomePerTick 
        2.resourceManager
        3.constructionCost แบบ [HideInInspector]
    */  
    public int incomePerTick = 2;
    private ResourceManager resourceManager;
    [HideInInspector]public int constructionCost;
   

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
        resourceManager.AddGold(incomePerTick);
       
    }
}
