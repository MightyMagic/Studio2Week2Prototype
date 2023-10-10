using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplestMovement : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private float movementSpeed;

    [SerializeField] private float rotationSensitivity;

    [SerializeField] private float jumpMagnitude;
    [SerializeField] private float gravityValue;


    [SerializeField] private Rigidbody rb;
    Vector3 verticaltVector;
    Vector3 planeVector;

    public bool onGround = false;
    public bool falling = true;
    public float fallTimer = 0f;

    private Vector3 planeRotation;


    void Start()
    {
       // Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        planeVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        planeVector = planeVector.normalized;
        planeVector = transform.TransformDirection(planeVector) * movementSpeed;

        rb.velocity = new Vector3(planeVector.x, rb.velocity.y, planeVector.z);

        planeRotation = new Vector3(0f, (0.8f * Input.GetAxis("Mouse X") * rotationSensitivity), 0f);
        Quaternion deltaRotation = Quaternion.Euler(planeRotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
        //rb.angularVelocity = planeRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
            onGround = false;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpMagnitude, ForceMode.VelocityChange);
        falling = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        onGround = true;
        falling = false;
    }
}
