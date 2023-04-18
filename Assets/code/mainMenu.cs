using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;



public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text min;
    public TMP_Text sec;

    private int minutes;
    private int seconds;
    public static bool sound = true;
    void Start()
    {
        int time = PlayerPrefs.GetInt("highscore", 0);

        minutes = Math.DivRem(time, 60, out seconds);
        min.text = minutes.ToString();
        sec.text = seconds.ToString();

        if(PlayerPrefs.GetInt("sound", 1) == 1){
            sound = true;
        }
        else{
            sound = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void start(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void quit(){
        Application.Quit();
        Debug.Log("Quit");
    }
    public void soundOn(){
        sound = true;
        PlayerPrefs.SetInt("sound", 1);
    }
    public void soundOff(){
        sound = false;
        PlayerPrefs.SetInt("sound", 0);
    }
}
