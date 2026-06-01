using UnityEngine;
// อย่าลืมเพิ่ม namespace สำหรับใช้งาน TextMeshPro นะคะ
using TMPro; 

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1.0f;

    private GameObject[,] gridArray;
    private Vector2 gridOffset;

    public GameObject boxPrefab;

    void Start()
    {
        gridArray = new GameObject[width, height];
        // คำนวณ Offset เพื่อให้กึ่งกลางของ Grid อยู่ที่ (0,0) ของฉาก
        gridOffset = new Vector2(-(width / 2f) * cellSize + (cellSize / 2f), -(height / 2f) * cellSize + (cellSize / 2f));

        CreateGrid();

    }

    void CreateGrid()
    {
        // For Loop ซ้อนกันเพื่อสร้าง Grid ตามแนวกว้างและแนวสูง
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // 1. คำนวณตำแหน่งของช่องปัจจุบัน
                Vector3 spawnPosition = new Vector3(gridOffset.x + (x * cellSize), gridOffset.y + (y * cellSize), 0);

                // 2. สร้างกล่องขึ้นมาในฉาก
                GameObject visualBox = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);
                
                // นำไปเก็บไว้ใน Array เพื่อใช้อ้างอิงต่อในอนาคต (เช่น การคลิก หรือเช็คสถานะช่อง)
                gridArray[x, y] = visualBox;

                // 3. ใส่พิกัด [x,y] เข้าไปใน Text ของกล่องนั้นๆ
                // (สมมติว่าใน BoxPrefab มี Component TextMeshPro อยู่ในวัตถุลูก)
                TextMeshPro textComponent = visualBox.GetComponentInChildren<TextMeshPro>();
                if (textComponent != null)
                {
                    textComponent.text = $"[{x},{y}]";
                }
            }
        }
    }
}