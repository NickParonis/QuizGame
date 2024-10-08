using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmmount);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmmount);
        }
    }

        private void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else 
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
