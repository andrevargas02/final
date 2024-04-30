using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Declaração da classe CameraFollow, que herda de MonoBehaviour.
public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera deve seguir, configurável no Unity Editor.
    public Vector3 offset; // O deslocamento (distância e direção) da câmera em relação ao alvo, configurável no Unity Editor.
    public bool lookAtTarget = true; // Define se a câmera deve sempre estar orientada para olhar para o alvo.

    // Método LateUpdate é chamado uma vez a cada quadro, depois do Update em outros scripts.
    // Isso garante que a câmera só se mova após o alvo ter completado seu movimento.
    private void LateUpdate()
    {
        // Atualiza a posição da câmera. A nova posição é a posição do alvo mais o deslocamento definido.
        transform.position = target.position + offset;

        // Se lookAtTarget for verdadeiro, faz a câmera olhar diretamente para o alvo.
        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}
