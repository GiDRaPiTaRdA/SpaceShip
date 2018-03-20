using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using Assets.Scripts.Entities;
using ToolKit;
using UnityEngine;

public class MovementBehaviour : ShipMonoBehaviour {

    public float trust;
    public float retard;
    public float turn;

    private Rigidbody2D rigidbodyInstance;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        this.rigidbodyInstance = this.GetComponent<Rigidbody2D>();

        this.SpaceShip.TrustForce = this.trust;
        this.SpaceShip.RertardForce = this.retard;
        this.SpaceShip.TurnForce = this.turn;
        
        this.SpaceShip.OnTrust += this.SpaceShip_OnTrust;
        this.SpaceShip.OnRetard += this.SpaceShip_OnRetard;
        this.SpaceShip.OnTurn += this.SpaceShip_OnTurn;
    }

    private void SpaceShip_OnTrust(object sender, SpaceShipEventArgs e)
    {
        Vector2 deltaVelocity = new Vector2(0, e.TrustForce);

        this.rigidbodyInstance.AddForce(deltaVelocity.DirrectionDependentBehavoir(this.transform));
    }

    private void SpaceShip_OnRetard(object sender, SpaceShipEventArgs e)
    {
        this.rigidbodyInstance.AddForce(new Vector2(0f, -this.rigidbodyInstance.gravityScale * Physics.gravity.y * Time.deltaTime), ForceMode2D.Impulse);

        this.rigidbodyInstance.AddForce(
            new Vector2(
                -Time.deltaTime * e.RetardForce * this.rigidbodyInstance.mass * this.rigidbodyInstance.velocity.x,
                -Time.deltaTime * e.RetardForce * this.rigidbodyInstance.mass * this.rigidbodyInstance.velocity.y),
            ForceMode2D.Impulse);
    }

    private void SpaceShip_OnTurn(object sender, SpaceShipEventArgs e)
    {
        this.rigidbodyInstance.AddTorque(e.TurnForce, ForceMode2D.Force);
    }

}
