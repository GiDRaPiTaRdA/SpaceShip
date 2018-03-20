using Assets.Scripts.GameControls;
using Assets.ToolKit;
using System.Collections;
using System.Collections.Generic;
using ToolKit;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float damage = 50;
    public GameObject explosionPrefab;

    void Start()
    {
        this.gameObject.tag = GameTags.Bomb;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameTags.Lander)
            GameManager.SpaceShip.Damage(damage);
        else if(collision.gameObject.GetComponent<DamagebleBehaviour>()!=null)
        {
            collision.gameObject.GetComponent<DamagebleBehaviour>().Damage(damage);
        }

        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab,transform.position,transform.rotation);

            explosion.MoveToParrent(this.gameObject);
        }

        Destroy(this.gameObject);

    }

  
}
