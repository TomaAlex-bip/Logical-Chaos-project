using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float speed;

    private Transform arm;

    private Rigidbody rb;

    private float vertical;
    private float horizontal;



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        arm = transform.Find("Gun");
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate()
    {
        Rotate(transform);
        Rotate(arm);
        rb.velocity = new Vector3(horizontal, 0.0f, vertical) * speed * Time.fixedDeltaTime;
    }
    
    
    private void Rotate(Transform transform)
    {
        transform.LookAt(target);
        Quaternion rot = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        transform.rotation = rot;
    }

    
}
