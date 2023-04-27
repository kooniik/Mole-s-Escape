using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EarthCube")) // Sprawdzenie, czy kolizja dotyczy obiektu z tagiem "EarthCube"
        {
            Debug.Log("Player zderzył się z wrogiem!"); // Wyświetlenie informacji w konsoli
        }
    }
}