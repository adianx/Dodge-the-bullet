using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public float deadZone;
    public float rotation;
    private float ran;
    public Vector3 movement;

    public float limit = 4.6f;

    public Rigidbody2D bod;

    private logic log;
    public AudioSource a;
    public float rot;
    public GameObject sprite;


    void Start()
    {
        ran = Random.Range(-speed, speed);
        movement = new Vector3(speed, 0, 0);
        log = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
        rot = angle();

        transform.localEulerAngles = new Vector3(0, 0, rot);
    }

    // Update is called once per frame
    Vector3 prevPosition = Vector3.zero;


    float angle()
    {
        return Mathf.Atan2(ran, speed) * Mathf.Rad2Deg;
    }
    void Update()
    {

        if (player.alive)
        {
            if (transform.position.x > deadZone)
            {
                Destroy(gameObject);
            }

            transform.Translate(movement * Time.deltaTime);
            if (transform.position.y > limit || transform.position.y < -limit)
            {
                rot = -rot;
                transform.localEulerAngles = new Vector3(0, 0, rot);
                transform.Translate(movement * Time.deltaTime);

                if (mainMenu.sound) a.Play();
            }

            
        }




    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            player.alive = false;
            log.over();
        }
    }


}
