using Assets.Scripts.GameControls;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LandingPadBehavoiur : MonoBehaviour
{


    private float deltaHeight;
    private float deltaHeightMoved;
    private bool treeted;
    private float timeWaited;

    public float timeUp = 1;
    public float timeDown = 0.5f;
    public float timeWait = 1;

    new Collider2D collider;

    private bool Pressed { get; set; }

    // Use this for initialization
    void Start()
    {
        this.gameObject.tag = GameTags.LandingPad;

        collider = GetComponent<Collider2D>();

        Vector2 size = collider.bounds.size;

        //Vector2 size = transform.lossyScale;
        deltaHeight = size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (Pressed)
        {
            var moveResult = MoveDown();

            if (!moveResult)
            {
                // Pressed = collider.IsTouchingLayers();

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

                        var ship = GameObject.FindGameObjectsWithTag(GameTags.Lander);

                        bool temp = ship.Any(o =>
                          {
                              var composite = o.GetComponent<CompositeCollider2D>();
                              bool touch = collider.IsTouching(composite);
                              return touch;
                          }
                            );

                        Pressed = temp;

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
        if (collision.transform.tag == GameTags.Lander)
            Pressed = true;
    }

    private void Treet()
    {
        if (GameManager.SpaceShip.CanAct)
        {
            GameManager.SpaceShip.HP += 50;
            GameManager.SpaceShip.Fuel += 1000;
        }
    }

    private bool MoveDown()
    {
        bool result = false;

        float dH = (deltaHeight * Time.deltaTime) / timeDown;

        if (deltaHeightMoved < deltaHeight)
        {
            deltaHeightMoved += dH;
            transform.position = new Vector3(transform.position.x, transform.position.y - dH, transform.position.z);

            result = true;
        }

        return result;
    }

    private bool MoveUp()
    {
        bool result = false;

        if (deltaHeightMoved > 0)
        {
            float dH = (deltaHeight * Time.deltaTime) / timeUp;

            deltaHeightMoved -= dH;
            transform.position = new Vector3(transform.position.x, transform.position.y + dH, transform.position.z);

            result = true;
        }

        return result;
    }
}
