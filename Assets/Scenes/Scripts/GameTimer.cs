// Importações necessárias para usar funcionalidades do Unity.
using System.Collections;
using UnityEngine;
using TMPro;  // Namespace necessário para acessar funcionalidades do TextMeshPro.

// Declaração da classe GameTimer que herda de MonoBehaviour, permitindo que este script seja anexado a um GameObject.
public class GameTimer : MonoBehaviour
{
    // Variável pública para referenciar o componente de texto onde o tempo será exibido.
    public TextMeshProUGUI timerDisplay;

    // Propriedade para armazenar e acessar o valor do tempo. O set é privado para controlar onde o tempo pode ser modificado.
    public float timer { get; private set; }

    // Variável booleana para controlar se o cronômetro está ativo ou não.
    private bool timerRunning = false;

    // Método público para iniciar o cronômetro.
    public void StartTimer()
    {
        timer = 0f;  // Inicializa o cronômetro com 0.
        timerRunning = true;  // Ativa a execução do cronômetro.
        timerDisplay.gameObject.SetActive(true);  // Ativa o objeto de texto para mostrar o cronômetro na UI.
    }

    // Método público para parar o cronômetro.
    public void StopTimer()
    {
        timerRunning = false;  // Desativa a execução do cronômetro.
        timerDisplay.gameObject.SetActive(false);  // Desativa o objeto de texto, ocultando o cronômetro na UI.
    }

    // Método Update é chamado uma vez por quadro.
    private void Update()
    {
        // Verifica se o cronômetro está ativo.
        if (timerRunning)
        {
            // Incrementa o cronômetro com o tempo decorrido desde o último quadro.
            timer += Time.deltaTime;
            // Atualiza o texto do componente UI para mostrar o tempo decorrido, formatado com duas casas decimais.
            timerDisplay.text = $"Time: {timer:F2}s";
        }
    }
}
