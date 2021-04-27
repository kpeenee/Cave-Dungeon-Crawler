using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager current;

    [SerializeField] TextMeshProUGUI scoreText;
    private int currentScore = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateText();
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public static void DestroyCurrent()
    {
        Destroy(current.gameObject);
    }
}
