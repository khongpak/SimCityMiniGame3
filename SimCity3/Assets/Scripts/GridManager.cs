using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.InputSystem;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public GameObject boxPrefab;

    private Vector2 gridOffset;
    private GameObject[,] gridArray;

    void Start()
    {
        gridArray = new GameObject[width,height];
        gridOffset = new Vector2(-(width/2) * cellSize +(cellSize/2),-(height/2)*cellSize+(cellSize/2));

        CreateGrid();
    }

    void Update()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Debug.Log(mouseScreenPos);
    }

    private void CreateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y< height; y++)
            {
                Vector3 spawnPosition = new Vector3(gridOffset.x + (x*cellSize),gridOffset.y +(y * cellSize),0);
                GameObject visualBox = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);
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