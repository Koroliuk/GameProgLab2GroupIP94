using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private LayerMask  FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float JumpForce;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

  

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();

    }

    private void MovePlayer() 
    {   
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if (Input.GetButtonDown("Jump")) 
        {   
            if (Physics.CheckSphere(FeetTransform.position, 0.5f, FloorMask, QueryTriggerInteraction.Ignore))
            {   
                PlayerBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }   
        }
            
    }

    private void MovePlayerCamera ()
    {   
        xRot -= PlayerMouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f); 


        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f ,0f);
    }
       //
       // [SerializeField] private float _moveSpeed = 5f;
       // [SerializeField] private float _jumpForce = 5f;
       //
       // [SerializeField] private Transform _groundCheck;
       // [SerializeField] private LayerMask _groundLayers;
       // [SerializeField] private float _groundedRadius = 0.5f;
       //
       // private Rigidbody _rb;
       // private bool _isGrounded;
       //
       // private void Awake()
       // {
       //     _rb = GetComponent<Rigidbody>();
       // }
       //
       // private void Update()
       // {
       //     Move();
       //     Jump();
       //     GroundedCheck();
       // }
       //
       // private void Move()
       // {
       //     var inputX = Input.GetAxis("Horizontal");
       //     var inputZ = Input.GetAxis("Vertical");
       //     Vector3 _moveDir = new Vector3(inputX, 0, inputZ).normalized;
       //
       //     var moveVectore = _moveDir * _moveSpeed;
       //     _rb.velocity = new Vector3(moveVectore.x, _rb.velocity.y, moveVectore.z);
       // }
       //
       // private void Jump()
       // {
       //     if (Input.GetButtonDown("Jump") && _isGrounded)
       //     {
       //         _isGrounded = false;
       //         _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
       //     }
       // }
       //
       // private void GroundedCheck()
       // {
       //     _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundedRadius, _groundLayers, QueryTriggerInteraction.Ignore);
       // }
       //
       // private void OnApplicationFocus(bool hasFocus)
       // {
       //     SetCursorState(true);
       // }
       //
       // private void SetCursorState(bool newState)
       // {
       //     Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
       // }
}
