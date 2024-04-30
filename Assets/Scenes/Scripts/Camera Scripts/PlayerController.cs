using UnityEngine;

// Classe PlayerController herda de MonoBehaviour, o que permite que seja anexada a um GameObject.
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // Velocidade de movimento do jogador.
    public bool canMove = true; // Variável que controla se o jogador pode se mover ou não.
    private Rigidbody rb;  // Componente Rigidbody que será utilizado para aplicar física.

    // Método Start é chamado quando o script é inicialmente ativado.
    void Start()
    {
        // Obtém o componente Rigidbody do GameObject ao qual este script está anexado.
        rb = GetComponent<Rigidbody>();
    }

    // Método FixedUpdate é chamado em intervalos regulares de tempo, sendo mais consistente que Update para códigos de física.
    void FixedUpdate()
    {
        // Verifica se o jogador pode se mover. Se não, interrompe a execução do método aqui.
        if (!canMove) return;

        // Captura o input horizontal (A, D, seta esquerda, seta direita)
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Captura o input vertical (W, S, seta para cima, seta para baixo)
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula a direção do movimento baseando-se na orientação da câmera principal do jogo.
        // Isso faz com que o movimento seja sempre relativo à direção para onde a câmera está apontando.
        Vector3 direction = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;
        direction.y = 0; // Neutraliza o componente vertical da direção para manter o movimento no plano horizontal.

        // Aplica uma força ao Rigidbody que move o jogador na direção calculada, multiplicada pela velocidade de movimento.
        rb.AddForce(direction.normalized * moveSpeed);
    }
}
