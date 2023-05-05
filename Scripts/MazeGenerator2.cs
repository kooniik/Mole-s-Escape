using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator2 : MonoBehaviour
{
    public int width;
    public int height;
    public float wallLength = 1f;
    public GameObject wallPrefab;
    public Transform wallsParent;
    public int fillPercent; // new variable to specify the fill percentage
    public float zPos = 0.5f;
    public float wallMargin = 0.1f;
    public Vector3 gridOffset; // offset of the grid from the origin
    public Vector3 cellSize = Vector3.one; // size of each grid cell

    private int[,] maze;
    private Bounds mazeBounds;
    private Bounds movementBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        // Get the bounds of the second object and determine the movement bounds of the object
        GameObject backgroundObject = GameObject.Find("GroundBackground");
        Renderer backgroundRenderer = backgroundObject.GetComponent<Renderer>();
        movementBounds = backgroundRenderer.bounds;

        objectWidth = wallLength - 2 * wallMargin;
        objectHeight = wallLength - 2 * wallMargin;

        GenerateMaze();
        SpawnMaze();
    }

    void GenerateMaze()
    {
        maze = new int[width, height];

        // initialize maze with outer walls
        for (int i = 0; i < width; i++)
        {
            maze[i, 0] = 1;
            maze[i, height - 1] = 1;
        }
        for (int i = 0; i < height; i++)
        {
            maze[0, i] = 1;
            maze[width - 1, i] = 1;
        }

        // randomly fill the maze based on fill percent
        int totalCells = (width - 2) * (height - 2);
        int cellsToFill = Mathf.RoundToInt(fillPercent * 0.01f * totalCells);
        for (int i = 0; i < cellsToFill; i++)
        {
            int x = Random.Range(2, width - 2);
            int y = Random.Range(2, height - 2);
            maze[x, y] = 1;
        }
    }

    void SpawnMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (maze[x, y] == 1)
                {
                    // Limit the position of the wall to the bounds of the second object
                    float xPos = Mathf.Clamp(-width / 2f + x + 0.5f + wallMargin * x,
                                             movementBounds.min.x + objectWidth / 2,
                                             movementBounds.max.x - objectWidth / 2);
                    float yPos = Mathf.Clamp(-height / 2f + y + 0.5f + wallMargin * y,
                                             movementBounds.min.y + objectHeight / 2,
                                             movementBounds.max.y - objectHeight / 2);
                    Vector3 wallPos = new Vector3(xPos, yPos, zPos);

                    // Apply the grid offset and cell size to the wall position
                    wallPos = gridOffset + Vector3.Scale(wallPos, cellSize);

                    GameObject wall = Instantiate(wallPrefab, wallPos, Quaternion.identity, wallsParent);
                    wall.transform.localScale = new Vector3(wallLength - wallMargin, wallLength - wallMargin, wallLength);
                }
            }
        }
    }

    // Draw the grid
void OnDrawGizmos()
{
Gizmos.color = Color.grey;
// Draw vertical lines of the grid
for (float x = 0; x <= width; x += cellSize.x)
{
    Vector3 start = new Vector3(x, 0, 0) + gridOffset;
    Vector3 end = new Vector3(x, 0, height) + gridOffset;
    Gizmos.DrawLine(start, end);
}

// Draw horizontal lines of the grid
for (float y = 0; y <= height; y += cellSize.z)
{
    Vector3 start = new Vector3(0, 0, y) + gridOffset;
    Vector3 end = new Vector3(width, 0, y) + gridOffset;
    Gizmos.DrawLine(start, end);
}
}}