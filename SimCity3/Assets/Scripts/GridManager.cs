using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

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
        2.ตรวจสอบว่า EventSystem ทำงานอยู่รึเปล่า และ EventSystem IsPointerOverGameObject รึเปล่า ถ้าใช่ 
            ก็ให้ตั้งค่า cursorInstance เป็น false และ return ค่าออกไป
        3.สร้าง mouseScreenPos เพื่ออ่านค่าตำแหน่งของเมาส์
        4.ตรวจสอบว่าค่าที่ mouscreenPos ไม่ใช่ตัวเลขรึเปล่า ถ้าไม่ใช้ให้ return ออกไปเลย
        5.เช็คไม่ให้ตำแหน่งเมาส์หลุดขอบของจอ ถ้าหลุดขอบไปแล้วให้ปิดการทำงานของ mousecursor
        6.สร้าง mousePosition เพื่อเก็บค่าจากการเปลี่ยนตำแหน่ง ScreenPoint ไปเป็น WordPoint
        7.สร้าง gridPosition เพื่อเก็บค่าที่ได้จากฟังก์ชัน GetGridPosition เป็นการแปลงตำแหน่ง gird ที่เมาส์ชี้อยู่
        8.ตรวจสอบตำแหน่ง gridPosition ว่าอยู่ในตำแหน่งที่เมาส์วางรึเปล่า เพื่อให้ เมาส์แสดงตามตำแหน่งของ grid 
        9.สร้าง cellCenter เพื่อระบุตำแหน่งตรงกลางของ grid นั้นๆ โดยไม่ต้องมี cellSize/2 เพราะเรากำหนดรูปให้เริ่มมุมซ้ายล่างแล้ว
        10.ให้เช็คว่า availableBuilding ไม่ใช่ค่าวางเปล่า และ มีสมาชิกมากกว่า 0
        11. ให้ประกาศตัวแปร currentData ประเภท BuildingData เพิ่มเก็บค่า availableBuilding[selectedBuildingIndex]
        12. ประกาศตัวแปร currentBuildingPrefab ประเภท GameObject ให้เก็บ ค่า currentData.buildingPrefab
        13. ประกาศตัวแปร cursorHighlightSprite และ buildingPrefabSprite ประเภท SpriteRenderer 
            ให้cursorHighlightSprite เก็บค่าของ cursorInstanc และ buildingPrefabSprite เก็บค่าของ currentBuildingPrefab
            ที่มี Component SpriteRenderer โดยใช้ getComponent
        14. ให้เช็คว่า cursorHighlightSprite และ buildingPrefabSprite ไม่ใช่ค่าว่าง
        15. กำหนดให้ cursorHighlightSprte.sprite = buildingPrefabSprite.sprte
        16. ประกาศตัวแปร resourceManager ประเภท ResourceManager ให้ FindFirstObjectByType<> 
        17. ประกาศตัวแปร canPlaceBuilding ประเภท bool เพื่อเก็บค่าที่ได้จากการเรียก เมธอด IsValidPosition(gridPosition,currdentData.buildingsize)
            กับเช็คว่า (resourceManager !=null และ resourceManager.gold มีค่ามากกว่าหรือเท่ากับ currentData.cost) 
        18. เช็คว่า canPlaceBuilding เป็นจริงรึเปล่า ถ้าเป็นจริง ให้กำหนด cursorHighlightSprite.color = new color(0.5f,1f,0.5f,0.5f)
            แต่ถ้าไม่จริง ให้กำหนด cursorHighlightSprite.color = new color(1f,0.5f,0.5f,0.5f)
        19. ถ้าไม่เป็นไปตามเงื่อนไขในข้อ 9 ให้ cursorInstance.SetActive(false)
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
            5. ตรวจสอบว่า EventSystem ทำงานอยู่รึเปล่า และ EventSystem IsPointerOverGameObject รึเปล่า ถ้าใช่
                ให้ return 
            6. สร้าง mouseScreenPos เพื่อขึ้นมารับค่าการอ่านตำแหน่งของเมาส์ผ่าน Screen
            7. ตรวจเช็คว่าค่า mouseScreePos.x กับ mouseScreenPos.y ได้ส่งค่าที่ไม่ใช่ตัวเลขมารึเปล่า ถ้าใช่ให้ returnออกไปเลย
            8. เช็คว่ากล้องยังมีอยู่ไม่ได้หายไปไหน
            9. สร้าง MousePosition พร้อมเปลี่ยนค่าตำแหน่งMouse จาก ScreenPoint ไปเป็น WorldPoint
            10. สร้าง gridPosition ขึ้นมาเพื่อเก็บค่าตำแหน่ง grid ที่เมาส์ชี้อยู่ โดยเรียก GetGridPositon
            11. เช็คว่าถ้า isLeftPress เป็นจริง 
            12. ประกาศตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
            13. เรียก IsValidPosition โดยส่งค่า gridPosion กับ currentdata.buildingsize เพื่อเช็คว่า ตำแหน่งนั้นสามารถวางObjectได้ไหม
            14. ทำการวาง Object ในตำหน่ง gridPositionนั้น
            15. เช็คว่าถ้า isRightPress เป็นจริง
            16. เช็คว่า girdPosition ยังอยู่ในกริดรึเปล่า ถ้าอยู่ในกริด ก็ให้เรียกเมธอด DemolishBuilding(gridPosition)
        */ 
        
     
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
        7. จากนั้นเรียก building.Setup ขึ้นมา เพื่อทำการส่งค่า โดยค่าที่ต้องส่งจะมีตามนี้ 
            7.1 currentData.incomePerTick อันนี้จะไปเชื่อมกับตัวแปร income ใน class building
            7.2 currentData.cost อันนี้จะไปเชื่อมกับตัวแปร cost ใน class building
            7.3 pos อันนี้จะไปเชื่อมกับตัวแปร pos ใน class building
            7.4 currentData.buildingSize อันนี้จะไปเชื่อมกับตัวแปร size ใน class building
            7.5 this(ก็คือการชี้กลับมาที่ตัวเอง) อันนี้ไปเชื่อมกับตัวแปร gm ใน class building
        8. สร้าง loop ขึ้นมาตามขนาดของ buildingsize แล้วบันทึกค่าลงใน gridArrayData[pos.x+x,pos.y+y]
        9. หลังจากบันทึกในลูปเสร็จแล้ว ก็ประกาศ onBuildingPlace ออกไปพร้อมส่งค่า currentData.cost นอกลูป
        10. แจ้งตึกโดยรอบให้เช็คสถานะถนน NotifyNeighbors(pos, currentData.buildingSize)
        11. ถ้าจากข้อที่ 3 เป็นเท็จให้ Debug ค่าออกมาว่า "เงินไม่พอสร้าง" ตามด้วยชื่อของสิ่งที่จะสร้าง
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
            9. กำหนดค่าตัวแปร minPox(Vector2Int) ให้เก็บค่า width,height อย่าลืม new Vector2Int
            10. กำหนดค่าตัวแปร maxPos(Vector2Int) ให้เก็บค่า -1,-1 อย่าลืม new Vector2Int 
                    ที่กำหนดค่า minPox เป็นค่าสูงสุด และ ค่า maxPos เป็นค่าต่ำสุด(ติดลบ) 
                    เพราะเวลาเข้าลูปแล้วมันจะค่อยๆลดค่าลงไปเรื่อยๆ จนเจอตำแหน่ง
            11. สร้างลูป x,y ขึ้นมาโดยให้ x < width และ y < height จากนั้นก็ทำการเช็ค gridArrayData[x,y] ว่ามีObject buildingToDestroy
                อยู่รึเปล่า ถ้ามีให้ gridArrayData[x,y] นั้น มีค่าเท่ากับ null
            12. จากนั้นกำหนด ค่า minPos.x , minPos.y, maxPos.x, maxPos.x เพื่อให้รู้ขนาดของตึกว่ามีตำแหน่งเริ่มต้นจากพิกัดไหน ไปจนถึงพิกัดไหน
                12.1 โดยมีเงื่อนไขว่า ถ้า x < minPos.x ให้ minPos.x มีค่าเท่ากับ x
                12.2 โดยมีเงื่อนไขว่า ถ้า y < minPos.y ให้ minPos.y มีค่าเท่ากับ y
                12.3 โดยมีเงื่อนไขว่า ถ้า x > maxPos.x ให้ maxPos.x มีค่าเท่ากับ x
                12.4 โดยมีเงื่อนไขว่า ถ้า y > maxPos.y ให้ maxPos.y มีค่าเท่ากับ y
            13. จากนั้นก็ทำการทำลาย Destory(buildingToDestory)
            14. Debug.Log($"ทุบตึกเรียบร้อย ได้คืน {refundAmount} Gold");
            15. แจ้งเตือนอาคารรอบข้างที่อยู่ติดกับสิ่งก่อสร้างนี้ โดยทำการเช็คก่อนว่า maxPos.x >= 0 และ maxPos.y >=0
                15.1 จากนั้นก็กำหนดตัวแปร size(vector2int) ให้มีค่าเท่ากับ maxPos.x - minPos.x + 1, maxPos.y - minPos.y + 1
                15.2 จากนั้นเรียก method NotifyNeighbors(minPos,size) เพื่อแจ้งเตือนตึกรอบๆ     
  
        */
        
        

    }

    public GameObject GetBuildingAt(Vector2Int pos)
    {
        /*TODO LIST (เมธอดนี้เอาไว้บอกว่าในตำแหน่งที่ส่งเข้ามานั้นมีสิ่งใดอยู่)
            1. เช็คว่า pos.x(ตำแหน่งที่ส่งเข้ามา) มีค่ามากกว่าหรือเท่ากับ 0 และ pos.x มีค่าน้อยกว่า width และ pos.y มีค่ามากกว่า
                หรือเท่ากับ 0 และ pos.y มีค่าน้อยกว่า height 
            2. ถ้าเงื่อนไขเป็นจริงให้ส่ง object ที่อยู่ ใน gridArrayData[pos.x, pos.y] ออกไป
            3. จากนั้นก็ return ค่า null ออกไป
        */
        
        return null;
    }

    private void NotifyNeighbors(Vector2Int startPos, Vector2Int size)
    {
        /*TODO LIST (ฟังก์ชันกระจายการแจ้งเตือนไปยังตึกโดยรอบเพื่ออัปเดตการเชื่อมต่อถนน)
            1. ทำการเข้าลูป โดยกำหนดให้ค่า x มีค่าเท่ากับ -1 เพื่อเริ่มเช็คตั้งแต่นอกขอบเลย ถ้า x น้อยกว่าหรือเท่ากับ ค่า size.x ที่ส่งเข้ามา
                ให้เพิ่มค่า x
            2. จากนั้นก็เข้าลูปซ้อน โดยกำหนดให้ค่า y มีค่าเท่ากับ -1 ถ้าค่า y น้อยกว่าหรือเท่ากับ ค่า size.y ให้เพิ่มค่า y
            3. สร้างตัวแปร isOutSide(bool) โดยเช็คว่าตำแหน่งเหล่านั้นอยู่นอกขอบตึกรึเปล่า โดยให้มีค่าเท่ากับ
                เมื่อ x มีค่าเท่ากับ -1 หรือ x มีค่าเท่ากับ size.x หรือ y มีค่าเท่ากับ -1 หรือ y มีค่าเท่ากับ size.y
            4. ถ้าค่า isOutside เป็นจริง
                4.1 กำหนดค่า checkPos(vector2int) มีค่าเท่าก startPos.x + x, startPos.y +y อย่าลืม new Vector2int ด้วย
                4.2 กำหนดค่า obj(GameObject) ให้มีค่าเท่ากับค่าที่ GetBuildingAt(checkPos) ส่งกลับมา
                4.3 ถ้า Obj ไม่ใช่ค่าว่าง และ obj มีคลาส Building อยู่ ก็ให้สร้างตัวแปร b(building)ขึ้นมา โดยใช้ TryGetComponent
                    4.3.1 แล้วก็ให้ b เรียก CheckRoadConnection() ขึ้นมา [b.CheckRoadConnection();]
        */
        
        
    }

}