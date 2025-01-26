using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int healthPlayer = 5;
    public int hungryPlayer = 5;

    public GameObject[] healthSprites;
    public GameObject[] hungrySprites;
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

        // Двигаем персонажа
        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        // Поворачиваем персонажа в сторону движения
        if (movement != Vector3.zero) // Проверяем, есть ли движение
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // Плавный поворот
        }

        // Прыжок
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

    public void HealthCheckSprite()
    {
        if(healthPlayer == 5)
        {
            healthSprites[0].SetActive(true);
            healthSprites[1].SetActive(true);
            healthSprites[2].SetActive(true);
            healthSprites[3].SetActive(true);
            healthSprites[4].SetActive(true);
        }
        if (healthPlayer == 4)
        {
            healthSprites[0].SetActive(true);
            healthSprites[1].SetActive(true);
            healthSprites[2].SetActive(true);
            healthSprites[3].SetActive(true);
            healthSprites[4].SetActive(false);
        }
        if (healthPlayer == 3)
        {
            healthSprites[0].SetActive(true);
            healthSprites[1].SetActive(true);
            healthSprites[2].SetActive(true);
            healthSprites[3].SetActive(false);
            healthSprites[4].SetActive(false);
        }
        if (healthPlayer == 2)
        {
            healthSprites[0].SetActive(true);
            healthSprites[1].SetActive(true);
            healthSprites[2].SetActive(false);
            healthSprites[3].SetActive(false);
            healthSprites[4].SetActive(false);
        }
        if (healthPlayer == 1)
        {
            healthSprites[0].SetActive(true);
            healthSprites[1].SetActive(false);
            healthSprites[2].SetActive(false);
            healthSprites[3].SetActive(false);
            healthSprites[4].SetActive(false);
        }
        if (healthPlayer == 1)
        {
            healthSprites[0].SetActive(false);
            healthSprites[1].SetActive(false);
            healthSprites[2].SetActive(false);
            healthSprites[3].SetActive(false);
            healthSprites[4].SetActive(false);
        }
    }
    public void HungryCheckSprite()
    {
        if(hungryPlayer == 5)
        {
            hungrySprites[0].SetActive(true);
            hungrySprites[1].SetActive(true);
            hungrySprites[2].SetActive(true);
            hungrySprites[3].SetActive(true);
            hungrySprites[4].SetActive(true);
        }
        if (hungryPlayer == 4)
        {
            hungrySprites[0].SetActive(true);
            hungrySprites[1].SetActive(true);
            hungrySprites[2].SetActive(true);
            hungrySprites[3].SetActive(true);
            hungrySprites[4].SetActive(false);
        }
        if (hungryPlayer == 3)
        {
            hungrySprites[0].SetActive(true);
            hungrySprites[1].SetActive(true);
            hungrySprites[2].SetActive(true);
            hungrySprites[3].SetActive(false);
            hungrySprites[4].SetActive(false);
        }
        if (hungryPlayer == 2)
        {
            hungrySprites[0].SetActive(true);
            hungrySprites[1].SetActive(true);
            hungrySprites[2].SetActive(false);
            hungrySprites[3].SetActive(false);
            hungrySprites[4].SetActive(false);
        }
        if (hungryPlayer == 1)
        {
            hungrySprites[0].SetActive(true);
            hungrySprites[1].SetActive(false);
            hungrySprites[2].SetActive(false);
            hungrySprites[3].SetActive(false);
            hungrySprites[4].SetActive(false);
        }
        if (hungryPlayer == 0)
        {
            hungrySprites[0].SetActive(false);
            hungrySprites[1].SetActive(false);
            hungrySprites[2].SetActive(false);
            hungrySprites[3].SetActive(false);
            hungrySprites[4].SetActive(false);
        }
    }

    public void Update()
    {
        HealthCheckSprite();
        HungryCheckSprite();
    }
}
