using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 300.0f; // Velocidade de rotação
    public Transform cameraTransform; // Referência para a transformação da câmera

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula a direção do movimento baseada na rotação da câmera.
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        forward.y = 0; // Garante que o movimento seja apenas no plano horizontal.
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Cria o vetor de movimento combinando as direções forward e right baseadas nos inputs.
        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized * moveSpeed;

        // Aplica força na direção calculada
        rb.AddForce(movement, ForceMode.VelocityChange);

        // Rotação com o mouse
        float turn = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
