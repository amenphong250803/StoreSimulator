using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference moveAction;

    public CharacterController charCon;

    public float moveSpeed;

    private float ySpeed;

    public InputActionReference jumpAction;

    public float jumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 moveAmount = new Vector3(moveInput.x, 0f, moveInput.y);

        moveAmount = moveAmount * moveSpeed;

        if (charCon.isGrounded == true)
        {
            ySpeed = 0f;

            if (jumpAction.action.WasPressedThisFrame())
            {
                ySpeed = jumpForce;
            }
        }

        ySpeed = ySpeed + (Physics.gravity.y * Time.deltaTime);
        

        moveAmount.y = ySpeed;

        charCon.Move(moveAmount * Time.deltaTime);
    }
}
