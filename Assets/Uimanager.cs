using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{
    public bool ispaused;
    private int score;
    private int highscore;
    public int lifepoints = 3;

    public Text scoretext;
    public Text highscoretext;
    public Image[] life;
    public GameObject pausemenu;
    public GameObject Death;
    public GameObject Pausebutton;

    private void Start()
    {
        score = 0;
        lifepoints = 3;
        scoretext.text = score.ToString();
        highscore = PlayerPrefs.GetInt("Score");
        highscoretext.text = "BestScore : " + highscore.ToString();
        pausemenu.SetActive(false);
        Time.timeScale = 1;
        ispaused = false;
        Death.SetActive(false);
        foreach(Image i in life)
        {
            i.enabled = true;
        }
    }
    public void increamentscore(int scoreamount)
    {
        score += scoreamount;
        scoretext.text = score.ToString();
        if(score > highscore)
        {
            highscore = score;
            highscoretext.text = "BestScore : " + highscore.ToString();
            PlayerPrefs.SetInt("Score", highscore);
        }
    }

    public void losePoints()
    {
        if(lifepoints <= 0)
        {
            return;
        }
        lifepoints--;
        life[lifepoints].enabled = false;
        if(lifepoints <= 0)
        {
            death();
        }
    }

    private void death()
    {
        ispaused = true;
        Death.SetActive(true);
        Pausebutton.SetActive(false);
    }

    public void PauseGame()
    {
        pausemenu.SetActive(!pausemenu.activeSelf);
        ispaused = pausemenu.activeSelf; 
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }
}
