using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{

    public static TargetBehaviour Instance { get; private set; }



    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Camera cam;

    [SerializeField] private float yOffset;


    private Vector3 desiredPosition;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance!=this)
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 100, layerMask))
        {
            desiredPosition = raycastHit.point + new Vector3(0f, yOffset);
        }
    }


    private void FixedUpdate()
    {
        transform.position = desiredPosition;
    }
}
