using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse3D : MonoBehaviour
{
    #region Singleton
    public static Mouse3D Instance { get; private set;}

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private Camera mainCam;
    [SerializeField] private LayerMask collisionLayerMask;
    public Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, collisionLayerMask))
        {
            return hit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }

    
}
