using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    private CameraMove cameraMove;
    [SerializeField]
    private GameObject cubePrefab; 

    [SerializeField]
    private float dropDistance = 30.0f;

    private void Start()
    {
        cameraMove = Camera.main.GetComponent<CameraMove>();
    }

    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            // Get the camera's forward direction and calculate a drop position
            Vector3 dropPosition = cameraMove.transform.position + cameraMove.transform.forward * dropDistance;

            // Instantiate the cube prefab at the calculated drop position
            Instantiate(cubePrefab, dropPosition, Quaternion.identity);
        }
    }
}
