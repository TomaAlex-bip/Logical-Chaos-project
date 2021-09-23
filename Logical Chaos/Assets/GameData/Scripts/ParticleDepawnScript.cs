using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDepawnScript : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(Despawn());
    }


    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
