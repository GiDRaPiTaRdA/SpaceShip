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
        lander = GameObject.FindGameObjectsWithTag(GameTags.Lander).First();
        landingPads = GameObject.FindGameObjectsWithTag(GameTags.LandingPad);

        SpriteRenderer render = GetComponent<SpriteRenderer>();
        deltaHeight = render.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Pressed = landingPads.Any(lp => IsNear(lp.transform));

        if (Pressed)
        {
            var moveResult = MoveDown();

            if (!moveResult)
            {
                if (!treeted)
                {
                    Treet();
                    treeted = true;
                }
                else
                {
                    timeWaited += Time.deltaTime;

                    if (timeWaited > timeWait)
                    {
                        timeWaited = 0;

                        Pressed = landingPads.Any(lp => IsNear(lp.transform));
                    }
                }
            }
        }
        else
        {
            var moveResult = MoveUp();

            if (!moveResult)
            {
                treeted = false;
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

        float dH = (deltaHeight * Time.deltaTime) / timeDown;

        if (deltaHeightMoved < deltaHeight)
        {
            deltaHeightMoved += dH;

            //bool temp = new Vector2(transform.position.x, transform.position.y - dH).DirrectionDependentBehavoir();

            Vector2 temp = new Vector2(0, -dH).DirrectionDependentBehavoir(transform.eulerAngles.z / Mathf.Rad2Deg);

            transform.position = new Vector3(transform.position.x+ temp.x, transform.position.y + temp.y, transform.position.z);

            result = true;
        }

        return result;
    }

    private bool MoveUp()
    {
        bool result = false;

        if (deltaHeightMoved > 0)
        {
            Collider2D collider = GetComponent<Collider2D>();


            float dH = (deltaHeight * Time.deltaTime) / timeUp;

            deltaHeightMoved -= dH;

            Vector2 temp = new Vector2(0, dH).DirrectionDependentBehavoir(transform.eulerAngles.z/Mathf.Rad2Deg);

            collider.transform.position = new Vector3(collider.transform.position.x + temp.x, collider.transform.position.y + temp.y, collider.transform.position.z);

            result = true;
        }

        return result;
    }
}
