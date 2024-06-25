using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGame : MonoBehaviour
{
    [SerializeField] private float cameraHeight;
    [SerializeField] private Transform playerBody;
    private Vector3 cameraTarget;

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cameraTarget = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + cameraHeight, playerBody.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
        Vector3 point = Mouse3D.Instance.GetMouseWorldPos();
        playerBody.LookAt(new Vector3(point.x, playerBody.position.y, point.z));
    }

}
