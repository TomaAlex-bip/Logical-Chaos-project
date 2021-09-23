using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject bigExplosionParticles;

    [SerializeField] private float speed;

    [SerializeField] private GameObject player;

    private Rigidbody rb;




    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        player = PlayerManager.Instance.gameObject;
    }

    private void Update()
    {
        transform.LookAt(player.transform);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerManager.Instance.BigDamage();
            Instantiate(bigExplosionParticles, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
        }
    }

}
