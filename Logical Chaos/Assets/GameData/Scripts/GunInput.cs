using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInput : MonoBehaviour
{
    public bool Shoot { get; set; }

    private bool isPlayer;

    private EnemyBehaviour enemyBehaviour;


    private void Awake()
    {
        if(CompareTag("Player"))
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
            enemyBehaviour = transform.parent.parent.parent.GetComponent<EnemyBehaviour>();
        }
    }

    private void Update()
    {
        if(isPlayer)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot = true;
            }
        }
        else if(enemyBehaviour != null)
        {
            if(enemyBehaviour.ReadyToShoot)
            {
                Shoot = true;
            }
        }
    }
}
