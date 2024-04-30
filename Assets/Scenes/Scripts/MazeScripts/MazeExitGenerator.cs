using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe MazeExitGenerator responsável por adicionar uma saída ao labirinto.
public class MazeExitGenerator : MonoBehaviour
{
    public MazeGenerator mazeGenerator; // Referência ao componente MazeGenerator que gera o labirinto.
    public GameObject exitPrefab; // Prefab para a saída do labirinto.

    // Método para encontrar uma posição aleatória para a saída do labirinto.
    public Vector2Int FindRandomExitPosition()
    {
        bool isTopOrBottom = Random.value < 0.5f; // Decide aleatoriamente se a saída será no topo ou na base do labirinto.
        int x = 0, y = 0;

        if (isTopOrBottom)
        {
            // Se a saída for no topo ou na base, escolhe uma posição aleatória ao longo da largura do labirinto.
            x = Random.Range(0, mazeGenerator.mazeWidth);
            // Escolhe se é no topo (y=0) ou na base (y=mazeHeight-1).
            y = Random.Range(0, 2) * (mazeGenerator.mazeHeight - 1);
        }
        else
        {
            // Se a saída for na esquerda ou na direita, escolhe uma posição aleatória ao longo da altura do labirinto.
            x = Random.Range(0, 2) * (mazeGenerator.mazeWidth - 1);
            // Escolhe uma posição aleatória ao longo da altura.
            y = Random.Range(0, mazeGenerator.mazeHeight);
        }

        return new Vector2Int(x, y); // Retorna a posição da saída.
    }

    // Método para criar a saída do labirinto.
    public void CreateExit() {
        Vector2Int exitPosition = FindRandomExitPosition(); // Encontra a posição para a saída.
        Direction wallToRemove = DetermineExitWallDirection(exitPosition); // Determina qual parede deve ser removida.
        mazeGenerator.RemoveWallAt(exitPosition, wallToRemove); // Remove a parede na posição da saída.

        // Calcula a posição no mundo para a saída com base na posição na grade do labirinto.
        Vector3 exitWorldPosition = new Vector3(exitPosition.x * mazeGenerator.CellSize, 0, exitPosition.y * mazeGenerator.CellSize);
        // Instancia o prefab da saída na posição calculada.
        Instantiate(exitPrefab, exitWorldPosition, Quaternion.identity, transform);
    }

    // Método privado para determinar qual parede deve ser removida para criar a saída.
    private Direction DetermineExitWallDirection(Vector2Int exitPosition) {
        // Decide qual parede remover baseando-se na posição da saída.
        if (exitPosition.y == 0) return Direction.Down; // Se estiver na linha mais baixa, remove a parede de baixo.
        if (exitPosition.y == mazeGenerator.mazeHeight - 1) return Direction.Up; // Se estiver na linha mais alta, remove a parede de cima.
        if (exitPosition.x == 0) return Direction.Left; // Se estiver na coluna mais à esquerda, remove a parede esquerda.
        if (exitPosition.x == mazeGenerator.mazeWidth - 1) return Direction.Right; // Se estiver na coluna mais à direita, remove a parede direita.

        return Direction.Up; // Default caso nenhum dos casos acima.
    }
}
