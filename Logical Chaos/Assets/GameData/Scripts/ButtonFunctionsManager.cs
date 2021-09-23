using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorImg;

    private void Awake()
    {
        Cursor.SetCursor(cursorImg, new Vector2(128, 128), CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1;
        }
        //Debug.Log(Time.timeScale);
    }


    public void SetMenuScene() => SceneManager.LoadScene(0);



    public void SetRandomScene()
    {
        var rng = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        Debug.Log(rng);
        /*while (rng == SceneManager.GetActiveScene().buildIndex)
        {
            rng = Random.Range(1, SceneManager.sceneCountInBuildSettings);
            Debug.Log(rng);
        }*/
        SceneManager.LoadScene(rng);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
