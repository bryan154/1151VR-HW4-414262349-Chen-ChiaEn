using UnityEngine;

public class AircraftController : MonoBehaviour
{
    public float forwardSpeed=5f;
    public float mouseSensitivity=0.03f;

    private Vector3 lastMousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            Vector3.forward * forwardSpeed * Time.deltaTime,
            Space.World
        );

        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition-lastMousePosition;

            float moveX = delta.x * mouseSensitivity;
            float moveY = delta.y * mouseSensitivity;

            transform.Translate(
                new Vector3(moveX,moveY,0),
                Space.World
            );
            lastMousePosition = Input.mousePosition;
        }

    }
}
