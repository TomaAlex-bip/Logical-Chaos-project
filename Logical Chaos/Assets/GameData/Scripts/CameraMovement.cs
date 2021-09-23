using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    [SerializeField] private GameObject follow;

    [SerializeField] private float speed;

    private Vector3 offset;
    private Vector3 positionToGo;


    private void Start()
    {
        offset = transform.position - follow.transform.position;
    }

    private void Update()
    {
        positionToGo = follow.transform.position + offset;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, positionToGo, speed * Time.fixedDeltaTime);
    }

}
