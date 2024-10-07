using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeAliveCounter : MonoBehaviour
{
    [SerializeField] Player Player;
    public TMP_Text TimeAliveScore;
    public TMP_Text HighScore;
    void Start()
    {
        
    }

    public void TimeAlive()
    {
        float TimeAliveCounter = 1 * Time.deltaTime;
        int TimeAlive = (int)TimeAliveCounter;

        TimeAliveScore.text = TimeAliveCounter.ToString();
        if (TimeAliveCounter > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", TimeAlive);
            TimeAliveScore.text = TimeAliveCounter.ToString();

        }
    }
}
