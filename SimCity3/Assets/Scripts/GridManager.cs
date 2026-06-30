using UnityEngine;
using System;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;


public class GridManager : MonoBehaviour
{
    /* TODO
    1. ประกาศตัวแปร width,height, cellSize, boxPrefab, gridArrayBG, 
        gridOffset,cursorPrefab, cursorInstance,gridArrayData
    2. ประกาศตัวแปร eventBus OnBuildingPlaced
    3. สร้างส่วนของ [Header("Building Setting)] แล้วสร้าง 2 ตัวแปรนี้ให้อยู่ภายใต้หัวข้อนี้
        4. สร้างตัวแปร availableBuilding เป็นแบบ Array ประเภท BuildingData
        5. สร้างตัวแปร int selectedBuildingIndex
    */
    [Header("Building Setting")]
        public BuildingData[] availableBuilding;
        private int selectedBuildingIndex;
    
    public static event Action<int> OnBuildingPlaced;

    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public GameObject boxPrefab;
    public GameObject cursorPrefab;

    private Vector2 gridOffset;
    private GameObject[,] gridArrayBG;
    private GameObject[,] gridArrayData;
    private GameObject cursorInstance;




    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArrayBG
        2.กำหนดค่า gridOffset
        3.เรียกฟังก์ชัน CreateGrid
        4.เช็ค cursorPrefab และ ปิดการทำงานของ cursorInstance
        5.กำหนดค่า gridArrayData
        */
        gridArrayBG =  new GameObject[width,height];
        gridArrayData = new GameObject[width,height];
        gridOffset = new Vector2(-(width/2)*cellSize, -(height/2)*cellSize);
        CreateGrid();
        if(cursorPrefab != null)
        {
            cursorInstance = Instantiate(cursorPrefab);
            cursorInstance.SetActive(false);
        }
        
        
    }

    void Update()
    {
        /* TODO
            1. เรียกใช้ Mousecursor
            2. เรียกใช้ PlaceObject
        */
        Mousecursor();
        PlaceObject();

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
        Vector2 gridOffsetBG = new Vector2(-(width/2)*cellSize + (cellSize/2),-(height/2)*cellSize + (cellSize/2));
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 spawnboxPoint = new Vector3((x*cellSize) + gridOffsetBG.x,(y*cellSize) + gridOffsetBG.y, 0f);
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
        if(Camera.main == null || cursorInstance == null) return;

        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();

        if(mouseScreenPos.x < 0 || mouseScreenPos.x > Screen.width
            || mouseScreenPos.y < 0 || mouseScreenPos.y > Screen.height)
        {
            cursorInstance.SetActive(false);
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(
            mouseScreenPos.x,mouseScreenPos.y, Camera.main.nearClipPlane
        ));

        Vector2Int gridPosition = GetGridPosition(new Vector3(
            mousePosition.x - gridOffset.x, mousePosition.y - gridOffset.y,0f
        ));
       
       if(gridPosition.x >= 0 && gridPosition.x < width && gridPosition.y >= 0 && gridPosition.y < height)
        {
            cursorInstance.SetActive(true);

            Vector3 cellCenter = new Vector3(
                (gridPosition.x * cellSize) + (cellSize/2) + gridOffset.x,
                (gridPosition.y * cellSize) + (cellSize/2) + gridOffset.y,0f
            );

            cursorInstance.transform.position = cellCenter;
        }
    }


    private Vector2Int GetGridPosition(Vector3 WorldPosition)
    {
        /*
        1. สร้างตัวแปร x เพื่อแปลงค่า x จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        2. สร้างตัวแปร y เพื่อแปลงค่า y จาก WorldPosition ที่ส่งเข้ามาโดยปัดเศษทิ้ง
        3. คืนค่า x,y แบบ Vector2Int
        */
        int x = Mathf.FloorToInt(WorldPosition.x/cellSize);
        int y = Mathf.FloorToInt(WorldPosition.y/cellSize);

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
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            if(float.IsNaN(mouseScreenPos.x) || float.IsNaN(mouseScreenPos.y)) return;

            if(Camera.main != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(
                    mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane
                ));

                Vector2Int gridPosition = GetGridPosition(new Vector3(
                    mousePosition.x - gridOffset.x, mousePosition.y - gridOffset.y,0f
                ));

                if (IsValidPosition(gridPosition))
                {
                    CreateBuilding(gridPosition);
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

        if(pos.x >= 0 && pos.x < width && pos.y >= 0 && pos.y < height)
        {
            return gridArrayData[pos.x,pos.y] == null;
        }
                
        return false;
    }
    
    private void CreateBuilding(Vector2Int pos)
    {
        /*TODO
        1. สร้างตัวแปร currentData ประเภท BuildingData ให้เก็บค่าจาก availableBuilding ชี้ index ที่ตัวแปร selectedBuildingIndex
        2. สร้างตัวแปร resourceManager ประเภท ResourceManager แล้วให้เก็บค่าจาก Object แรกที่มีComponent ResourceManager 
            โดยใช้ FindFirstObject
        3. ตรวจสอบว่า resourceManager ไม่ได้เป็นค่าว่าง และ เงินที่อยู่ใน resourceManager มีค่ามากกว่า currentData.cost
        4. สร้างตัวแปร worldPosition เพื่อให้วัตถุที่จะวางลงอยู่ตรงกลางช่อง gridพอดี
        5. สร้าง Object ขึ้นมาโดยให้เก็บไว้ที่ตัวแปร newBuilding และ Object ที่สร้างมาก็ต้องอยู่ในตำแหน่ง worldPosition
        6. ตรวจสอบว่า newBuilding มี Component building อยู่ในตัวมันรึเปล่า โดยใช้ TryGetComponent ถ้ามีให้สร้างตัวแปร b ประเภท 
            building ขึ้นมาเพื่อทำการเชื่อมกับ component building ที่อยู่ใน newBuilding 
        7. จากนั้นกำหนดค่า incomePerTick ที่อยู่ใน newBuilding ให้เท่ากับ currentData.incomePertick
        8. ประกาศ onBuildingPlace ออกไปพร้อมส่งค่า currentData.cost
        9. ให้ตัวแปร array gridArrayData บันทึกตำแหน่งของ newBuilding
        10. ถ้าจากข้อที่ 3 เป็นเท็จให้ Debug ค่าออกมาว่า "เงินไม่พอสร้าง" ตามด้วยชื่อของสิ่งที่จะสร้าง
        */
        BuildingData currentData = availableBuilding[selectedBuildingIndex];
        ResourceManager resourceManager = FindFirstObjectByType<ResourceManager>();

        if(resourceManager != null && resourceManager.gold >= currentData.cost)
        {
            Vector3 worldPosition = new Vector3(
                (pos.x * cellSize) + (cellSize/2) + gridOffset.x,
                (pos.y * cellSize) +  (cellSize/2) + gridOffset.y,
                0f
            );

            GameObject newBuilding = Instantiate(currentData.buildingPrefab,worldPosition,Quaternion.identity);
            if(newBuilding.TryGetComponent(out Building b))
            {
                b.incomePerTick = currentData.incomePerTick;

                OnBuildingPlaced?.Invoke(currentData.cost);
                gridArrayData[pos.x,pos.y] = newBuilding;

            }
        }
        else
        {
            Debug.Log("เงินไม่พอสร้าง "+currentData.name);
        }
       

    }

    public void SelectBuilding(int index)
    {
        /*TODO กำหนดให้ตัวแปร selectedBuildingIndex มีค่าเท่ากับ index*/
        selectedBuildingIndex = index;
        
    }
}