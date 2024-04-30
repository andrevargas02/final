using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Vector3 spawnPosition;

    void Awake()
    {
        // Configura a posição de spawn para a posição inicial deste objeto
        spawnPosition = transform.position;
    }
}