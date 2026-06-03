using UnityEngine;
using TMPro;
using Unity.Collections;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public GameObject boxPrefab;

    private Vector2 gridOffset;
    private GameObject[,] gridArray;

    public GameObject curserPrefab;
    private GameObject curserInstance;

    void Start()
    {
        gridArray = new GameObject[width,height];
       //gridOffset = new Vector2(-(width/2) * cellSize +(cellSize/2),-(height/2)*cellSize+(cellSize/2));
        gridOffset = new Vector2(-(width/2) * cellSize ,-(height/2)*cellSize);

        CreateGrid();

        if(curserPrefab != null)
        {
            curserInstance = Instantiate(curserPrefab);
            curserInstance.SetActive(false);
        }
    }

    void Update()
    {
        Debug.Log(Mouse.current.position.ReadValue());
        mouseCurser();
    }

    private void CreateGrid()
    {
        Vector2 gridOffsets = new Vector2(-(width/2) * cellSize +(cellSize/2),-(height/2)*cellSize+(cellSize/2));
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y< height; y++)
            {
                Vector3 spawnPosition = new Vector3(gridOffsets.x + (x*cellSize),gridOffsets.y +(y * cellSize),0);
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

    private void mouseCurser()
    {
        if(Camera.main == null || curserInstance == null) return;

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

        if(mouseScreenPos.x < 0 || mouseScreenPos.x > Screen.width ||
            mouseScreenPos.y < 0 || mouseScreenPos.y > Screen.height)
        {
            curserInstance.SetActive(false);
            return;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x,mouseScreenPos.y,Camera.main.nearClipPlane));
        
        Vector2Int gridPosition = GetGridPosition(new Vector3(mousePosition.x - gridOffset.x, mousePosition.y - gridOffset.y, 0));
        if(gridPosition.x >= 0 && gridPosition.x < width && gridPosition.y >= 0 && gridPosition.y < height)
        {
            curserInstance.SetActive(true);

            Vector3 cellCenter = new Vector3(
                gridPosition.x * cellSize + (cellSize/2) + gridOffset.x,
                gridPosition.y * cellSize + (cellSize/2) + gridOffset.y,
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
        int x = Mathf.FloorToInt(WorldPosition.x / cellSize);
        int y = Mathf.FloorToInt(WorldPosition.y / cellSize);
        return new Vector2Int(x,y);
    }
}