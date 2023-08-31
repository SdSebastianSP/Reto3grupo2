using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        // Movimiento basado en la dirección de la cámara
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        Vector3 moveDirection = (cameraForward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        // Salto
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        // Detectar colinas y aplicar fuerza para subir/bajar
        if (!isGrounded) return;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f, groundLayer))
        {
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);

            if (slopeAngle > 0 && slopeAngle <= 45)
            {
                Vector3 slopeDirection = Vector3.Cross(Vector3.Cross(Vector3.up, hit.normal), hit.normal).normalized;
                //rb.AddForce(slopeDirection * slopeForce);
            }
        }
    }
}
