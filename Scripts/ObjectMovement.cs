using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;
    private Bounds movementBounds;

    // Uzyskaj granice drugiego obiektu i wyznacz granice ruchu obiektu
    private void Start()
    {
        GameObject backgroundObject = GameObject.Find("GroundBackground"); // nazwa drugiego obiektu
        Renderer backgroundRenderer = backgroundObject.GetComponent<Renderer>();
        movementBounds = backgroundRenderer.bounds;

        // Ustaw rozmiary obiektu
        objectWidth = transform.GetComponent<Renderer>().bounds.size.x;
        objectHeight = transform.GetComponent<Renderer>().bounds.size.y;
    }

    private void Update()
    {
        // Ogranicz ruch obiektu do granic drugiego obiektu
        float xPosition = Mathf.Clamp(transform.position.x, 
                                      movementBounds.min.x + objectWidth / 2, 
                                      movementBounds.max.x - objectWidth / 2);
        float yPosition = Mathf.Clamp(transform.position.y, 
                                      movementBounds.min.y + objectHeight / 2, 
                                      movementBounds.max.y - objectHeight / 2);
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }
}