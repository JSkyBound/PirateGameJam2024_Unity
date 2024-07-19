using System;
using UnityEngine;

public class NPCProximity : MonoBehaviour
{
    public float detectionRadius = 5.0f; // Radius within which the player is detected
    public LayerMask obstacleMask; // Layer mask for obstacles
    public Transform player; // Reference to the player's transform

    [SerializeField] private Color detectionColor = Color.red; // Color when detected
    [SerializeField] private Color originalColor = Color.white; // Color when not detected

    private Renderer npcRenderer;

    void Start()
    {
        npcRenderer = GetComponent<Renderer>();
        originalColor = npcRenderer.material.color; // Default color
    }

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            if (IsPlayerInLineOfSight())
            {
                npcRenderer.material.color = detectionColor;
                Debug.Log("PLAYER DETECTED");
            }
            else
            {
                npcRenderer.material.color = originalColor;
            }
        }
        else
        {
            npcRenderer.material.color = originalColor;
        }
    }

    bool IsPlayerInLineOfSight()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        return !Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
