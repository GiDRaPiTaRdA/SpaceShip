using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using Assets.Scripts.Entities;
using UnityEngine;

public class TorgueStabelizationBehaviour : ShipMonoBehaviour
{
    public float stabelization = 20;
    Rigidbody2D rigidbodyInstance;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        this.rigidbodyInstance = this.GetComponent<Rigidbody2D>();

        this.SpaceShip.Stabelization = this.stabelization;
        this.SpaceShip.OnStabelize += this.SpaceShip_OnStabelize;
    }

    // Update is called once per frame
    void Update()
    {
        float stabelisingForce = this.rigidbodyInstance.angularVelocity * 0.001f * this.SpaceShip.Stabelization * Time.timeScale;

        this.SpaceShip.Stabelize(stabelisingForce);
    }

    private void SpaceShip_OnStabelize(object sender, SpaceShipEventArgs e)
    {
        this.rigidbodyInstance.AddTorque(-e.StabelizingForce, ForceMode2D.Force);
    }

}
