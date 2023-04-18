using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;



public class logic : MonoBehaviour
{
    // Start is called before the first frame update
    public static int totalTime = 0;
    public GameObject endScreen;
    public int minutes;
    public int seconds;
    public TMP_Text min;
    public TMP_Text sec;
    private float time;
    public AudioSource a;
    public GameObject exp;
    public static bool explode = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (player.alive)
        {
            time += Time.deltaTime;
            if (time >= 1)
            {
                totalTime += 1;
                time = 0;
            }
        }
        minutes = Math.DivRem(totalTime, 60, out seconds);
        min.text = minutes.ToString();
        sec.text = seconds.ToString();

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        player.alive = true;
        if (PlayerPrefs.GetInt("highscore", 0) < totalTime)
        {
            PlayerPrefs.SetInt("highscore", totalTime);
        }
        totalTime = 0;
        player.hide = false;
    }

    public void over()
    {
        endScreen.SetActive(true);
        if (mainMenu.sound) a.Play();
        explode = true;

    }
}
