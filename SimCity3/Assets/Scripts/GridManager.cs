using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class GridManager : MonoBehaviour
{
    /* TODO
    1. ประกาศตัวแปร width,height, cellSize, boxPrefab, gridArrayBG, 
        gridOffset,curserPrefab, curserInstance,buildingPrefab,gridArrayData
    2. ประกาศตัวแปร eventBus OnBuildingPlaced
    */

   

    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArrayBG
        2.กำหนดค่า gridOffset
        3.เรียกฟังก์ชัน CreateGrid
        4.เช็ค curserPrefab และ ปิดการทำงานของ curserInstance
        5.กำนหดค่า gridArrayData
        */
        
        
        
    }

    void Update()
    {
        /* TODO
            1. เรียกใช้ MouseCurser
            2. เรียกใช้ PlaceObject
        */
  
    }

    private void CreateGrid()
    {
        /*TODO
        1.กำหนดค่า gridOffsets
        2.สร้างตาราง
            3.สร้าง spawnboxPoint
            4.สร้าง visualBox
            5.ใส่ค่า visualBox ใน gridArray
            6.สร้าง textComponent แล้วเปลี่ยนข้อความให้แสดง ตำแหน่ง x,y ใน ช่อง
        */
       

    }

    private void mouseCurser()
    {
        /*TODO
        1.ตรวจสอบการมีของกล้องและcurserInstance 
        2.สร้าง mouseScreenPos เพื่ออ่านค่าตำแหน่งของเมาส์
        3.เช็คไม่ให้ตำแหน่งเมาส์หลุดขอบของจอ ถ้าหลุดขอบไปแล้วให้ปิดการทำงานของ mouseCurser
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
        
        
        
        return Vector2Int.zero;
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
            7. เรียก IsValidPosition เพื่อเช็คว่า ตำแหน่งนั้นสามารถวางObjectได้ไหม
            8. ทำการวาง Object ในตำหน่ง gridPositionนั้น
        */
        
    }

    private bool IsValidPosition(Vector2Int pos)
    {
        /*TODO
            1.ตรวจสอบตำแหน่งค่า pos ที่ส่งเข้ามาว่า ยังอยู่ในช่อง grid รึเปล่า
            2.ถ้าอยู่ในช่อง grid ให้เช็คอีกครั้งว่า ตำแหน่งนั้นใน gridArrayData นั้นว่างรึเปล่า ถ้าว่างส่งค่า true ถ้าไม่ว่างส่งค่า false
            3.ถ้าไม่อยู่ในช่อง grid ให้ส่งค่า false
        */
        
        return false;
    }

    private void PlaceBuilding(Vector2Int pos)
    {
        /*TODO
            1. สร้าง worldPosition เป็น vector3 ขึ้นมาจากตำแหน่ง pos โดยจะอยู่ตรงกลางในช่อง pos นั้น
            2. ทำการสร้าง buidingPrefab ลงในตำแหน่ง wordPosition พร้อมบันทึกค่าลงยัง gridArrayData ในตำแหน่งนั้น
            3. ประกาศออกไปโดยผ่าน eventbus ที่ชื่อว่า OnBuildingPlaced พร้อมส่งค่า 10 ออกไป
        */
        
    }
}