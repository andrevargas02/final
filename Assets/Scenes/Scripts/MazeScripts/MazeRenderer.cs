// Importação dos namespaces necessários para acessar funcionalidades do Unity.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declaração da classe MazeRenderer que herda de MonoBehaviour.
public class MazeRenderer : MonoBehaviour
{
   // Referências para o gerador de labirintos e o prefab da célula do labirinto configuradas através do Unity Editor.
   [SerializeField] MazeGenerator mazeGenerator;
   [SerializeField] GameObject MazeCellPrefab;

   // Define o tamanho de cada célula no labirinto.
   public float CellSize = 1f;

   // Método Start é chamado na primeira atualização de quadro depois que o script é ativado.
   private void Start()
   {
       // Gera o labirinto chamando GetMaze do MazeGenerator e armazena em uma matriz 2D.
       MazeCell[,] maze = mazeGenerator.GetMaze();

       // Loop através de cada posição x e y na matriz do labirinto para criar células visuais.
       for (int x = 0; x < mazeGenerator.mazeWidth; x++)
       {
           for (int y = 0; y < mazeGenerator.mazeHeight; y++)
           {
               // Instancia um novo GameObject a partir do prefab da célula do labirinto,
               // posicionando-o baseado no índice da matriz e no tamanho definido da célula.
               GameObject newCell = Instantiate(MazeCellPrefab, new Vector3((float)x * CellSize, 0f, (float)y * CellSize), Quaternion.identity, transform);

               // Obtém o componente MazeCellObject do novo GameObject de célula.
               MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();

               // Lê os estados das paredes da célula atual na matriz do labirinto.
               bool top = maze[x, y].topWall;
               bool left = maze[x, y].leftWall;

               // Determina se as paredes direita e inferior devem estar presentes.
               // Isso é usado para definir paredes nas bordas do labirinto.
               bool right = false;
               bool bottom = false;

               if (x == mazeGenerator.mazeWidth - 1) right = true; // Parede direita na última coluna.
               if (y == 0) bottom = true;  // Parede inferior na primeira linha.

               // Inicializa a célula do labirinto com as informações de parede.
               mazeCell.Init(top, bottom, left, right);
           }
       }
   }
}
