using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using Unity.Collections;
using System;



public class GridManager : MonoBehaviour
{
    /* TODO
    ประกาศตัวแปร width,height, cellSize, boxPrefab, gridArray, gridOffset,curserPrefab, curserInstance
    */

    public static event Action<int> OnBuildingPlaced; 

    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public GameObject boxPrefab;
    public GameObject curserPrefab;
    public GameObject buildingPrefab;

    private GameObject[,] gridArrayBG;
    private Vector2 gridOffset;
    private GameObject curserInstance;   

    private GameObject[,] gridArrayData; 
   

    void Start()
    {
        /*TODO
        1.กำหนดค่า gridArray
        2.กำหนดค่า gridOffset
        3.เรียกฟังก์ชัน CreateGrid
        4.เช็ค curserPrefab และ ปิดการทำงานของ curserInstance
        */
        
        gridArrayBG = new GameObject[width,height];
        gridArrayData = new GameObject[width,height];
        gridOffset = new Vector2(-(width/2)*cellSize,-(height/2)*cellSize);
        CreateGrid();
        if(curserPrefab != null)
        {
            curserInstance = Instantiate(curserPrefab);
            curserInstance.SetActive(false);
        }
        
    }

    void Update()
    {
        mouseCurser();

        if(Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            if(float.IsNaN(mouseScreenPos.x) || float.IsNaN(mouseScreenPos.y))
            {
                return;
            }

            if(Camera.main != null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y,Camera.main.nearClipPlane));
                Vector2Int gridPosition = GetGridPosition(new Vector3(mousePosition.x - gridOffset.x, mousePosition.y - gridOffset.y, 0f));

                if (IsValidPosition(gridPosition))
                {
                    PlaceBuilding(gridPosition);
                }
            }
        }


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
        Vector2 gridOffsets = new Vector2(-(width/2)*cellSize+(cellSize/2),-(height/2)*cellSize+(cellSize/2));

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 spawnboxPoint = new Vector3((x*cellSize)+gridOffsets.x,(y*cellSize)+gridOffsets.y,0f);
                GameObject visualbox = Instantiate(boxPrefab,spawnboxPoint,Quaternion.identity);
                gridArrayBG[x,y] = visualbox;
                TextMeshPro textComponent = visualbox.GetComponentInChildren<TextMeshPro>();
                if(textComponent != null)
                {
                    textComponent.text = $"[{x},{y}]";
                }
            }
        }

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
        
        if(Camera.main == null || curserInstance == null) return;

        Vector3 mouseScreenPos = Mouse.current.position.ReadValue();

        if(mouseScreenPos.x < 0 || mouseScreenPos.y > Screen.width ||
            mouseScreenPos.y < 0 || mouseScreenPos.y > Screen.height)
        {
            curserInstance.SetActive(false);
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x,mouseScreenPos.y, 
                Camera.main.nearClipPlane));
        
        Vector2Int gridPosition = GetGridPosition(new Vector3(mousePosition.x - gridOffset.x, 
                mousePosition.y -gridOffset.y,0f));
        
        if(gridPosition.x >= 0 && gridPosition.x < width &&
            gridPosition.y >= 0 && gridPosition.y < height)
        {
            curserInstance.SetActive(true);

            Vector3 cellCenter = new Vector3(
                (gridPosition.x * cellSize) + (cellSize/2) + gridOffset.x,
                (gridPosition.y*cellSize) + (cellSize/2) + gridOffset.y,
                0f 
            );

            curserInstance.transform.position = cellCenter;
        }
        else
        {
            curserInstance.SetActive(false);
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

    private bool IsValidPosition(Vector2Int pos)
    {
        if(pos.x >=0 && pos.x < width && pos.y >=0 && pos.y < height)
        {
            return gridArrayData[pos.x, pos.y] == null;
        }
        return false;
    }

    private void PlaceBuilding(Vector2Int pos)
    {
        Vector3 worldPosition = new Vector3(
            pos.x * cellSize + (cellSize/2) +gridOffset.x,
            pos.y * cellSize + (cellSize/2) + gridOffset.y,
            0f
        );

        gridArrayData[pos.x,pos.y] = Instantiate(buildingPrefab,worldPosition,Quaternion.identity);
        OnBuildingPlaced?.Invoke(10);
    }
}