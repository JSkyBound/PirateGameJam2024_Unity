using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed of the character
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get input from controller
        float moveHorizontalController = Input.GetAxis("HorizontalController");
        float moveVerticalController = Input.GetAxis("VerticalController");

        // Combine keyboard and controller input
        Vector3 movement = new Vector3(moveHorizontal + moveHorizontalController, 0.0f, moveVertical + moveVerticalController);

        rb.velocity = movement * speed;
    }
}
