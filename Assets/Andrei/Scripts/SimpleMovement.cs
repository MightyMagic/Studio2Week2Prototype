using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    #region MovementProperties
    [SerializeField] private GameObject Player;
    [SerializeField] private float movementSpeed;

    [SerializeField] private float rotationSensitivity;

    [SerializeField] private float jumpMagnitude;
    [SerializeField] private float gravityValue;

    #endregion

    #region States
    public bool onGround = false;
    public bool falling = true;
    public float fallTimer = 0f;

    private Vector3 planeRotation;


    private Rigidbody rb;
    Vector3 verticaltVector;
    Vector3 planeVector;

    Camera cam;
    Vector3 camOffset;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();

        verticaltVector = Vector3.zero;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        cam = Camera.main;
        camOffset = cam.transform.position - transform.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
            onGround= false;
        }

        if(falling)
        {
            fallTimer += Time.deltaTime;
        }
    }

    
    void FixedUpdate()
    {
       planeVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
       

       // Vector3 planeVector = Vector3.forward * Input.GetAxisRaw("Vertical") + Vector3.right * Input.GetAxisRaw("Horizontal");
        planeVector = planeVector.normalized;
        planeVector = transform.TransformDirection(planeVector) * movementSpeed;

        verticaltVector = new Vector3(0f, FallingSpeed(), 0f);

        //rb.velocity = planeVector * Time.deltaTime + verticaltVector;

        rb.velocity = new Vector3(planeVector.x, rb.velocity.y, planeVector.z);

        planeRotation = new Vector3(0f, (0.8f * Input.GetAxis("Mouse X") * rotationSensitivity), 0f);
        Quaternion deltaRotation = Quaternion.Euler(planeRotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpMagnitude, ForceMode.VelocityChange);
        falling = true;
    }

    float FallingSpeed()
    {
        if (falling)
            return -1f * gravityValue * fallTimer;
        else return 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            onGround= true;
        }

        falling= false;
    }

    //  private void LateUpdate()
    //  {
    //
    //      //camOffset = Quaternion.Euler(0f, -planeRotation, 0f) * camOffset;
    //
    //      Vector3 camAdjustment = -1f * planeVector.normalized * camOffset.magnitude;
    //      
    //      Vector3 newPosition = Vector3.Lerp(cam.transform.position, camAdjustment, movementSpeed);
    //      cam.transform.LookAt(Player.transform);
    //
    //  }
}
