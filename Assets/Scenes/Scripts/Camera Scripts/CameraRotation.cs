using UnityEngine;

// Classe CameraRotation que controla a orientação da câmera baseada nos movimentos do mouse.
public class CameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilidade do mouse, ajustável pelo Unity Editor.
    private float xRotation = 0f; // Armazena a rotação acumulada no eixo X (vertical).

    // Método Start é chamado no primeiro frame quando o script é ativado.
    void Start()
    {
        // Bloqueia o cursor no centro da tela e o oculta, melhorando a interação em jogos de FPS.
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Método Update é chamado uma vez a cada frame.
    void Update()
    {
        // Obtém os movimentos do mouse nos eixos X e Y, multiplica pela sensibilidade e pelo delta de tempo.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Atualiza a rotação vertical acumulada, subtraindo o movimento vertical do mouse.
        xRotation -= mouseY;
        // Limita a rotação no eixo X para evitar giros completos de 360 graus verticalmente.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Aplica a rotação calculada à câmera.
        // A rotação vertical (pitch) é controlada pela variável xRotation.
        // A rotação horizontal (yaw) é ajustada adicionando o movimento do mouse no eixo X diretamente ao eixo Y.
        transform.localEulerAngles = new Vector3(xRotation, transform.localEulerAngles.y + mouseX, 0f);
    }
}
