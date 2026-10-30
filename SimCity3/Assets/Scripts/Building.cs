using UnityEngine;

public class Building : MonoBehaviour
{
    /* TODO
        ประกาศตัวแปร 
        1.incomePerTick 
        2.resourceManager
        3.constructionCost แบบ [HideInInspector]
        4.gridManager เป็น GridManager เพื่อเอามาใช้ตอนเรียก method Setup 
        5.myGridPos เป็น Vector2Int เพื่อเอามาใช้ตอนเรียก method Setup 
        6.myBuildingSize เป็น vector2int ให้ค่าเริ่มต้นเป็น Vector2Int.one เพื่อเอามาใช้ตอนเรียก method Setup 
        7.isConnectedToRoad เป็นแบบ bool กำหนดค่าเริ่มต้นเป็น false; เอาไว้ใช้ในเมธอด CheckRoadConnection
    */  
  
    
    public void Setup(int income, int cost, Vector2Int pos, Vector2Int size, GridManager gm)
    {
        /*  TODO
        1.สร้างเมธอด Setup ขึ้นมา โดยมีการรับค่า income(int),cost(int),pos(vector2int),size(vetor2int),gm(gridmanager)
        2. กำหนดค่าให้ incomePerTick = income, constructionCost = cost, myGridPos = pos, myBuildingSize = size,
            gridManager = gm , resourceManager ให้ไปค้นค่าโดยใช้ FindFirstObjectByType()
        3.เรียกMethod CheckRoadConnection() 
        */
       
    }

    // ฟังก์ชันตรวจสอบถนนที่อยู่รอบๆ ขอบของตึก (รองรับทั้งตึก 1x1 และตึกขนาดใหญ่)
    public void CheckRoadConnection()
    {
        /*TODO
            1. ตรวจสอบว่าค่า gridManager เป็นค่า null รึเปล่า ถ้าใช่ ให้ return ออกไปเลย
            2. ให้ isConnectedToRoad มีค่าเป็น false
            3. เริ่มทำการวน Loop เพื่อตรวจสอบพื้นที่รอบๆ ขอบตึกทุกทิศทาง ทั้งแกน x,y โดยกำหนดค่า x = -1 และ y = -1 
                เริ่มตั้งแต่นอก ตาราง grid ถ้า x มีค่าน้อยกว่าหรือเท่ากับ myBuildingSize.x ให้ xเพิ่มค่าอีก 1 และ ถ้า y มีค่า
                น้อยกว่าหรือเท่ากับ myBuildingSize.y ให้ y เพิ่มค่าอีก 1
                3.1 กำหนดตัวแปร isOutside(bool) ขึ้นมาเพื่อเช็คว่าช่องกริดในลำดับนั้นอยู่ภายนอกสิ่งก่อสร้าง โดยมีเงือนไขจะเป็นจริงเมื่อ 
                    x มีค่าเท่ากับ -1 หรือ x มีค่าเท่ากับ myBuildingSize.x หรือ y มีค่าเท่ากับ -1 หรือ y มีค่าเท่ากับ myBuildingSize.y
                3.2 กำหนดตัวแปร isCorner(bool) ขึ้นมาเพื่อเช็คว่าช่องกริดในลำดับนั้นอยู่ตามมุมของสิ่งปลูกสร้างรึเปล่า โดยมีเงื่อนไขจะเป็นจริงเมื่อ 
                    x มีค่าเท่ากับ -1 หรือ x มีค่าเท่ากับ myBuildingSize.x และ y มีค่าเท่ากับ -1 หรือ y มีค่าเท่ากับ myBuildingSize.y
                3.3 ทำการตรวจสอบว่า isOutside เป็นจริง และ isCorner เป็นเท็จ
                3.4 กำหนดให้ checkPos(vector2Int) มีค่าเท่ากับ myGridPos.x + x, myGridPos.y + y);
                3.5 กำหนดให้ neighborObj มีค่าเท่ากับ gridManager.GetBuildingAt(checkPos) ตรวจสอบว่าตำแหน่งนั้นมีสิ่งใดอยู่
                3.6 ถ้า neighborObj ไม่ใช่ค่า null และ neighborObj.name.Contains("Road") ให้เปลี่ยน isConnectedToRoad เป็น true
                    จากนั้นก็ return ออกไปเลย
        */
        
    }
    
    void Start()
    {
        /*TODO
            1.ตรวจสอบว่า resourceManager เป็นค่า null รึเปล่า ถ้าใช่
                1.1 กำหนดค่า resourceManager ให้ไปค้นหา Object แรกที่มีสคลิป ResourceManager โดยใช้ method 
                    FindFirstObjectByType
        */
 

                
    }

    /*TODO
    สร้าง OnEnble และ OnDisable เพื่อรับสมัคร OnDayPassed หรือ OnMonthPassed 
    จาก TimeManager เพื่อสั่งให้ ProduceResources ทำงาน
    */

 

    void ProduceResources()
    {
        /*TODO
        ทำการเช็ค resourceManager ว่าไม่ใช่ค่า null 
        แล้วให้ resouceManager เรียก method AddGold แล้วส่งค่า incomePerTick ออกไป
        */       
        // หากไม่ได้ติดถนนจะไม่ผลิตเงิน
       
    }
}
