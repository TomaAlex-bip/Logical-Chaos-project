using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehaviour : Projectile
{
    [SerializeField] private GameObject redExplosionParticles;
    [SerializeField] private GameObject greenExplosionParticles;
    [SerializeField] private GameObject blueExplosionParticles;
    [SerializeField] private GameObject bigExplosionParticles;
    [SerializeField] private GameObject defaultParticles;

    [SerializeField] private GameObject scoreTextPopUp;

    [SerializeField] private CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RedEnemy"))
        {
            spawner.enemyTypes[0]--;

            if(gameManager.WaveColor == "red")
            {
                gameManager.Score += 50;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f,0f,0f));
                s.GetComponent<PointsScript>().SetScoreText(50);
            }
            else
            {
                gameManager.Score += 100;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
                s.GetComponent<PointsScript>().SetScoreText(100);
            }

            Instantiate(redExplosionParticles, other.transform.position, Quaternion.Euler(-90, 0, 0));
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            SoundManager.Instance.PlaySound("EnemyDestroyed");
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("GreenEnemy"))
        {
            spawner.enemyTypes[1]--;

            if (gameManager.WaveColor == "green")
            {
                gameManager.Score += 50;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
                s.GetComponent<PointsScript>().SetScoreText(50);
            }
            else
            {
                gameManager.Score += 100;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
                s.GetComponent<PointsScript>().SetScoreText(100);
            }

            Instantiate(greenExplosionParticles, other.transform.position, Quaternion.Euler(-90, 0, 0));
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySound("EnemyDestroyed");
        }
        else if(other.CompareTag("BlueEnemy"))
        {
            spawner.enemyTypes[2]--;

            if (gameManager.WaveColor == "blue")
            {
                gameManager.Score += 50;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
                s.GetComponent<PointsScript>().SetScoreText(50);
            }
            else
            {
                gameManager.Score += 100;
                var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
                s.GetComponent<PointsScript>().SetScoreText(100);
            }

            Instantiate(blueExplosionParticles, other.transform.position, Quaternion.Euler(-90, 0, 0));
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySound("EnemyDestroyed");
        }
        else if(other.CompareTag("BombEnemy"))
        {
            gameManager.Score += 100;
            var s = Instantiate(scoreTextPopUp, transform.position, Quaternion.Euler(90f, 0f, 0f));
            s.GetComponent<PointsScript>().SetScoreText(100);

            Instantiate(bigExplosionParticles, other.transform.position, Quaternion.Euler(-90, 0, 0));
            StartCoroutine(cameraShake.Shake(0.2f, 0.6f));
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySound("EnemyDestroyed");
        }
        else
        {
            Instantiate(defaultParticles, transform.position, Quaternion.Euler(-90, 0, 0));
        }

        Destroy(gameObject);
    }

}
