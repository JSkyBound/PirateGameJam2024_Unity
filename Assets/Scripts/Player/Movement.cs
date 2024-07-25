using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 5.0f; // Adjust the speed of the character while not sneaking
    public float sneakSpeed = 2.5f; // Slower movement speed
    private float currentSpeed; // Current movement speed
    public float jumpForce = 5.0f; // Adjust jump height
    private Rigidbody rb;
    public Transform cameraTransform; // Reference to the camera's transform
    public LayerMask groundLayer; // Layer mask for the ground
    private bool isGrounded = false; // Whether the player is on the ground
    public float distanceFromGroundCheck = 0.5f;
    public KeyCode sneakKey = KeyCode.LeftShift;
    public bool isSneaking;

    RaycastHit hit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if (CheckIsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Move() 
    {
        isPlayerSneaking();

        // Get input from keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Get input direction relative to the camera
        UnityEngine.Vector3 forward = cameraTransform.forward;
        UnityEngine.Vector3 right = cameraTransform.right;

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
        UnityEngine.Vector3 moveDirection = (forward * moveVertical + right * moveHorizontal).normalized;

        // Move the player
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
        
    }

    void Jump()
    {
        // Apply an upward force to the player
        rb.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);
    }
    bool isPlayerSneaking()
    {
        if (Input.GetKey(sneakKey))
        {
            currentSpeed = sneakSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
        return isSneaking;
    }

    bool CheckIsGrounded()
    {
        // Check if the player is on the ground
        isGrounded = (Physics.Raycast(transform.position, UnityEngine.Vector3.down, out hit, distanceFromGroundCheck ,groundLayer));

        return isGrounded;
    }
}