using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    private GameObject background;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        background = GameObject.Find("Background");
    }

    void Update()
    {
        // Obtener la entrada del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        bool verticalInput = Input.GetKeyDown(KeyCode.Space);

        // Mover horizontalmente al jugador
        rb.linearVelocityX = horizontalInput * 5f;

        // Verificar que el jugador este tocando el suelo
        Vector2 groundCheckPosition = new Vector2(col.bounds.center.x, col.bounds.min.y);
        Collider2D groundCheck = Physics2D.OverlapBox(groundCheckPosition, new Vector2(0.5f, 0.1f), 0f, LayerMask.GetMask("Ground"));
        if (groundCheck != null && verticalInput) {
            rb.linearVelocityY = 7f;
        }

        // La camara sigue al jugador
        Camera.main.transform.position = new Vector3(
            transform.position.x,
            Camera.main.transform.position.y,
            Camera.main.transform.position.z
        );

        // El fondo se mueve con el jugador
        background.transform.position = new Vector3(
            transform.position.x,
            background.transform.position.y,
            background.transform.position.z
        );
    }
}
