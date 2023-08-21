using System.Collections;
using UnityEngine;

public class Robot : MonoBehaviour
{
    [SerializeField]
    public Transform plane; 

    [SerializeField]
    public float moveSpeed = 50f; 

    [SerializeField]
    public float rotationSpeed = 90f;


    //THIS SCRIPTS MOVES THE ROBOT IN ANY DIRECTION WITH ROTATION. 

    /*private Vector3 minPosition;
    private Vector3 maxPosition;

    private Vector3 targetPosition; // Target position for the robot's movement

    private void Start()
    {
        // Get the boundaries of the plane's collider
        Collider planeCollider = plane.GetComponent<Collider>();
        minPosition = planeCollider.bounds.min + Vector3.up;
        maxPosition = planeCollider.bounds.max - Vector3.up;

        StartCoroutine(MoveRobot());
    }

    private IEnumerator MoveRobot()
    {
        while (true)
        {
            // Calculate a random target position within the plane's bounds
            targetPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                1f,
                Random.Range(minPosition.z, maxPosition.z)
            );

            // Rotate the robot to face the target position
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);
            while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

            // Move the robot to the target position
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Wait for a short time before the next movement
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }*/

    //THIS MOVES THE ROBOT WITHIN THE PLANE AND MAKES SURE THAT THE ROBOT FACE IS TOWARDS THAT LOCATION WHERE 
    private Vector3 minPosition;
    private Vector3 maxPosition;

    private Vector3 targetPosition; // Target position for the robot's movement

    private void Start()
    {
        Collider planeCollider = plane.GetComponent<Collider>();
        minPosition = planeCollider.bounds.min + Vector3.up;
        maxPosition = planeCollider.bounds.max - Vector3.up;

        StartCoroutine(MoveRobot());
    }

    private IEnumerator MoveRobot()
    {
        while (true)
        {
            
            targetPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                1f,
                Random.Range(minPosition.z, maxPosition.z)
            );

            
            Vector3 directionToTarget = targetPosition - transform.position;

            
            Quaternion targetRotation = Quaternion.LookRotation(-directionToTarget, Vector3.up);
            while (Quaternion.Angle(transform.rotation, targetRotation) > 1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }

           
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

          
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }

}
