using Assets.Scripts.GameControls;
using Assets.ToolKit;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using ToolKit;
using UnityEngine;

public class BombBehaviour : ShipMonoBehaviour
{
    public float damage = 50;
    public GameObject explosionPrefab;

    protected override void Start()
    {
        base.Start();

        this.gameObject.tag = GameTags.Bomb;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameTags.Lander)
            this.SpaceShip.Damage(this.damage);
        else if(collision.gameObject.GetComponent<DamagebleBehaviour>()!=null)
        {
            collision.gameObject.GetComponent<DamagebleBehaviour>().Damage(this.damage);
        }

        if (this.explosionPrefab != null)
        {
            var explosion = Instantiate(this.explosionPrefab, this.transform.position, this.transform.rotation);

            explosion.MoveToParrent(this.gameObject);
        }

        Destroy(this.gameObject);

    }

  
}
