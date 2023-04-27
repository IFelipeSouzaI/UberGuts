using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public List<Transform> objectsList;
    public float followSpeed = 0.5f;
    public float moveSpeed = 0.5f;
    private Vector3[] originalPositions;

    void Start()
    {
        // Salva as posi��es originais dos objetos
        originalPositions = new Vector3[objectsList.Count];
        for (int i = 0; i < objectsList.Count; i++){
            originalPositions[i] = objectsList[i].position;
        }
    }

    void Update()
    {
        // Movimenta o objeto n0 (mais pr�ximo ao ch�o)
        Transform obj0 = objectsList[0];
        obj0.position = new Vector3(obj0.position.x + Input.GetAxis("Horizontal") * moveSpeed, obj0.position.y, obj0.position.z + Input.GetAxis("Vertical") * moveSpeed);

        // Movimenta os outros objetos
        for (int i = 1; i < objectsList.Count; i++)
        {
            Transform obj = objectsList[i];

            // Aplica atraso na movimenta��o de acordo com a posi��o do objeto na lista
            float delay = (float)(objectsList.Count - i) / objectsList.Count;
            obj.position = Vector3.Lerp(obj.position, objectsList[i - 1].position + (new Vector3(0,originalPositions[i].y,0)) * delay, Time.deltaTime * followSpeed);

            Quaternion targetRotation = Quaternion.LookRotation(obj0.position - objectsList[i - 1].position);
            obj.rotation = Quaternion.Slerp(obj.rotation, targetRotation, Time.deltaTime * followSpeed);
        }
    }
}
