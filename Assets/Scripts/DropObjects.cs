using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    private CameraMove cameraMove;
    [SerializeField]
    private GameObject cubePrefab; // Reference to the cube prefab

    private void Start()
    {
        cameraMove = Camera.main.GetComponent<CameraMove>();
    }
    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get the current mouse position in the scene
            Vector3 mousePosition = cameraMove.GetMousePosition();
            //mousePosition.z = 0f; // Set the z-coordinate to 0 to ensure the cube is placed on the ground

            // Instantiate the cube prefab at the mouse position
            Instantiate(cubePrefab, mousePosition, Quaternion.identity);
        }
    }
}
