
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string WaveColor { get; private set; }

    public int Score { get; set; }

    [SerializeField] private int minSecondsWave;
    [SerializeField] private int maxSecondsWave;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text countdownText;
    [SerializeField] private Text timerText;
    [SerializeField] private Image colorImage;
    [SerializeField] private Image colorVignette;
    [SerializeField] private Slider healthBar;

    //[SerializeField] private Texture2D cursorImg;

    [SerializeField] private GameObject colorEffect;

    [SerializeField] private Animator pauseAnim;

    private Image colorEffectImage;

    private Animator colorEffectAnim;

    private int timer;
    private int countdownTimer;

    private PlayerManager playerManager;
    private SpawnerScript spawner;

    private bool gameIsPaused;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        Init();

    }
    private void Init()
    {
        countdownTimer = 3;
        Time.timeScale = 0;
        StartCoroutine(StartCountdown());

        //Cursor.SetCursor(cursorImg, new Vector2(128, 128), CursorMode.ForceSoftware);

        colorEffectImage = colorEffect.GetComponent<Image>();
        colorEffectAnim = colorEffect.GetComponent<Animator>();
        timer = 0;
        StartCoroutine(StartTimer());
    }

    private void Start()
    {
        playerManager = PlayerManager.Instance;
        spawner = SpawnerScript.Instance;
    }



    private void Update()
    {
        if(countdownTimer <= 0)
        {
            UpdateSlider();

            CheckTimer();

            CheckIfPause();

            scoreText.text = Score.ToString();

            timerText.text = timer.ToString();

            if(gameIsPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        }

        
        

    }


    private void CheckTimer()
    {
        if(timer < 0 && !playerManager.GameIsOver)
        {
            timer = UnityEngine.Random.Range(minSecondsWave, maxSecondsWave);
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        if(WaveColor == "red")
        {
            Score += 100 * spawner.enemyTypes[0];
            Score -= 25 * (spawner.enemyTypes[1] + spawner.enemyTypes[2]);
        }
        else if(WaveColor == "green")
        {
            Score += 100 * spawner.enemyTypes[1];
            Score -= 25 * (spawner.enemyTypes[0] + spawner.enemyTypes[2]);
        }
        else if(WaveColor == "blue")
        {
            Score += 100 * spawner.enemyTypes[2];
            Score -= 25 * (spawner.enemyTypes[1] + spawner.enemyTypes[0]);
        }

        var rng = Random.Range(0f, 1f);
        if (rng <= 0.3f)
        {
            WaveColor = "red";
            colorImage.color = Color.red;
            colorEffectImage.color = Color.red;
            colorVignette.color = Color.red;
        }
        else if(rng <= 0.6f)
        {
            WaveColor = "green";
            colorImage.color = Color.green;
            colorEffectImage.color = Color.green;
            colorVignette.color = Color.green;
        }
        else
        {
            WaveColor = "blue";
            colorImage.color = Color.blue;
            colorEffectImage.color = Color.blue;
            colorVignette.color = Color.blue;
        }

        colorEffectAnim.SetTrigger("effectOn");

        SoundManager.Instance.PlaySound("ColorChangeSound");
    
    }

    private IEnumerator StartTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timer--;
            Score++;
        }
    }



    private void UpdateSlider() => healthBar.value = playerManager.Hitpoints;


    //public void RestartLevel() => SceneManager.LoadScene(0);


    private IEnumerator StartCountdown()
    {
        while(countdownTimer >= 0)
        {
            SoundManager.Instance.PlaySound("321");
            yield return new WaitForSecondsRealtime(1);
            countdownTimer--;
            countdownText.text = countdownTimer.ToString();
        }
        Destroy(countdownText.gameObject.transform.parent.gameObject);
        Time.timeScale = 1;
    }


    private void CheckIfPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchPauseState();
        }
    }


    public void SwitchPauseState()
    {
        gameIsPaused = !gameIsPaused;
        pauseAnim.SetTrigger("pop");
    }







}
