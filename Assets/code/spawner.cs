using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public float maxAngle = 45.0f;
    private float time;
    public float sTime = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float upAngle = transform.rotation.z + maxAngle;
        float downAngle = transform.rotation.z - maxAngle;
        time += Time.deltaTime;
        if (time > sTime)
        {
            if (player.alive)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                time = 0;
            }

        }

    }
}
