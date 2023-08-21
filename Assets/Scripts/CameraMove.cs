using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// A simple FPP (First Person Perspective) camera rotation and movement script.
/// Like those found in most FPS (First Person Shooter) games.
/// </summary>
public class CameraMove : MonoBehaviour
{
    public float Sensitivity
    {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    [Header("Camera Movement")]
    [Range(0.1f, 9f)]
    [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)]
    [SerializeField] float yRotationLimit = 88f;
    [SerializeField] float moveSpeed = 100f; // Speed at which the camera movess


    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    [Header("Zoom")]
    [SerializeField] float zoomSpeed = 50f; // Speed at which the camera zooms
    [SerializeField] float minFOV = 20f; // Minimum field of view (zoomed in)
    [SerializeField] float maxFOV = 60f; // Maximum field of view (zoomed out)

    [Header("Skybox Materials")]
    [SerializeField] Material skyboxMaterial1; 
    [SerializeField] Material skyboxMaterial2;
    [SerializeField] Material skyboxMaterial3;
    private Material targetSkybox;


    [Header("Canvas")]
    [SerializeField] GameObject backdrop;
    [SerializeField] TextMeshProUGUI textMsg;

    private void Start()
    {
        targetSkybox = RenderSettings.skybox;
    }

    void Update()
    {
        // Camera rotation
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);
        transform.localRotation = xQuat * yQuat;

        // Camera movement
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply Y axis clamping
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;
        newPosition.y = Mathf.Max(newPosition.y, 4f); // Ensure Y position is at least 4
        transform.position = newPosition;

        // Camera zoom using scroll wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float newFOV = Camera.main.fieldOfView - scrollInput * zoomSpeed;
        newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
        Camera.main.fieldOfView = newFOV;


        // Change skybox based on input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            targetSkybox = skyboxMaterial1;
            StartCoroutine(ChangeSkyboxOverTime(targetSkybox,"Day"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            targetSkybox = skyboxMaterial2;
            StartCoroutine(ChangeSkyboxOverTime(targetSkybox, "Blend"));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            targetSkybox = skyboxMaterial3;
            StartCoroutine(ChangeSkyboxOverTime(targetSkybox, "Night"));
        }
    }

    private IEnumerator ChangeSkyboxOverTime(Material newSkybox,string msg)
    {
        textMsg.text = msg;
        float startTime = Time.time;
        float duration = 2f;
        backdrop.SetActive(true);
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            RenderSettings.skybox.Lerp(RenderSettings.skybox, newSkybox, t);
            yield return null;
        }

        RenderSettings.skybox = newSkybox;
        backdrop.SetActive(false);


    }

    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }
}
