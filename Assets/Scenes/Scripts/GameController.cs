// Importações necessárias de namespaces para acessar funcionalidades de UI, controle de cena, etc.
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Define a classe GameController, que é derivada de MonoBehaviour.
public class GameController : MonoBehaviour
{
    // Variáveis públicas que podem ser configuradas no Unity Editor.
    public int countdownTime = 3; // Tempo inicial da contagem regressiva.
    public TextMeshProUGUI countdownDisplay; // Componente de texto para exibir a contagem regressiva.
    public GameObject victoryPanel; // Painel exibido ao final do jogo.
    public PlayerController playerController; // Referência ao controlador do jogador.
    public GameTimer gameTimer; // Referência ao cronômetro do jogo.

    // Método Start é chamado ao iniciar o script.
    private void Start()
    {
        // Verifica se todas as referências necessárias estão configuradas.
        if (countdownDisplay == null || victoryPanel == null || playerController == null || gameTimer == null)
        {
            Debug.LogError("GameController: Missing component references in the inspector!");
            return; // Sai do método se algo não estiver configurado.
        }

        victoryPanel.SetActive(false); // Desativa o painel de vitória inicialmente.
        playerController.canMove = false; // Impede que o jogador se mova antes do jogo começar.
        StartCoroutine(CountdownToStart()); // Inicia a corrotina da contagem regressiva.
    }

    // Corrotina que controla a contagem regressiva antes do jogo começar.
    IEnumerator CountdownToStart()
    {
        countdownDisplay.gameObject.SetActive(true); // Ativa o display de contagem regressiva.

        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString(); // Atualiza o texto do contador.
            yield return new WaitForSecondsRealtime(1f); // Espera um segundo em tempo real.
            countdownTime--; // Decrementa o contador.
        }

        countdownDisplay.text = "GO"; // Muda o texto para "GO" ao final da contagem.
        yield return new WaitForSecondsRealtime(1f); // Espera mais um segundo.
        countdownDisplay.gameObject.SetActive(false); // Desativa o display de contagem regressiva.

        gameTimer.StartTimer(); // Inicia o cronômetro do jogo.
        playerController.canMove = true; // Permite que o jogador comece a se mover.
    }

    // Método chamado para terminar o jogo.
    public void EndGame()
    {
        playerController.canMove = false; // Impede movimento do jogador.
        Time.timeScale = 0f; // Pausa o jogo.
        victoryPanel.SetActive(true); // Ativa o painel de vitória.
        gameTimer.StopTimer(); // Para o cronômetro.
        Debug.Log("Game Ended: Player has won!"); // Mensagem de log.
    }

    // Método para reiniciar o jogo.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual.
        Time.timeScale = 1f; // Restaura a velocidade normal do jogo.
    }

    // Método para sair do jogo.
    public void QuitGame()
    {
        Application.Quit(); // Fecha o aplicativo.
    }
}
