using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    private CameraMove cameraMove;
    [SerializeField]
    private GameObject cubePrefab; // Reference to the cube prefab

    [SerializeField]
    private float dropDistance = 30.0f; // Distance in front of the camera to drop the object

    private void Start()
    {
        cameraMove = Camera.main.GetComponent<CameraMove>();
    }

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the camera's forward direction and calculate a drop position
            Vector3 dropPosition = cameraMove.transform.position + cameraMove.transform.forward * dropDistance;

            // Instantiate the cube prefab at the calculated drop position
            Instantiate(cubePrefab, dropPosition, Quaternion.identity);
        }
    }
}
