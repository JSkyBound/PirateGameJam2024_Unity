using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed of the character
    private Rigidbody rb;
    public Transform cameraTransform; // Reference to the camera's transform

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();     
    }

    private void Move() 
    {
        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get input direction relative to the camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Flatten the vectors to ignore vertical movement
        forward.y = 0;
        right.y = 0;

        // Normalize the vectors
        forward.Normalize();
        right.Normalize();

        // Get input from controller
        //float moveHorizontalController = Input.GetAxis("HorizontalController");
        //float moveVerticalController = Input.GetAxis("VerticalController");

        // Combine keyboard and controller input
        //Vector3 movement = new Vector3(moveHorizontal + moveHorizontalController, 0.0f, moveVertical + moveVerticalController);
        //Vector3 moveDirection = (forward * (moveVertical + moveVerticalController) + right * (moveHorizontal + moveHorizontalController)).normalized;
        Vector3 moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        // Move the player
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        
    }
}