using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public int sceneIndex;  // Índice da cena para carregar, conforme listado em Build Settings

    public void LoadScene()
    {
        SceneManager.LoadScene(0);  // Carrega a cena com base no índice fornecido
    }
}
