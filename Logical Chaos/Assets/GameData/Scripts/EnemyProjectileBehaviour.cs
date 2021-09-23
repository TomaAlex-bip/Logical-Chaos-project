using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileBehaviour : Projectile
{
    [SerializeField] private GameObject healParticles;
    [SerializeField] private GameObject damageParticles;

    [SerializeField] private string projectileType;

    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = PlayerManager.Instance;
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            switch(gameManager.WaveColor)
            {
                case "red":
                    if(projectileType == "red")
                    {
                        playerManager.Heal();
                        Instantiate(healParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    else
                    {
                        playerManager.Damage();
                        Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    break;

                case "green":
                    if (projectileType == "green")
                    {
                        playerManager.Heal();
                        Instantiate(healParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    else
                    {
                        playerManager.Damage();
                        Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    break;

                case "blue":
                    if (projectileType == "blue")
                    {
                        playerManager.Heal();
                        Instantiate(healParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    else
                    {
                        playerManager.Damage();
                        Instantiate(damageParticles, transform.position, Quaternion.Euler(-90, 0, 0));
                    }
                    break;
            }

        }

        //instantiate particles
        
        Destroy(gameObject);
    }
}
