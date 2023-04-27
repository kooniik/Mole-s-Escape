using UnityEngine;

public class Mole_Control_WSAD : MonoBehaviour
{
    public float moveSpeed = 5f; // prędkość poruszania się
    private Rigidbody2D rb; // komponent Rigidbody2D obiektu Mole

    void Start()
    {
        // pobranie komponentu Rigidbody2D obiektu Mole
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // pobranie wejścia z klawiatury
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // obliczenie wektora kierunku ruchu
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // ustawienie prędkości obiektu
        rb.velocity = movement * moveSpeed;
    }
}
