using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarState : MonoBehaviour
{
    static private CarState _inst;
    static public CarState Inst
    {
        get { return _inst; }
    }

    CarMovement cm;
    Rigidbody2D rb;

    [SerializeField] public Animator carAnim;
    [SerializeField] public Animator jumpExplosion;

    [Header ("State movement for the car")]
    [SerializeField] public bool airTime = true;

    [Header ("State progression for the car")]
    [SerializeField] public bool convector = false;
    [SerializeField] public bool uranium = false;
    [SerializeField] public bool music = false;

    private void Awake()
    {
        _inst = this;
    }


    private void Start()
    {
        cm = CarMovement.Inst;
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && !airTime)
        {
            jumpExplosion.SetTrigger("Jump");
            rb.AddForce(new Vector2(0, cm.jumpHeight), ForceMode2D.Impulse);
            airTime = true;
        }
    }


    private void OnColliderEnter2D (Collision collision)
    {
        airTime = false;
    }


    private void OnColliderExit2D (Collision2D collision)
    {
        airTime = true;
    }
}
