using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe MazeCellObject que gerencia as paredes de uma célula do labirinto.
public class MazeCellObject : MonoBehaviour
{
    // Referências para os objetos das paredes, configuradas através do Unity Editor.
    // Estas paredes são GameObjects que podem ser ativadas ou desativadas.
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject bottomWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject leftWall;

    // Método público que inicializa a visibilidade das paredes da célula.
    // Cada parâmetro bool representa se uma parede específica deve estar visível ou não.
    public void Init(bool top, bool bottom, bool left, bool right)
    {
        // Ativa ou desativa a parede superior dependendo do valor do parâmetro 'top'.
        topWall.SetActive(top);
        // Ativa ou desativa a parede inferior dependendo do valor do parâmetro 'bottom'.
        bottomWall.SetActive(bottom);
        // Ativa ou desativa a parede direita dependendo do valor do parâmetro 'right'.
        rightWall.SetActive(right);
        // Ativa ou desativa a parede esquerda dependendo do valor do parâmetro 'left'.
        leftWall.SetActive(left);
    }
}
