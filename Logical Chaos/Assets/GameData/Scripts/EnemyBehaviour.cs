using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public bool ReadyToShoot { get; private set; }

    [SerializeField] private string enemyType;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    [SerializeField] private float minDistanceToShoot;
    [SerializeField] private float minDistanceToTarget;

    //[SerializeField] private bool taunted;
    [SerializeField] private bool hasArrived;

    private Vector3 nextPosition;

    private GameObject player;
    private GameObject mesh;
    
    private GameObject targetRotation;
    private GameObject nextPositionRotation;

    private Rigidbody rb;

    private float distance;


    private void Awake()
    {
        hasArrived = true;

        player = PlayerManager.Instance.gameObject;

        mesh = transform.Find("EnemyMesh").gameObject;

        targetRotation = transform.Find("TargetRotation").gameObject;
        nextPositionRotation = transform.Find("NextPositionRotation").gameObject;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
        MoveForward();
        LookAtTarget();
    }


    private void Update()
    {
        CalculateDistance();

        CalculateNextPosition();

        FireAtTarget();
    }

    private void LookAtTarget()
    {
        if(distance <= minDistanceToTarget)
        {
            targetRotation.transform.LookAt(player.transform);
        }
        else
        {
            targetRotation.transform.rotation = transform.rotation;
        }

        mesh.transform.rotation = Quaternion.RotateTowards(mesh.transform.rotation, targetRotation.transform.rotation, rotationSpeed * Time.fixedDeltaTime);

    }
    private void FireAtTarget()
    {
        float yRotDifference = Mathf.Abs(Mathf.Abs(mesh.transform.rotation.eulerAngles.y) - Mathf.Abs(targetRotation.transform.rotation.eulerAngles.y));


        if(distance <= minDistanceToShoot && yRotDifference < 25f)
        {
            ReadyToShoot = true;
        }
        else
        {
            ReadyToShoot = false;
        }
    }

    private void CalculateDistance() => distance = Vector3.Distance(transform.position, player.transform.position);

    private void MoveForward() => rb.velocity = transform.forward * movementSpeed * Time.fixedDeltaTime;

    private void Rotate()
    {
        nextPositionRotation.transform.LookAt(nextPosition);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, nextPositionRotation.transform.rotation, rotationSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextPositionRotation.transform.rotation, 2 * Time.fixedDeltaTime);
    }

    private void CalculateNextPosition()
    {
        if(hasArrived)
        {
            hasArrived = false;
            if(UnityEngine.Random.Range(0f, 1f) <= 0.3f)
            {
                nextPosition = player.transform.position;
            }
            else
            {
                nextPosition = RandomNextPosition();
            }
        }
            
        if(Vector3.Distance(transform.position, nextPosition) < 3f)
        {
            hasArrived = true;
        }

    }

    private Vector3 RandomNextPosition() => new Vector3(UnityEngine.Random.Range(minPosition.x, maxPosition.x),
                                                        transform.position.y,
                                                        UnityEngine.Random.Range(minPosition.y, maxPosition.y));
    


}
