using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the NPC movement
    public float distance = 5.0f; // Distance to move in one direction before turning
    private Vector3 startPosition;
    private int currentDirection = 0; // 0: forward, 1: right, 2: backward, 3: left
    private Vector3 nextPosition;
    private float distanceMoved = 0.0f;

    void Start()
    {
        startPosition = transform.position;
        nextPosition = startPosition + Vector3.forward * distance;
    }

    void Update()
    {
        MoveInSquarePattern();
    }

    void MoveInSquarePattern()
    {
        float moveStep = speed * Time.deltaTime;
        distanceMoved += moveStep;

        transform.Translate(nextPosition.normalized * moveStep);

        if (distanceMoved >= distance)
        {
            distanceMoved = 0.0f;
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        currentDirection = (currentDirection + 1) % 4;

        switch (currentDirection)
        {
            case 0: // Move forward
                nextPosition = Vector3.forward * distance;
                break;
            case 1: // Move right
                nextPosition = Vector3.right * distance;
                break;
            case 2: // Move backward
                nextPosition = Vector3.back * distance;
                break;
            case 3: // Move left
                nextPosition = Vector3.left * distance;
                break;
        }

        startPosition = transform.position;
    }
}
