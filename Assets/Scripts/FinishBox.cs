using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBox : MonoBehaviour
{
    public GameManager gameManager;
    Vector3 startPosition;
    Vector3 endPosition;
    MeshRenderer headMaterial;
    private void Start()
    {
        startPosition = transform.position;
        endPosition = transform.position;
        endPosition.y -= 0.65f;
        headMaterial = GetComponentInChildren<MeshRenderer>();
        Color colorRandom = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        headMaterial.material.color = colorRandom;
    }
    private void Update()
    {
        Vector3 currentBoxPos = Vector3.Lerp(startPosition, endPosition, gameManager.completePercentage * 0.01f);
        transform.position = currentBoxPos;
    }
}
