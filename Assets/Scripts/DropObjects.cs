using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    private CameraMove cameraMove;

    [Header("Prefabs")]
    [SerializeField]
    private float dropDistance = 30.0f;
    [SerializeField]
    private GameObject[] prefabsObj; // Array of cube prefabs
    private int currentPrefabIndex = 0;

    [Header("Canvas")]
    [SerializeField] GameObject backdrop;
    [SerializeField] TextMeshProUGUI textMsg;


    private void Start()
    {
        cameraMove = Camera.main.GetComponent<CameraMove>();
    }

    private void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentPrefabIndex = (currentPrefabIndex + 1) % prefabsObj.Length;
            textMsg.text ="Object Changed !";
            /*float startTime = 0;
            float duration = 5f;
            backdrop.SetActive(true);
            while (startTime < duration)
            {
                startTime = startTime - 1f;
            }
            backdrop.SetActive(false);*/
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dropPosition = cameraMove.transform.position + cameraMove.transform.forward * dropDistance;
            Instantiate(prefabsObj[currentPrefabIndex], dropPosition, Quaternion.identity);
        }
    }
}
