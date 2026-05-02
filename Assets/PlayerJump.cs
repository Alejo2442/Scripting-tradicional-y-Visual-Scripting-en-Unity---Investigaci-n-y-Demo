using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private InputActionReference jumpAction;

    private bool isGrounded;
    private float playerHalfHeight;

    private void OnEnable()
    {
        if (jumpAction != null && jumpAction.action != null)
            jumpAction.action.Enable();
    }
    private void OnDisable()
    {
        if (jumpAction != null && jumpAction.action != null)
            jumpAction.action.Disable();
    }

    public void Start()
    {
        if (spriteRenderer != null)
        {
            playerHalfHeight = spriteRenderer.bounds.extents.y;
        }
    }

    void Update()
    {
        float distanciaRayo = playerHalfHeight + groundCheckDistance;

        Debug.DrawRay(groundCheck.position, Vector2.down * distanciaRayo, Color.red);

        isGrounded = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            distanciaRayo,
            LayerMask.GetMask("Ground")
        );

        if (jumpAction != null && jumpAction.action != null && jumpAction.action.WasPressedThisFrame())
        {
            if (isGrounded)
            {
                Jump();
            }
            else
            {
                Debug.Log("¡El radar no llega a tocar la capa Ground!");
            }
        }
    }

    private void Jump()
    {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, 0f);
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}