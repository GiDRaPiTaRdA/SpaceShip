using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using Assets.Scripts.Entities;
using Assets.ToolKit;
using UnityEngine;

public class SpaceShipDestructionBehaviour : ShipMonoBehaviour {

    public GameObject explosionPrefab;
    public GameObject destructedSpaceship;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        this.SpaceShip.DestructTreshold = 1.5f;

        this.SpaceShip.OnDestruct += this.SpaceShip_OnDestruct;
    }

    private void SpaceShip_OnDestruct(object sender, SpaceShipEventArgs e)
    {
        if (!this.SpaceShip.IsDestroyed)
        {
            this.SpaceShip.IsDestroyed = true;

            this.HandleLanderDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != GameTags.Loot)
        {
            this.SpaceShip.OnCollisiion(DamageCalc.PowerFunc(DamageCalc.GetDamageForce(collision)));
        }
    }

    private void HandleLanderDestroy()
    {
        Destroy(this.gameObject);

        if (this.explosionPrefab != null)
        {
            var spaceshipDestructed = Instantiate(this.destructedSpaceship, this.transform.position, this.transform.rotation);
            var explosion = Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation);

            explosion.MoveToParrent(this.gameObject);
            spaceshipDestructed.TranferPhisicsToChildDebris(this.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
