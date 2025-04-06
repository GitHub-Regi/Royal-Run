using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float moveSpeedUpdate;
    [SerializeField] float xClamp;
    [SerializeField] float zClamp;
    
    Rigidbody rb;
    Vector2 movement;

    LevelGenerator levelGenerator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPos = rb.position;
        Vector3 moveDir = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPos = currentPos + moveDir * (moveSpeed * Time.fixedDeltaTime);

        newPos.x = Mathf.Clamp(newPos.x, -xClamp, xClamp);
        newPos.z = Mathf.Clamp(newPos.z, -zClamp, zClamp);

        rb.MovePosition(newPos);
    }

    public void UpdateMoveSpeed(float chunkSpeed)
    {
        switch (chunkSpeed)
        {
            case >=2f and <= 4f:
                moveSpeed = 3f;
                break;
            case >=5f and <= 8f:
                moveSpeed = 4f;
                break;
            case >= 16f and <= 20f:
                moveSpeed = 7f;
                break;
            case >= 21f:
                moveSpeed = 9f;
                break;
            default:
                moveSpeed = 5f;
                break;
        }
    }
}
