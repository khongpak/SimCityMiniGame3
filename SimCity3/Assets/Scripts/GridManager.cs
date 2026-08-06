using UnityEngine;

public class GridManager : MonoBehaviour
{
    /* TODO
    1. ประกาศตัวแปร width,height, cellSize, boxPrefab, cursorPrefab
    2. ประกาศตัวแปร gridArrayBG, gridArrayData, gridOffset,  cursorInstance
    2. ประกาศตัวแปร eventBus OnBuildingPlaced
    3. สร้างส่วนของ [Header("Building Setting)] แล้วสร้าง 2 ตัวแปรนี้ให้อยู่ภายใต้หัวข้อนี้
        4. ประกาศตัวแปร availableBuilding เป็นแบบ Array ประเภท BuildingData
        5. ประกาศตัวแปร int selectedBuildingIndex
    */
    
  

    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArrayBG
        2.กำหนดค่า gridArrayData
        3.กำหนดค่า gridOffset
        4.เรียกฟังก์ชัน CreateGrid
        5.เช็ค cursorPrefab และ ปิดการทำงานของ cursorInstance
        */

        

    }

    void Update()
    {
        /* TODO
            1. เรียกใช้ MouseHighlightCursor
            2. เรียกใช้ CheckMouseClick
        */  



    }

    private void CreateGrid()
    {
        /*TODO
        1.กำหนดค่า gridOffsetBG
        2.สร้างตาราง
            3.สร้าง spawnboxPoint
            4.สร้าง visualBox
            5.ใส่ค่า visualBox ใน gridArray
            6.สร้าง textComponent แล้วเปลี่ยนข้อความให้แสดง ตำแหน่ง x,y ใน ช่อง
        */
        
        
    }

    private void MouseHighlightCursor()
    {
        /*TODO
        1.ตรวจสอบการมีของกล้องและcursorInstance 
        2.สร้าง mouseScreenPos เพื่ออ่านค่าตำแหน่งของเมาส์
        3.ตรวจสอบว่าค่าที่ mouscreenPos ไม่ใช่ตัวเลขรึเปล่า ถ้าไม่ใช้ให้ return ออกไปเลย
        4.เช็คไม่ให้ตำแหน่งเมาส์หลุดขอบของจอ ถ้าหลุดขอบไปแล้วให้ปิดการทำงานของ mousecursor
        5.สร้าง mousePosition เพื่อเก็บค่าจากการเปลี่ยนตำแหน่ง ScreenPoint ไปเป็น WordPoint
        6.สร้าง gridPosition เพื่อเก็บค่าที่ได้จากฟังก์ชัน GetGridPosition เป็นการแปลงตำแหน่ง gird ที่เมาส์ชี้อยู่
        7.ตรวจสอบตำแหน่ง gridPosition ว่าอยู่ในตำแหน่งที่เมาส์วางรึเปล่า เพื่อให้ เมาส์แสดงตามตำแหน่งของ grid 
        8.สร้าง cellCenter เพื่อระบุตำแหน่งตรงกลางของ grid นั้นๆ โดยไม่ต้องมี cellSize/2 เพราะเรากำหนดรูปให้เริ่มมุมซ้ายล่างแล้ว
        9.ให้เช็คว่า availableBuilding ไม่ใช่ค่าวางเปล่า และ มีสมาชิกมากกว่า 0
        10. ให้ประกาศตัวแปร currentData ประเภท BuildingData เพิ่มเก็บค่า availableBuilding[selectedBuildingIndex]
        11. ประกาศตัวแปร currentBuildingPrefab ประเภท GameObject ให้เก็บ ค่า currentData.buildingPrefab
        12. ประกาศตัวแปร cursorHighlightSprite และ buildingPrefabSprite ประเภท SpriteRenderer 
            ให้cursorHighlightSprite เก็บค่าของ cursorInstanc และ buildingPrefabSprite เก็บค่าของ currentBuildingPrefab
            ที่มี Component SpriteRenderer โดยใช้ getComponent
        13. ให้เช็คว่า cursorHighlightSprite และ buildingPrefabSprite ไม่ใช่ค่าว่าง
        14. กำหนดให้ cursorHighlightSprte.sprite = buildingPrefabSprite.sprte
        15. ประกาศตัวแปร resourceManager ประเภท ResourceManager ให้ FindFirstObjectByType<> 
        16. ประกาศตัวแปร canPlaceBuilding ประเภท bool เพื่อเก็บค่าที่ได้จากการเรียก เมธอด IsValidPosition(gridPosition,currdentData.buildingsize)
            กับเช็คว่า (resourceManager !=null และ resourceManager.gold มีค่ามากกว่าหรือเท่ากับ currentData.cost) 
        17. เช็คว่า canPlaceBuilding เป็นจริงรึเปล่า ถ้าเป็นจริง ให้กำหนด cursorHighlightSprite.color = new color(0.5f,1f,0.5f,0.5f)
            แต่ถ้าไม่จริง ให้กำหนด cursorHighlightSprite.color = new color(1f,0.5f,0.5f,0.5f)
        18. ถ้าไม่เป็นไปตามเงื่อนไขในข้อ 9 ให้ cursorInstance.SetActive(false)
        */

        

    }


    private Vector2Int GetGridPosition(Vector3 WorldPosition)
    {
        /*
        1. ประกาศตัวแปร x เพื่อแปลงค่า x จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        2. ประกาศตัวแปร y เพื่อแปลงค่า y จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        3. คืนค่า x,y แบบ Vector2Int
        */     
      
        return new Vector2Int(0,0);

    }

    
    private bool IsValidPosition(Vector2Int startPos, Vector2Int size)
    {
        /*TODO
            1. ทำการวนloop (x,y) ตามขนาดของ size ที่ส่งเข้ามา
            2. ประกาศตัวแปร currentX เพื่อเก็บค่า startPos.x + x
            3. ประกาศตัวแปร currentY เพื่อเก็บค่า startPos.y + y
            4. ตรวจสอบว่า currentX และ currentY หลุดขอบกริดรึเปล่า ถ้าหลุดให้ return ค่า false
            5. ตรวจสอบว่า gridArrayData[currentX, currentY] วางรึเปล่า ถ้าไม่ว่างให้ return ค่า false
            6. ถ้าเช็คใน loop หมดแล้วว่าไม่มีค่า false ก็ให้ return ค่า true
        */
        
        
        return true;
    }
    
    private void CreateBuilding(Vector2Int pos)
    {
        /*TODO
        1. ประกาศตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
        2. ประกาศตัวแปร resourceManager ประเภท ResourceManager แล้วให้เก็บค่าจาก Object แรกที่มีComponent ResourceManager 
            โดยใช้ FindFirstObject
        3. ตรวจสอบว่า resourceManager ไม่ได้เป็นค่าว่าง และ เงินที่อยู่ใน resourceManager มีค่ามากกว่าหรือเท่ากับ currentData.cost
        4. ประกาศตัวแปร worldPosition เพื่อให้วัตถุที่จะวางลงอยู่ตรงกลางช่อง gridพอดี(ไม่ต้องเพิ่ม cellsize/2)
        5. สร้าง Object ขึ้นมาโดยให้เก็บไว้ที่ตัวแปร newBuilding และ Object ที่สร้างมาก็ต้องอยู่ในตำแหน่ง worldPosition
        6. ตรวจสอบว่า newBuilding มี Component building อยู่ในตัวมันรึเปล่า โดยใช้ TryGetComponent ถ้ามีให้ประกาศตัวแปร b ประเภท 
            building ขึ้นมาเพื่อทำการเชื่อมกับ component building ที่อยู่ใน newBuilding 
        7. จากนั้นกำหนดค่า incomePerTick ที่อยู่ใน newBuilding ให้เท่ากับ currentData.incomePertick
        8. จากนั้นกำหนดค่า constructionCost ที่อยู่ใน newBuilding ให้เท่ากับ currentData.cost
        8. สร้าง loop ขึ้นมาตามขนาดของ buildingsize แล้วบันทึกค่าลงใน gridArrayData[pos.x+x,pos.y+y]
        8. หลังจากบันทึกในลูปเสร็จแล้ว ก็ประกาศ onBuildingPlace ออกไปพร้อมส่งค่า currentData.cost นอกลูป
        10. ถ้าจากข้อที่ 3 เป็นเท็จให้ Debug ค่าออกมาว่า "เงินไม่พอสร้าง" ตามด้วยชื่อของสิ่งที่จะสร้าง
        */
        
        

    }

    public void SelectBuilding(int index)
    {
        /*TODO กำหนดให้ตัวแปร selectedBuildingIndex มีค่าเท่ากับ index*/
        
    }

    private void CheckMouseClick()
    {
        /*TODO
            1. ตรวจเช็คว่าเมาส์ทำงานรึเปล่า
            2. สร้างตัวแปร isLeftPressed เป็นแบบ bool เพื่อเก็บค่า ว่าเมาส์ทางซ้ายว่าได้กดรึเปล่า
            3. สร้างตัวแปร isRightPressed เป็นแบบ bool เพื่อเก็บค่า ว่าเมาส์ทางขวาได้กดรึเปล่า
            4. ถ้า isLeftPressed และ isRightPressed ไม่ได้กด ให้ return
            5. สร้าง mouseScreenPos เพื่อขึ้นมารับค่าการอ่านตำแหน่งของเมาส์ผ่าน Screen
            6. ตรวจเช็คว่าค่า mouseScreePos.x กับ mouseScreenPos.y ได้ส่งค่าที่ไม่ใช่ตัวเลขมารึเปล่า ถ้าใช่ให้ returnออกไปเลย
            7. เช็คว่ากล้องยังมีอยู่ไม่ได้หายไปไหน
            8. สร้าง MousePosition พร้อมเปลี่ยนค่าตำแหน่งMouse จาก ScreenPoint ไปเป็น WorldPoint
            9. สร้าง gridPosition ขึ้นมาเพื่อเก็บค่าตำแหน่ง grid ที่เมาส์ชี้อยู่ โดยเรียก GetGridPositon
            10. เช็คว่าถ้า isLeftPress เป็นจริง 
            11. ประกาศตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
            12. เรียก IsValidPosition โดยส่งค่า gridPosion กับ currentdata.buildingsize เพื่อเช็คว่า ตำแหน่งนั้นสามารถวางObjectได้ไหม
            13. ทำการวาง Object ในตำหน่ง gridPositionนั้น
            14. เช็คว่าถ้า isRightPress เป็นจริง
            15. เช็คว่า girdPosition ยังอยู่ในกริดรึเปล่า ถ้าอยู่ในกริด ก็ให้เรียกเมธอด DemolishBuilding(gridPosition)
        */ 
        
     
    }


    void DemolishBuilding(Vector2Int pos)
    {
        /*TODO LIST
          1. ตรวจสอบว่า gridArrayData[pos.x,pos.y] เป็นค่าว่างรึเปล่า ถ้าเป็นค่าว่างให้ return ออกไปเลย
          2. ประกาศตัวแปร buildingToDestroy ประเภท GameObject ขึ้นมาเพิ่มเก็บObjectที่อยู่ใน gridArrayData[pos.x,pos.y]
          3. ประกาศตัวแปร refundAmount = 0
          4. เช็คว่า buildingToDestory มีสคลิป Building อยู่รึเปล่า โดยใช้ TryGetComponent ถ้ามีให้ ประกาศตัวแปร b ขึ้นมาเก้บค่าไว้
          5. กำหนดให้ refundAmount มีค่าเท่ากับ b.constructionCost ÷ 2
          6. ประกาศตัวแปร resourceManager ขึ้นมาจากนั้นก็อ้างอิงObjectที่แนบสคลิป ResourceManager โดยใช้ FindFirstObjectByType
          7. เช็คว่า resourceManager ไม่ใช่ค่าว่างเปล่า
          8. ให้ resourceManager เรียกเมธอด RefundGold(refundAmount)
          9. สร้างลูป x,y ขึ้นมาโดยให้ x < width และ y < height จากนั้นก็ทำการเช็ค gridArrayData[x,y] ว่ามีObject buildingToDestroy
             อยู่รึเปล่า ถ้ามีให้ gridArrayData[x,y] นั้น มีค่าเท่ากับ null
          10. จากนั้นก็ทำการทำลาย Destory(buildingToDestory)
          11. Debug.Log($"ทุบตึกเรียบร้อย ได้คืน {refundAmount} Gold");    
  
        */

        

    }

}