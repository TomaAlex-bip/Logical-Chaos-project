using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    
    private TextMesh scoreText;

    private void Awake()
    {
        scoreText = gameObject.GetComponent<TextMesh>();
        StartCoroutine(Despawn());
    }

    public void SetScoreText(int ceva)
    {
        scoreText.text = "+" + ceva.ToString();
    }


    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
