using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float xClamp;
    [SerializeField] float zClamp;
    
    Rigidbody rb;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
}
