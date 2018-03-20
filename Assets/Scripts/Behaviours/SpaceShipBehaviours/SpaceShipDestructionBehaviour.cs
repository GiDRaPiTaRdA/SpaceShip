using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Entities;
using Assets.ToolKit;
using UnityEngine;

public class SpaceShipDestructionBehaviour : MonoBehaviour {

    public GameObject explosionPrefab;
    public GameObject destructedSpaceship;

    // Use this for initialization
    void Start () {
        GameManager.SpaceShip.DestructTreshold = 1.5f;

        GameManager.SpaceShip.OnDestruct += this.SpaceShip_OnDestruct;
    }

    private void SpaceShip_OnDestruct(object sender, SpaceShipEventArgs e)
    {
        if (!GameManager.SpaceShip.IsDestroyed)
        {
            GameManager.SpaceShip.IsDestroyed = true;

            HandleLanderDestroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != GameTags.Loot)
        {
            GameManager.SpaceShip.OnCollisiion(DamageCalc.PowerFunc(DamageCalc.GetDamageForce(collision)));
        }
    }

    private void HandleLanderDestroy()
    {
        Destroy(this.gameObject);

        if (explosionPrefab != null)
        {
            var spaceshipDestructed = Instantiate(destructedSpaceship, transform.position, transform.rotation);
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            explosion.MoveToParrent(this.gameObject);
            spaceshipDestructed.TranferPhisicsToChildDebris(this.gameObject.GetComponent<Rigidbody2D>());
        }
    }
}
