using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using Unity.Collections;
using Unity.Mathematics;



public class GridManager : MonoBehaviour
{
    /* TODO
    1. ประกาศตัวแปร width,height, cellSize, boxPrefab, gridArrayBG, 
        gridOffset,curserPrefab, curserInstance,buildingPrefab,gridArrayData
    2. ประกาศตัวแปร eventBus OnBuildingPlaced
    */

    public static event Action<int> OnBuildingPlaced;

    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public GameObject boxPrefab;
    public GameObject curserPrefab;
    public GameObject buildingPrefab;

    private GameObject[,] gridArrayBG;
    private GameObject[,] gridArrayData;
    private Vector2 gridOffset;
    private GameObject curserInstace;    
   

    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArrayBG
        2.กำหนดค่า gridOffset
        3.เรียกฟังก์ชัน CreateGrid
        4.เช็ค curserPrefab และ ปิดการทำงานของ curserInstance
        5.กำนหดค่า gridArrayData
        */
        gridArrayBG = new GameObject[width,height];
        gridArrayData = new GameObject[width,height];
        gridOffset = new Vector2(-(width/2f)*cellSize , -(height/2f)*cellSize);
        CreateGrid();
        if(curserPrefab != null)
        {
            curserInstace = Instantiate(curserPrefab);
            curserInstace.SetActive(false);
        }
        
        
    }

    void Update()
    {
        /* TODO
            1. เรียกใช้ MouseCurser
            2. เรียกใช้ PlaceObject
        */
       MouseCurser();
       PlaceObject();
  
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
       
       Vector2 gridOffsets = new Vector2 (-(width/2)*cellSize + (cellSize/2), -(height/2)*cellSize + (cellSize/2));

       for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 spawnboxPoint = new Vector3(gridOffsets.x + (x*cellSize), gridOffsets.y + (y*cellSize),0f);
                GameObject visualBox = Instantiate(boxPrefab,spawnboxPoint,Quaternion.identity);
                gridArrayBG[x,y] = visualBox;
                TextMeshPro textComponent = visualBox.GetComponentInChildren<TextMeshPro>();
                if(textComponent != null)
                {
                    textComponent.text = $"[{x},{y}]";
                }
            }
        }

    }

    private void MouseCurser()
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
        
        if(Camera.main == null || curserInstace == null) return;
        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();

        if(mouseScreenPos.x < 0 || mouseScreenPos.x > Screen.width ||
            mouseScreenPos.y < 0 || mouseScreenPos.y > Screen.height)
        {
            curserInstace.SetActive(false);
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane));

        Vector2Int gridPosition = GetGridPosition(new Vector3(
                mousePosition.x - gridOffset.x, mousePosition.y - gridOffset.y, 0f));
        
        if(gridPosition.x >= 0 && gridPosition.x < width &&
            gridPosition.y >= 0 && gridPosition.y < height)
        {
            curserInstace.SetActive(true);
            Vector3 cellCenter = new Vector3(
                (gridPosition.x *cellSize) + ( cellSize/2) + gridOffset.x,
                (gridPosition.y * cellSize) + (cellSize/2) + gridOffset.y,
                0f 
            );

            curserInstace.transform.position = cellCenter;

        }
        else
        {
            curserInstace.SetActive(false);
        }
    }


    private Vector2Int GetGridPosition(Vector3 WorldPosition)
    {
        /*
        1. สร้างตัวแปร x เพื่อแปลงค่า x จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        2. สร้างตัวแปร y เพื่อแปลงค่า y จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        3. คืนค่า x,y แบบ Vector2Int
        */
        int x = Mathf.FloorToInt(WorldPosition.x / cellSize);
        int y = Mathf.FloorToInt(WorldPosition.y / cellSize);
        
        
        return new Vector2Int(x,y);
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

        if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            if(float.IsNaN(mouseScreenPos.x) || float.IsNaN(mouseScreenPos.y)) return;

            if(Camera.main != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(
                    mouseScreenPos.x,mouseScreenPos.y,Camera.main.nearClipPlane));
                
                Vector2Int gridPosition = GetGridPosition(new Vector3(
                    mousePosition.x - gridOffset.x,mousePosition.y - gridOffset.y,0f
                ));

                if (IsValidPosition(gridPosition))
                {
                    PlaceBuilding(gridPosition);
                }
            }
        }

       
        
    }

    private bool IsValidPosition(Vector2Int pos)
    {
        /*TODO
            1.ตรวจสอบตำแหน่งค่า pos ที่ส่งเข้ามาว่า ยังอยู่ในช่อง grid รึเปล่า
            2.ถ้าอยู่ในช่อง grid ให้เช็คอีกครั้งว่า ตำแหน่งนั้นใน gridArrayData นั้นว่างรึเปล่า ถ้าว่างส่งค่า true ถ้าไม่ว่างส่งค่า false
            3.ถ้าไม่อยู่ในช่อง grid ให้ส่งค่า false
        */

        if(pos.x >=0 && pos.x < width &&
            pos.y >= 0 && pos.y < height)
        {
            return gridArrayData[pos.x, pos.y] == null;
        }
        
        return false;
    }

    private void PlaceBuilding(Vector2Int pos)
    {
        /*TODO
            1. สร้าง worldPosition เป็น vector3 ขึ้นมาจากตำแหน่ง pos โดยจะอยู่ตรงกลางในช่อง pos นั้น
            2. ทำการสร้าง buidingPrefab ลงในตำแหน่ง wordPosition พร้อมบันทึกค่าลงยัง gridArrayData ในตำแหน่งนั้น
            3. ประกาศออกไปโดยผ่าน eventbus ที่ชื่อว่า OnBuildingPlaced พร้อมส่งค่า 10 ออกไป
        */
        
        Vector3 worldPositon = new Vector3(
            (pos.x * cellSize) + (cellSize/2) + gridOffset.x,
            (pos.y * cellSize) + (cellSize/2) + gridOffset.y,
            0f
        );

        gridArrayData[pos.x, pos.y] = Instantiate(buildingPrefab,worldPositon,Quaternion.identity);
        OnBuildingPlaced?.Invoke(10);
    }
}