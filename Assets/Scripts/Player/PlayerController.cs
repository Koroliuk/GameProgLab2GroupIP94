using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpForce = 5f;

    private Vector3 _playerMovementInput;
    private Vector2 _playerMouseInput;
    private float _xRot;


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _playerMovementInput = new Vector3(horizontal, 0f, vertical);
        _playerMouseInput = new Vector2(mouseX, mouseY);

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        var moveVector = transform.TransformDirection(_playerMovementInput) * speed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);

        if (Input.GetButtonDown("Jump") && GroundedCheck())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void MovePlayerCamera()
    {
        _xRot -= _playerMouseInput.y * sensitivity;
        _xRot = Mathf.Clamp(_xRot, -90f, 90f);

        transform.Rotate(0f, _playerMouseInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(_xRot, 0f, 0f);
    }
    
    private bool GroundedCheck()
    {
        return Physics.CheckSphere(groundCheck.position, 0.5f, groundLayers, QueryTriggerInteraction.Ignore);
    }
    
    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
