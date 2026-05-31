using Unity.Mathematics;
using UnityEngine;

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
        gridArray = new GameObject[width,height];
        gridOffset = new Vector2(-(width/2f)*cellSize,-(height/2f)*cellSize);
        Debug.Log(gridOffset);

        Instantiate(boxPrefab,gridOffset,transform.rotation);
    }

}
