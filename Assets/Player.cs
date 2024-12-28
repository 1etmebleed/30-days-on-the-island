using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int healthPlayer = 10;

    public int hungryPlayer = 10;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Camera playerCamera;
    public float cameraSensitivity = 2f;

    private Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (horizontal * right + vertical * forward).normalized;

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false; 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    
}