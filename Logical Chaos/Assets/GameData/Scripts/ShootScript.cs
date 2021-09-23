using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{


    [SerializeField] private GameObject projectile;

    [SerializeField] private float reloadTime;

    [SerializeField] private bool reloaded;

    private GunInput gunInput;


    private void Awake()
    {
        reloaded = true;

        gunInput = transform.GetComponent<GunInput>();
    }

    private void Update()
    {
        if(Time.timeScale != 0)
        {
            if(gunInput.Shoot)
            {
                gunInput.Shoot = false;
                Shoot();
            }
        }

    }


    private GameObject Shoot()
    {
        if(reloaded)
        {
            reloaded = false;
            SoundManager.Instance.PlaySound("Shoot");
            StartCoroutine(Reload());
            return Instantiate(projectile, transform.position, transform.rotation);
        }

        return null;
    }


    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloaded = true;
    }

}
