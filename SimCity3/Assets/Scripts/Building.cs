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
    [HideInInspector]public int constructionCost;

    private ResourceManager resourceManager;
    private GridManager gridManager;
    private Vector2Int myGridPos;
    private Vector2Int myBuildingSize = Vector2Int.one;

    [Header("Statud")]
    public bool isConnectedToRoad = false;

    // ฟังก์ชัน Setup สำหรับกำหนดค่าเริ่มต้นเมื่อถูกสร้างขึ้นมา
    public void Setup(int income, int cost, Vector2Int pos, Vector2Int size, GridManager gm)
    {
        incomePerTick = income;
        constructionCost = cost;
        myGridPos = pos;
        myBuildingSize = size;
        gridManager = gm;
        resourceManager = FindFirstObjectByType<ResourceManager>();

        CheckRoadConnection();
    }

    // ฟังก์ชันตรวจสอบถนนที่อยู่รอบๆ ขอบของตึก (รองรับทั้งตึก 1x1 และตึกขนาดใหญ่)
    public void CheckRoadConnection()
    {
        if (gridManager == null) return;

        isConnectedToRoad = false;

        // วนลูปตรวจสอบพื้นที่รอบๆ ขอบตึกทุกทิศทาง
        for (int x = -1; x <= myBuildingSize.x; x++)
        {
            for (int y = -1; y <= myBuildingSize.y; y++)
            {
                // ตรวจสอบเฉพาะช่องที่เป็นขอบภายนอกตึกเท่านั้น
                bool isOutside = (x == -1 || x == myBuildingSize.x || y == -1 || y == myBuildingSize.y);
                // ไม่เช็คช่องที่เป็นแนวทแยงมุม
                bool isCorner = (x == -1 || x == myBuildingSize.x) && (y == -1 || y == myBuildingSize.y);

                if (isOutside && !isCorner)
                {
                    Vector2Int checkPos = new Vector2Int(myGridPos.x + x, myGridPos.y + y);
                    GameObject neighborObj = gridManager.GetBuildingAt(checkPos);

                    if (neighborObj != null && neighborObj.name.Contains("Road"))
                    {
                        isConnectedToRoad = true;
                        return; // พบถนนติดอยู่แล้ว ออกจากลูปได้ทันที
                    }
                }
            }
        }
    }
    
    void Start()
    {
        /*TODO
        กำหนดค่า resourceManager ให้ไปค้นหา Object แรกที่มีสคลิป ResourceManager โดยใช้ method 
        FindFirstObjectByType
        */
        if(resourceManager == null)
        {
            resourceManager = FindFirstObjectByType<ResourceManager>();
        }

                
    }

    /*TODO
    สร้าง OnEnble และ OnDisable เพื่อรับสมัคร OnDayPassed หรือ OnMonthPassed 
    จาก TimeManager เพื่อสั่งให้ ProduceResources ทำงาน
    */

    void OnEnable()
    {
        TimeManager.OndayPass += ProduceResources;
    }

    void OnDisable()
    {
        TimeManager.OndayPass -= ProduceResources;
    }

    void ProduceResources()
    {
        /*TODO
        ทำการเช็ค resourceManager ว่าไม่ใช่ค่า null 
        แล้วให้ resouceManager เรียก method AddGold แล้วส่งค่า incomePerTick ออกไป
        */       
        // หากไม่ได้ติดถนนจะไม่ผลิตเงิน
        if (!isConnectedToRoad) return;

        if (resourceManager != null)
        {
            resourceManager.AddGold(incomePerTick);
        }
    }
}
