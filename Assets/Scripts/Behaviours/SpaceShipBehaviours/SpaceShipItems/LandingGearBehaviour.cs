using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolKit;
using UnityEngine;

public class LandingGearBehaviour : MonoBehaviour
{


    private float deltaHeight;
    private float deltaHeightMoved;
    private bool treeted;
    private float timeWaited;

    public float timeUp = 1;
    public float timeDown = 0.5f;
    public float timeWait = 1;

    GameObject lander;
    GameObject[] landingPads;
    

    private bool Pressed { get; set; }

    // Use this for initialization
    void Start()
    {
        this.lander = GameObject.FindGameObjectsWithTag(GameTags.Lander).First();
        this.landingPads = GameObject.FindGameObjectsWithTag(GameTags.LandingPad);

        SpriteRenderer render = this.GetComponent<SpriteRenderer>();
        this.deltaHeight = render.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.Pressed = this.landingPads.Any(lp => this.IsNear(lp.transform));

        if (this.Pressed)
        {
            var moveResult = this.MoveDown();

            if (!moveResult)
            {
                if (!this.treeted)
                {
                    this.Treet();
                    this.treeted = true;
                }
                else
                {
                    this.timeWaited += Time.deltaTime;

                    if (this.timeWaited > this.timeWait)
                    {
                        this.timeWaited = 0;

                        this.Pressed = this.landingPads.Any(lp => this.IsNear(lp.transform));
                    }
                }
            }
        }
        else
        {
            var moveResult = this.MoveUp();

            if (!moveResult)
            {
                this.treeted = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       // Pressed = true;
    }

    private bool IsNear(Transform tranform, int range = 3)
    {
        Vector2 vector2 = new Vector2(this.lander.transform.position.x - tranform.position.x, this.lander.transform.position.y - tranform.position.y);
        bool result = vector2.magnitude <= range;

        return result;
    }

    private void Treet()
    {
        //GameManager.SpaceShip.Fuel += 100;
    }

    private bool MoveDown()
    {
        bool result = false;

        float dH = (this.deltaHeight * Time.deltaTime) / this.timeDown;

        if (this.deltaHeightMoved < this.deltaHeight)
        {
            this.deltaHeightMoved += dH;

            //bool temp = new Vector2(transform.position.x, transform.position.y - dH).DirrectionDependentBehavoir();

            Vector2 temp = new Vector2(0, -dH).DirrectionDependentBehavoir(this.transform.eulerAngles.z / Mathf.Rad2Deg);

            this.transform.position = new Vector3(this.transform.position.x+ temp.x, this.transform.position.y + temp.y, this.transform.position.z);

            result = true;
        }

        return result;
    }

    private bool MoveUp()
    {
        bool result = false;

        if (this.deltaHeightMoved > 0)
        {
            Collider2D collider = this.GetComponent<Collider2D>();


            float dH = (this.deltaHeight * Time.deltaTime) / this.timeUp;

            this.deltaHeightMoved -= dH;

            Vector2 temp = new Vector2(0, dH).DirrectionDependentBehavoir(this.transform.eulerAngles.z/Mathf.Rad2Deg);

            collider.transform.position = new Vector3(collider.transform.position.x + temp.x, collider.transform.position.y + temp.y, collider.transform.position.z);

            result = true;
        }

        return result;
    }
}
