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

    public InputActionReference lookAction;
    private float horiRot, vertRot;
    public float lookSpeed;
    public Camera theCam;
    public float minLookAngle, maxLookAngle;

    public LayerMask whatIsStock;
    public float interactionRange;

    private GameObject heldPickup;
    public Transform holdPoint;

    public float throwForce;

    public LayerMask whatIsShelf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookinput = lookAction.action.ReadValue<Vector2>();

        horiRot += lookinput.x * Time.deltaTime * lookSpeed;
        transform.rotation = Quaternion.Euler(0f, horiRot, 0f);

        vertRot -= lookinput.y * Time.deltaTime * lookSpeed;
        vertRot = Mathf.Clamp(vertRot, minLookAngle, maxLookAngle);
        theCam.transform.localRotation = Quaternion.Euler(vertRot, 0f, 0f);



        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        Vector3 vertMove = transform.forward * moveInput.y;
        Vector3 horiMove = transform.right * moveInput.x;

        Vector3 moveAmount = horiMove + vertMove;
        moveAmount = moveAmount.normalized;

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


        //check for pickup
        Ray ray = theCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if(heldPickup == null)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (Physics.Raycast(ray, out hit, interactionRange, whatIsStock))
                {
                    heldPickup = hit.collider.gameObject;
                    heldPickup.transform.SetParent(holdPoint);
                    heldPickup.transform.localPosition = Vector3.zero;
                    heldPickup.transform.localRotation = Quaternion.identity;

                    heldPickup.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
        else
        {
            if(Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (Physics.Raycast(ray, out hit, interactionRange, whatIsShelf))
                {
                    heldPickup.transform.position = hit.transform.position;
                    heldPickup.transform.rotation = hit.transform.rotation;

                    heldPickup.transform.SetParent(null);
                    heldPickup = null;
                }
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                Rigidbody pickupRB = heldPickup.GetComponent<Rigidbody>();
                pickupRB.isKinematic = false;
                pickupRB.AddForce(theCam.transform.forward * throwForce, ForceMode.Impulse);

                heldPickup.transform.SetParent(null);
                heldPickup = null;
            }
        }
    }
}
