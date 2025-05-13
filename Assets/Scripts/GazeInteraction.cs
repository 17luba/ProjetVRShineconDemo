using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    public float rayLength = 100f;
    public string targetTag = "Target";
    public float moveSpeed = 3.5f;
    public float activationTime = 1.5f;

    private float gazeTimer = 0f;
    private Transform player;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        Ray ray = new Ray(player.position, player.forward);
        RaycastHit hit;

        bool isLookingAtTarget = false;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                isLookingAtTarget = true;
                gazeTimer += Time.deltaTime;

                // Si on atteint le temps requis, activer le déplacement
                if (gazeTimer >= activationTime && !isMoving)
                {
                    targetPosition = hit.point;
                    isMoving = true;
                }
            }
        }

        // Si on ne regarde pas l'objet, on reset tout
        if (!isLookingAtTarget)
        {
            gazeTimer = 0f;

            // Si on n'est plus en train de regarder, on annule le déplacement
            if (isMoving)
            {
                isMoving = false;
            }
        }

        // Mouvement du joueur
        if (isMoving)
        {
            Vector3 direction = (targetPosition - player.position).normalized;
            Vector3 move = direction * moveSpeed * Time.deltaTime;

            // Déplacement seulement sur l’axe XZ
            move.y = 0;

            player.parent.transform.position += move;

            // Arrêt si proche
            if (Vector3.Distance(player.position, targetPosition) < 0.5f)
            {
                isMoving = false;
                gazeTimer = 0f;
            }
        }
    }
}
