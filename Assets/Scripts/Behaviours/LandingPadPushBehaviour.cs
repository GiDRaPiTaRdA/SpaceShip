using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class LandingPadPushBehaviour : ShipMonoBehaviour
{


    private float deltaHeight;
    private float deltaHeightMoved;
    private bool IsActive = true;


    public float timeDown;

    new Collider2D collider;

    private bool IsPressingDown { get; set; }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        this.collider = this.GetComponent<Collider2D>();

        Vector2 size = this.collider.bounds.size;
        this.deltaHeight = size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.IsPressingDown && this.IsActive)
        {
            float dH = (this.deltaHeight * Time.deltaTime) / this.timeDown;

            if (this.deltaHeightMoved < this.deltaHeight)
            {
                this.deltaHeightMoved += dH;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - dH, this.transform.position.z);
            }
            else
            {
                this.IsActive = false;
                this.SpaceShip.Fuel = 0;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        this.IsPressingDown = true;
    }
}
