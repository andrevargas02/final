// Necessário para utilizar funcionalidades do Unity como MonoBehaviour, SceneManager, e classes de UI como TextMeshProUGUI.
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Declaração da classe MenuController, que gerencia o comportamento do menu no jogo.
public class MenuController : MonoBehaviour
{
    // Campo público para conectar o componente TextMeshProUGUI via Unity Editor.
    // Este componente é usado para exibir o tempo de jogo.
    public TextMeshProUGUI timeDisplay;

    // Método Start é chamado na primeira atualização de quadro após o objeto ser ativado.
    private void Start()
    {
        // Recupera o tempo salvo das preferências do jogador (PlayerPrefs), padrão para 0 se não estiver definido.
        float lastTime = PlayerPrefs.GetFloat("LastTime", 0);
        
        // Atualiza o texto do componente timeDisplay para mostrar o tempo decorrido formatado para duas casas decimais.
        timeDisplay.text = $"Tempo: {lastTime:F2} segundos";
    }

    // Método público que pode ser vinculado a um botão no Unity Editor para reiniciar o jogo.
    public void RestartGame()
    {
        // Carrega a cena chamada "GameScene", que deve ser o nome da sua cena de jogo principal.
        SceneManager.LoadScene("GameScene");
        
        // Define Time.timeScale para 1, garantindo que o jogo não esteja pausado ao reiniciar.
        Time.timeScale = 1f;
    }

    // Método público que pode ser vinculado a um botão no Unity Editor para sair do jogo.
    public void QuitGame()
    {
        // Fecha a aplicação. Este comando tem efeito apenas em builds finais, não no editor do Unity.
        Application.Quit();
    }
}
