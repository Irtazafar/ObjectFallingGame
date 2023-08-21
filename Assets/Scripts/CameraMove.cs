using UnityEngine;

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

    [Range(0.1f, 9f)]
    [SerializeField] float sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)]
    [SerializeField] float yRotationLimit = 88f;

    [SerializeField] float moveSpeed = 100f; // Speed at which the camera moves

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

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
        newPosition.y = Mathf.Max(newPosition.y, 4f); // Ensure Y position is at least 2
        transform.position = newPosition;
    }

    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }
}
