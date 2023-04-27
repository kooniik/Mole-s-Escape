using UnityEngine;

public class EarthCubeCollision : MonoBehaviour
{
    [SerializeField] private Material blueMaterial; // Referencja do materiału "Blue_Material"
    private int collisionCount = 0; // Licznik kolizji

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Sprawdzenie, czy kolizja dotyczy obiektu z tagiem "Player"
        {
            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>(); // Pobranie komponentu MeshRenderer z obiektu, do którego jest przypisany ten skrypt

            if (collisionCount == 0) // Sprawdzenie, czy to pierwsza kolizja
            {
                meshRenderer.material = blueMaterial; // Przypisanie materiału "Blue_Material" do obiektu
                collisionCount++; // Inkrementacja licznika kolizji
            }
            else if (collisionCount == 1) // Sprawdzenie, czy to druga kolizja
            {
                Destroy(gameObject); // Usunięcie obiektu "EarthCube"
            }
        }
    }
}