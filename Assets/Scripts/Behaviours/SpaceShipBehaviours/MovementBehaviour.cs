using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using ToolKit;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour {

    public float trust;
    public float retard;
    public float turn;

    private Rigidbody2D rigidbodyInstance;

    // Use this for initialization
    void Start () {
        rigidbodyInstance = GetComponent<Rigidbody2D>();

        GameManager.SpaceShip.TrustForce = trust;
        GameManager.SpaceShip.RertardForce = retard;
        GameManager.SpaceShip.TurnForce = turn;

        GameManager.SpaceShip.OnTrust += this.SpaceShip_OnTrust;
        GameManager.SpaceShip.OnRetard += this.SpaceShip_OnRetard;
        GameManager.SpaceShip.OnTurn += this.SpaceShip_OnTurn;
    }

    private void SpaceShip_OnTrust(object sender, SpaceShipEventArgs e)
    {
        Vector2 deltaVelocity = new Vector2(0, e.TrustForce);

        this.rigidbodyInstance.AddForce(deltaVelocity.DirrectionDependentBehavoir(transform));
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
        rigidbodyInstance.AddTorque(e.TurnForce, ForceMode2D.Force);
    }

}
