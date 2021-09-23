using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public static PlayerManager Instance { get; private set; }

    public int Hitpoints { get; private set; }

    public bool GameIsOver { get; private set; }

    [SerializeField] private int maxHP;

    [SerializeField] private Animator gameOverAnim;

    [SerializeField] private GameObject hud;

    [SerializeField] private Text finalScoreText;

    [SerializeField] private CameraShake cameraShake;

    


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        Hitpoints = maxHP;


    }




    private void Update()
    {
        CheckHitpoints();
    }



    private void CheckHitpoints()
    {
        if (Hitpoints > maxHP)
        {
            Hitpoints = maxHP;
        }
        if (Hitpoints <= 0)
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        GameIsOver = true;

        finalScoreText.text = "SCORE: " + GameManager.Instance.Score.ToString();

        var spawner = SpawnerScript.Instance.gameObject;
        spawner.SetActive(false);

        transform.gameObject.SetActive(false);

        var target = TargetBehaviour.Instance.gameObject;
        target.SetActive(false);

        hud.SetActive(false);

        gameOverAnim.SetTrigger("PopUp");

        


    }

    public void Heal()
    {
        Hitpoints++;
        SoundManager.Instance.PlaySound("Heal");
    }

    public void Damage()
    {
        StartCoroutine(cameraShake.Shake(0.15f, 1f));
        Hitpoints -= 2;
        SoundManager.Instance.PlaySound("SmallExplosion");
    }

    public void BigDamage()
    {
        StartCoroutine(cameraShake.Shake(0.25f, 2f));
        Hitpoints -= 5;
        SoundManager.Instance.PlaySound("BigExplosion");
    }
}
