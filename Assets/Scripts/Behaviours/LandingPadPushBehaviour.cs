using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class LandingPadPushBehaviour : MonoBehaviour
{


    private float deltaHeight;
    private float deltaHeightMoved;
    private bool IsActive = true;


    public float timeDown;

    new Collider2D collider;

    private bool IsPressingDown { get; set; }

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider2D>();

        Vector2 size = collider.bounds.size;
        deltaHeight = size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressingDown && IsActive)
        {
            float dH = (deltaHeight * Time.deltaTime) / timeDown;

            if (deltaHeightMoved < deltaHeight)
            {
                deltaHeightMoved += dH;
                transform.position = new Vector3(transform.position.x, transform.position.y - dH, transform.position.z);
            }
            else
            {
                IsActive = false;
                GameManager.SpaceShip.Fuel = 0;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        IsPressingDown = true;
    }
}
