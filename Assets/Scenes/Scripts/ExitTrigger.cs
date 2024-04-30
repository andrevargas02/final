using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitTrigger : MonoBehaviour
{
    public GameObject gameTimer; // Referência ao GameTimer no Unity Inspector
    public int menuSceneIndex = 0; // Índice da cena do menu principal nas Build Settings

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Para o timer do jogo, se existir
            if (gameTimer != null)
            {
                GameTimer timer = gameTimer.GetComponent<GameTimer>();
                if (timer != null)
                {
                    timer.StopTimer();
                    PlayerPrefs.SetFloat("LastTime", timer.timer); // Salva o tempo decorrido
                }
                else
                {
                    Debug.LogError("Componente GameTimer não encontrado!");
                }
            }
            else
            {
                Debug.LogError("GameTimer não está configurado no ExitTrigger");
            }

            // Começa a carregar a cena do menu principal assincronamente pelo índice
            StartCoroutine(LoadYourAsyncScene(menuSceneIndex));
        }
    }

    IEnumerator LoadYourAsyncScene(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        // Espera até que a cena tenha terminado de carregar
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // A cena foi carregada, agora pode redefinir o Time.timeScale
    }
}
