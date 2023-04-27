using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public Joystick joystick; // referencja do joysticka
    public float moveSpeed = 5f; // prędkość poruszania się
    private Rigidbody2D rb; // komponent Rigidbody2D obiektu

    void Start()
    {
        // pobranie komponentu Rigidbody2D obiektu
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // pobranie wartości wejścia z joysticka
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        // obliczenie wektora kierunku ruchu
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // ustawienie prędkości obiektu
        rb.velocity = movement * moveSpeed;
    }
}