using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.1f;
    private bool pressUp = false;
    private bool pressDown = false;
    public float deadZone = 4.4f;
    private bool down = true;
    private bool up = true;
    public Rigidbody2D bod;
    public static bool alive = true;
    public static bool hide = false;
    public SpriteRenderer sp;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (alive)
        {

            if (Input.GetKeyDown(KeyCode.W))
            {
                pressUp = true;
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                pressUp = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                pressDown = true;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                pressDown = false;
            }
            if (pressUp)
            {
                bod.velocity = new Vector2(0, moveSpeed);
            }
            else if (pressDown)
            {
                bod.velocity = new Vector2(0, -moveSpeed);
            }
            else
            {
                bod.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            bod.velocity = new Vector2(0, 0);
        }

    transform.eulerAngles = new Vector3(0, 0, 90);
    if(hide) sp.enabled = false;

        
    }
}
