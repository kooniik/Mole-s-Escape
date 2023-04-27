using UnityEngine;

public class ChangeMaterialOnCollision : MonoBehaviour
{
    public Material blueMaterial; // materiał, który chcemy przypisać do obiektu nr 2

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // sprawdzamy, czy kolizja wystąpiła z obiektem nr 1
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // pobieramy komponent Sprite Renderer
            spriteRenderer.material = blueMaterial; // zmieniamy materiał obiektu nr 2 na blueMaterial
        }
    }
}