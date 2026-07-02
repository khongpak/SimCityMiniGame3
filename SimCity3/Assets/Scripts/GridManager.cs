using UnityEngine;
using System;
using TMPro;
using UnityEngine.InputSystem;



public class GridManager : MonoBehaviour
{
    /* TODO
    1. ประกาศตัวแปร width,height, cellSize, boxPrefab, cursorPrefab
    2. ประกาศตัวแปร gridArrayBG, gridOffset, gridArrayData, cursorInstance
    2. ประกาศตัวแปร eventBus OnBuildingPlaced
    3. สร้างส่วนของ [Header("Building Setting)] แล้วสร้าง 2 ตัวแปรนี้ให้อยู่ภายใต้หัวข้อนี้
        4. สร้างตัวแปร availableBuilding เป็นแบบ Array ประเภท BuildingData
        5. สร้างตัวแปร int selectedBuildingIndex
    */


    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArrayBG
        2.กำหนดค่า gridOffset
        3.เรียกฟังก์ชัน CreateGrid
        4.เช็ค cursorPrefab และ ปิดการทำงานของ cursorInstance
        5.กำหนดค่า gridArrayData
        */
       
        
    }

    void Update()
    {
        /* TODO
            1. เรียกใช้ Mousecursor
            2. เรียกใช้ PlaceObject
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

    private void Mousecursor()
    {
        /*TODO
        1.ตรวจสอบการมีของกล้องและcursorInstance 
        2.สร้าง mouseScreenPos เพื่ออ่านค่าตำแหน่งของเมาส์
        3.เช็คไม่ให้ตำแหน่งเมาส์หลุดขอบของจอ ถ้าหลุดขอบไปแล้วให้ปิดการทำงานของ mousecursor
        4.สร้าง mousePosition เพื่อเก็บค่าจากการเปลี่ยนตำแหน่ง ScreenPoint ไปเป็น WordPoint
        5.สร้าง gridPosition เพื่อเก็บค่าที่ได้จากฟังก์ชัน GetGridPosition เป็นการแปลงตำแหน่ง gird ที่เมาส์ชี้อยู่
        6.ตรวจสอบตำแหน่ง gridPosition ว่าอยู่ในตำแหน่งที่เมาส์วางรึเปล่า เพื่อให้ เมาส์แสดงตามตำแหน่งของ grid 
        7.สร้าง cellCenter เพื่อระบุตำแหน่งตรงกลางของ grid นั้นๆ 
        */
        
    }


    private Vector2Int GetGridPosition(Vector3 WorldPosition)
    {
        /*
        1. สร้างตัวแปร x เพื่อแปลงค่า x จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        2. สร้างตัวแปร y เพื่อแปลงค่า y จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        3. คืนค่า x,y แบบ Vector2Int
        */

        return new Vector2Int(0,0);
    }

    private void PlaceObject()
    {
        /*TODO
            1. ตรวจเช็คว่าเมาส์ยังทำงานอยู่รึเปล่า พร้อมกับเช็คว่าเมาส์มีการคลิกซ้ายรึยัง
            2. สร้าง mouseScreenPos เพื่อขึ้นมารับค่าการอ่านตำแหน่งของเมาส์ผ่าน Screen
            3. ตรวจเช็คว่าค่า mouseScreePos.x กับ mouseScreenPos.y ได้ส่งค่าที่ไม่ใช่ตัวเลขมารึเปล่า ถ้าใช่ให้ returnออกไปเลย
            4. เช็คว่ากล้องยังมีอยู่ไม่ได้หายไปไหน
            5. สร้าง MousePosition พร้อมเปลี่ยนค่าตำแหน่งMouse จาก ScreenPoint ไปเป็น WorldPoint
            6. สร้าง gridPosition ขึ้นมาเพื่อเก็บค่าตำแหน่ง grid ที่เมาส์ชี้อยู่ โดยเรียก GetGridPositon
            7. สร้างตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
            8. เรียก IsValidPosition โดยส่งค่า gridPosion กับ currentdata.buildingsize เพื่อเช็คว่า ตำแหน่งนั้นสามารถวางObjectได้ไหม
            9. ทำการวาง Object ในตำหน่ง gridPositionนั้น
        */ 

        

    }

    private bool IsValidPosition(Vector2Int startPos, Vector2Int size)
    {
        /*TODO
            1. ทำการวนloop (x,y) ตามขนาดของ size ที่ส่งเข้ามา
            2. สร้างตัวแปร currentX เพื่อเก็บค่า startPos.x + x
            3. สร้างตัวแปร currentY เพื่อเก็บค่า startPos.y + y
            4. ตรวจสอบว่า currentX และ currentY หลุดขอบกริดรึเปล่า ถ้าหลุดให้ return ค่า false
            5. ตรวจสอบว่า gridArrayData[currentX, currentY] วางรึเปล่า ถ้าไม่ว่างให้ return ค่า false
            6. ถ้าเช็คใน loop หมดแล้วว่าไม่มีค่า false ก็ให้ return ค่า true
        */

        return true;
    }
    
    private void CreateBuilding(Vector2Int pos)
    {
        /*TODO
        1. สร้างตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
        2. สร้างตัวแปร resourceManager ประเภท ResourceManager แล้วให้เก็บค่าจาก Object แรกที่มีComponent ResourceManager 
            โดยใช้ FindFirstObject
        3. ตรวจสอบว่า resourceManager ไม่ได้เป็นค่าว่าง และ เงินที่อยู่ใน resourceManager มีค่ามากกว่าหรือเท่ากับ currentData.cost
        4. สร้างตัวแปร worldPosition เพื่อให้วัตถุที่จะวางลงอยู่ตรงกลางช่อง gridพอดี(ไม่ต้องเพิ่ม cellsize/2)
        5. สร้าง Object ขึ้นมาโดยให้เก็บไว้ที่ตัวแปร newBuilding และ Object ที่สร้างมาก็ต้องอยู่ในตำแหน่ง worldPosition
        6. ตรวจสอบว่า newBuilding มี Component building อยู่ในตัวมันรึเปล่า โดยใช้ TryGetComponent ถ้ามีให้สร้างตัวแปร b ประเภท 
            building ขึ้นมาเพื่อทำการเชื่อมกับ component building ที่อยู่ใน newBuilding 
        7. จากนั้นกำหนดค่า incomePerTick ที่อยู่ใน newBuilding ให้เท่ากับ currentData.incomePertick
        8. สร้าง loop ขึ้นมาตามขนาดของ buildingsize แล้วบันทึกค่าลงใน gridArrayData[pos.x+x,pos.y+y]
        8. ประกาศ onBuildingPlace ออกไปพร้อมส่งค่า currentData.cost
        10. ถ้าจากข้อที่ 3 เป็นเท็จให้ Debug ค่าออกมาว่า "เงินไม่พอสร้าง" ตามด้วยชื่อของสิ่งที่จะสร้าง
        */
        

    }

    public void SelectBuilding(int index)
    {
        /*TODO กำหนดให้ตัวแปร selectedBuildingIndex มีค่าเท่ากับ index*/
       
        
    }
}