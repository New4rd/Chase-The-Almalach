using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    static private CarMovement _inst;
    static public CarMovement Inst
    {
        get { return _inst; }
    }


    Rigidbody2D rb;
    CarState cs;
    float rotationLimit = 25f;

    public float speed;
    public float jumpHeight;


    private void Awake()
    {
        _inst = this;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cs = CarState.Inst;
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (transform.localEulerAngles.z < 180f && transform.localEulerAngles.z > rotationLimit)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotationLimit);
            rb.angularVelocity = 0;
        }

        if (transform.localEulerAngles.z > 180f && transform.localEulerAngles.z < 360-rotationLimit)
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotationLimit);
            rb.angularVelocity = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" && cs.airTime) cs.airTime = false;
    }
}
