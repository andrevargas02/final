using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe CameraCollision que herda de MonoBehaviour.
public class CameraCollision : MonoBehaviour
{
    public Transform target; // O objeto que a câmera deve seguir.
    public float distanceFromTarget = 3.0f; // Distância desejada da câmera até o alvo.
    public Vector3 offset; // Offset adicional para a posição da câmera.
    public float collisionBuffer = 0.3f; // Buffer para evitar que a câmera penetre visualmente em objetos ao colidir.

    // Método LateUpdate é chamado uma vez por frame, após a atualização de todos os Updates.
    private void LateUpdate()
    {
        // Calcula a posição desejada da câmera com base na posição do alvo e no offset.
        Vector3 desiredPosition = target.position + offset;
        
        // Variável para armazenar informações sobre um possível impacto de um raio lançado.
        RaycastHit hit;

        // Lança um raio da posição do alvo na direção da posição desejada da câmera. 
        // Se houver um objeto entre o alvo e a posição desejada, detecta a colisão.
        if (Physics.Raycast(target.position, desiredPosition - target.position, out hit, distanceFromTarget))
        {
            // Se houver uma colisão, ajusta a posição da câmera para o ponto de impacto, 
            // recuando um pouco baseado no normal do ponto de impacto para evitar sobreposição visual.
            transform.position = hit.point - (hit.normal * collisionBuffer);
        }
        else
        {
            // Se não houver colisão, simplesmente coloca a câmera na posição desejada.
            transform.position = desiredPosition;
        }
    }
}
