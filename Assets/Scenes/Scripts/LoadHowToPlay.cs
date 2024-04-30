using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHowToPlay : MonoBehaviour
{
    public int sceneIndex;  // Índice da cena para carregar

    public void LoadScene()
    {
        SceneManager.LoadScene(2);  // Carrega a cena com base no índice fornecido
    }
}
