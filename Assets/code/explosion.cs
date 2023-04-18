using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    public float etime;
    public ParticleSystem p;
    public AudioSource sound;
    void Start()
    {
        p.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.explode)
        {
            p.Play();
            time += Time.deltaTime;
            if(mainMenu.sound) sound.Play();
            player.hide = true;

            if(time >= etime){
                p.Stop();
                logic.explode = false;
            }
        }

    }

}
