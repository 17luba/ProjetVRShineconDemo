using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    [Header("Deplacement joueur")]
    public float rayLength = 100f;
    public string targetTag = "Target";
    public float moveSpeed = 3.5f;
    public float activationTime = 0f;

    [Header("UI")]
    public GazeUIManager gazeUIManager;
    public string defaultGazeMessage = "";

    private float gazeTimer = 0f;
    private Transform player;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private GameObject currentTarget = null;

    void Start()
    {
        player = Camera.main.transform;
    }

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            GameObject hitObject = hit.collider.gameObject;

            // Si nouveau regard sur autre objet
            if (hitObject != currentTarget)
            {
                currentTarget = hitObject;
                gazeTimer = 0f;
            }

            gazeTimer += Time.deltaTime;

            // 🔎 Lecture du message à afficher
            string message = defaultGazeMessage;
            GazeTarget gazeTarget = hitObject.GetComponent<GazeTarget>();
            if (gazeTarget != null)
            {
                message = gazeTarget.GetFormattedMessage();
                gazeUIManager?.ShowMessage(message);
            }
            else
            {
                gazeUIManager?.HideMessage();
            }

            // ✅ Si regarde un objet "Target", on commence à se déplacer après délai
            if (hitObject.CompareTag(targetTag) && gazeTimer >= activationTime && !isMoving)
            {
                targetPosition = hit.point;
                isMoving = true;
            }

            // 🟡 Si on regarde un autre objet qui n’est pas un "Target", on arrête le mouvement
            if (!hitObject.CompareTag(targetTag))
            {
                isMoving = false;
            }
        }
        else
        {
            // 🟡 Si on ne regarde rien : reset
            currentTarget = null;
            gazeTimer = 0f;
            isMoving = false; // 🔴 Arrêt immédiat du déplacement
            gazeUIManager?.HideMessage();
        }

        // Mouvement du joueur
        if (isMoving)
        {
            Vector3 direction = (targetPosition - Camera.main.transform.position).normalized;
            direction.y = 0;
            Camera.main.transform.parent.position += direction * Time.deltaTime * moveSpeed;

            if (Vector3.Distance(Camera.main.transform.position, targetPosition) < 0.5f)
            {
                isMoving = false;
                gazeTimer = 0f;
            }
        }
    }
}