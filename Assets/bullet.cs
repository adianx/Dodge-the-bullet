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
        movement = new Vector3(speed, ran, 0);
        log = GameObject.FindGameObjectWithTag("logic").GetComponent<logic>();
    }

    // Update is called once per frame
    Vector3 prevPosition = Vector3.zero;
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
                movement = new Vector3(movement.x, -movement.y, movement.z);
                transform.Translate(movement * Time.deltaTime);

                if (mainMenu.sound) a.Play();
            }
        }

        if (prevPosition != Vector3.zero)
        {
            Vector3 movementDir = transform.position - prevPosition;
            sprite.transform.rotation = Quaternion.LookRotation(movementDir, Vector3.left);
        }
        prevPosition = transform.position;




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
