using UnityEngine;

public class TeleportToSpawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleporta o jogador para a posição de spawn
            other.transform.position = SpawnPoint.spawnPosition;
        }
    }
}
