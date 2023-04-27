using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject wallPrefab;  // prefabrykat ściany
    public int mazeWidth;          // szerokość labiryntu
    public int mazeHeight;         // wysokość labiryntu

    private void Start()
    {
        GenerateMaze(new Vector2Int(0, 0), new Vector2Int(mazeWidth - 1, mazeHeight - 1));
    }

    private void GenerateMaze(Vector2Int start, Vector2Int end)
    {
        // Sprawdzamy, czy obszar labiryntu jest wystarczająco duży, aby dzielić
        if (start.x > end.x || start.y > end.y) return;
        Vector2Int size = end - start;
        if (size.x < 2 || size.y < 2) return;

        // Losowo wybieramy jedną ze ścian do usunięcia
        Vector2Int wallPos = new Vector2Int(Random.Range(start.x + 1, end.x), Random.Range(start.y + 1, end.y));

        // Tworzymy ściany dla całego obszaru
        for (int x = start.x; x <= end.x; x++)
        {
            for (int y = start.y; y <= end.y; y++)
            {
                if (x == wallPos.x && y == wallPos.y) continue;
                if (x == start.x || x == end.x || y == start.y || y == end.y)
                {
                    GameObject newWall = Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity);
                    newWall.transform.parent = transform;
                }
            }
        }

        // Rekurencyjnie generujemy labirynt dla każdej z dwóch części obszaru
        GenerateMaze(start, wallPos - Vector2Int.one);
        GenerateMaze(new Vector2Int(start.x, wallPos.y + 1), new Vector2Int(wallPos.x - 1, end.y));
    }
}
