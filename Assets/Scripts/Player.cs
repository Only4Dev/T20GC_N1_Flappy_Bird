using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioManager audioManager;

    [SerializeField] float impulseForce = 5f;
    [SerializeField] float maxFallSpeed = -10f;

    [SerializeField] InputActionAsset InputActions;
    [SerializeField] InputAction jumpAction;

    Rigidbody2D rigidbody2D;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (gameManager.CurrentState == GameState.Waiting)
        {
            if (jumpAction.WasPressedThisFrame())
            {
                gameManager.StartGame();
            }
        }

        else if (gameManager.CurrentState == GameState.Playing)
        {
            LimitFallSpeed();

            if (jumpAction.WasPressedThisFrame())
            {
                ApplyForce();
            }
        }
    }

    void ApplyForce()
    {
        audioManager.PlayFlap();
        rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocityX, impulseForce);
    }

    void LimitFallSpeed()
    {
        if(rigidbody2D.linearVelocityY < maxFallSpeed)
        {
            rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, maxFallSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

    public void StartPlaying()
    {
        rigidbody2D.gravityScale = 1.5f;
        ApplyForce();
    }

    public void Die()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        this.enabled = false;
    }
}
