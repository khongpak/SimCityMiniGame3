using UnityEngine;
using TMPro; 

public class GridManager : MonoBehaviour
{
   public int width = 10;
   public int height = 10;
   public float cellSize = 1f;
   public GameObject boxPrefab;

   private GameObject[,] gridArray;
   private Vector2 gridOffset;

    void Start()
    {
        gridOffset = new Vector2(-(width/2) * cellSize + (cellSize/2), -(height/2)*cellSize + (cellSize/2));
        gridArray = new GameObject[width,height];

        createGrid();
    }

    private void createGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector3 spawnPosition = new Vector3(gridOffset.x + (x * cellSize), gridOffset.y +(y * cellSize),0);
                GameObject visualBox = Instantiate(boxPrefab,spawnPosition,Quaternion.identity);
                gridArray[x,y] = visualBox;

                TextMeshPro textComponent = visualBox.GetComponentInChildren<TextMeshPro>();
                if(textComponent != null)
                {
                    textComponent.text = $"[{x},{y}]";
                }
            }
        }
    }
}