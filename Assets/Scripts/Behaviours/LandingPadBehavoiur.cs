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

        this.collider = this.GetComponent<Collider2D>();

        Vector2 size = this.collider.bounds.size;

        //Vector2 size = transform.lossyScale;
        this.deltaHeight = size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.Pressed)
        {
            var moveResult = this.MoveDown();

            if (!moveResult)
            {
                // Pressed = collider.IsTouchingLayers();

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

                        var ship = GameObject.FindGameObjectsWithTag(GameTags.Lander);

                        bool temp = ship.Any(o =>
                          {
                              var composite = o.GetComponent<CompositeCollider2D>();
                              bool touch = this.collider.IsTouching(composite);
                              return touch;
                          }
                            );

                        this.Pressed = temp;

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
        if (collision.transform.tag == GameTags.Lander) this.Pressed = true;
    }

    private void Treet()
    {
        //if (GameManager.SpaceShip.CanAct)
        //{
        //    GameManager.SpaceShip.HP += 50;
        //    GameManager.SpaceShip.Fuel += 1000;
        //}
    }

    private bool MoveDown()
    {
        bool result = false;

        float dH = (this.deltaHeight * Time.deltaTime) / this.timeDown;

        if (this.deltaHeightMoved < this.deltaHeight)
        {
            this.deltaHeightMoved += dH;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - dH, this.transform.position.z);

            result = true;
        }

        return result;
    }

    private bool MoveUp()
    {
        bool result = false;

        if (this.deltaHeightMoved > 0)
        {
            float dH = (this.deltaHeight * Time.deltaTime) / this.timeUp;

            this.deltaHeightMoved -= dH;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + dH, this.transform.position.z);

            result = true;
        }

        return result;
    }
}
