using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe MazeGenerator responsável por gerar o labirinto.

public class MazeGenerator : MonoBehaviour
{
    [Range(5, 500)]
    public int mazeWidth = 5, mazeHeight = 5;
    public int startX, startY;
    MazeCell[,] maze;
    Vector2Int currentCell;
    public bool rightWall, bottomWall;
    public float CellSize = 1f;

    // Lista das direções possíveis para a geração do labirinto.
    private List<Direction> directions = new List<Direction> { Direction.Up, Direction.Down, Direction.Left, Direction.Right };

    public MazeCell[,] GetMaze()
    {
        maze = new MazeCell[mazeWidth, mazeHeight];

        for (int x = 0; x < mazeWidth; x++)
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                maze[x, y] = new MazeCell(x, y);
            }
        }

        CarvePath(startX, startY);
        return maze;
    }

    List<Direction> GetRandomDirections()
    {
        List<Direction> dir = new List<Direction>(directions);
        List<Direction> rndDir = new List<Direction>();

        while (dir.Count > 0)
        {
            int rnd = Random.Range(0, dir.Count);
            rndDir.Add(dir[rnd]);
            dir.RemoveAt(rnd);
        }

        return rndDir;
    }

    bool IsCellValid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < mazeWidth && y < mazeHeight && !maze[x, y].visited;
    }

    Vector2Int CheckNeighbours()
    {
        List<Direction> rndDir = GetRandomDirections();

        foreach (var direction in rndDir)
        {
            Vector2Int neighbour = currentCell;

            switch (direction)
            {
                case Direction.Up:
                    neighbour.y++;
                    break;
                case Direction.Down:
                    neighbour.y--;
                    break;
                case Direction.Right:
                    neighbour.x++;
                    break;
                case Direction.Left:
                    neighbour.x--;
                    break;
            }

            if (IsCellValid(neighbour.x, neighbour.y))
                return neighbour;
        }

        return currentCell;
    }

    void BreakWalls(Vector2Int primaryCell, Vector2Int secondaryCell)
    {
        if (primaryCell.x > secondaryCell.x)
        {
            maze[primaryCell.x, primaryCell.y].leftWall = false;
        }
        else if (primaryCell.x < secondaryCell.x)
        {
            maze[secondaryCell.x, secondaryCell.y].leftWall = false;
        }
        else if (primaryCell.y < secondaryCell.y)
        {
            maze[primaryCell.x, primaryCell.y].topWall = false;
        }
        else if (primaryCell.y > secondaryCell.y)
        {
            maze[secondaryCell.x, secondaryCell.y].topWall = false;
        }
    }

    void CarvePath(int x, int y)
    {
        if (x < 0 || y < 0 || x >= mazeWidth || y >= mazeHeight)
        {
            x = y = 0;
            Debug.LogWarning("Starting position is out of bounds, defaulting to 0,0");
        }

        currentCell = new Vector2Int(x, y);
        List<Vector2Int> path = new List<Vector2Int>();
        bool deadEnd = false;

        while (!deadEnd)
        {
            Vector2Int nextCell = CheckNeighbours();
            if (nextCell == currentCell)
            {
                if (path.Count == 0)
                    deadEnd = true;
                else
                {
                    currentCell = path[path.Count - 1];
                    path.RemoveAt(path.Count - 1);
                }
            }
            else
            {
                BreakWalls(currentCell, nextCell);
                maze[currentCell.x, currentCell.y].visited = true;
                currentCell = nextCell;
                path.Add(currentCell);
            }
        }
    }

    // Retorna a posição inicial para gerar objetos na cena.
    public Vector3 GetSpawnPosition(float cellSize, float height)
    {
        return new Vector3(startX * cellSize, height, startY * cellSize);
    }

    // Remove uma parede específica em uma posição dada.
    public void RemoveWallAt(Vector2Int position, Direction wall)
    {
        if (position.x < 0 || position.x >= mazeWidth || position.y < 0 || position.y >= mazeHeight)
            return;

        switch (wall)
        {
            case Direction.Up:
                maze[position.x, position.y].topWall = false;
                if (position.y < mazeHeight - 1)
                    maze[position.x, position.y + 1].bottomWall = false;
                break;
            case Direction.Down:
                maze[position.x, position.y].bottomWall = false;
                if (position.y > 0)
                    maze[position.x, position.y - 1].topWall = false;
                break;
            case Direction.Right:
                maze[position.x, position.y].rightWall = false;
                if (position.x < mazeWidth - 1)
                    maze[position.x + 1, position.y].leftWall = false;
                break;
            case Direction.Left:
                maze[position.x, position.y].leftWall = false;
                if (position.x > 0)
                    maze[position.x - 1, position.y].rightWall = false;
                break;
        }
    }
}

// Enumeração das direções possíveis para movimentação no labirinto.
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

// Classe que representa cada célula no labirinto.
public class MazeCell
{
    public bool visited;  // Flag para indicar se a célula foi visitada.
    public int x, y;  // Coordenadas da célula.
    public bool topWall;  // Estado da parede superior.
    public bool leftWall;  // Estado da parede esquerda.
    public bool rightWall = true;  // Estado inicial da parede direita.
    public bool bottomWall = true;  // Estado inicial da parede inferior.
    public Vector2Int position  // Propriedade para obter a posição da célula como Vector2Int.
    {
        get
        {
            return new Vector2Int(x, y);
        }
    }

    // Construtor para inicializar a célula com coordenadas e estado inicial das paredes.
    public MazeCell(int x, int y)
    {
        this.x = x;
        this.y = y;
        visited = false;
        topWall = leftWall = true; // Paredes inicializadas como presentes.
    }
}
