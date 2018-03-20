using Assets.ToolKit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamagebleBehaviour : MonoBehaviour
{
    public float minDebrisSize  = 0.5f;
    public float hp = 100;
    public GameObject debrisPref;
    public GameObject explosionPref;

    // Not implimented
    public bool AutoScaleProperties = false;
    //public float ScaleDamagebleObject;
    //public float ScaleDamagebleDebris;
    //public float ScaleExplosionAnimation;

    public float ScaleDamageSensivity = 4;

    public bool IsDestoyed { get; private set; }
    public bool IsAlive => this.hp >= 0;

    public void Start()
    {
        var rgb = this.GetComponent<Rigidbody2D>();

        this.hp = this.hp * ScaleCoeficient(rgb);
        if(AutoScaleProperties) rgb.ApplyScale(ScaleCoeficient(rgb));
    }

    public void Damage(float damage)
    {
        this.hp -= damage;

        if (!this.IsAlive && !this.IsDestoyed)
        {
            HandleDestroy();
            IsDestoyed = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // hit damage
       this.Damage(DamageCalc.PowerFunc(DamageCalc.GetDamageForce(collision), ScaleDamageSensivity));
    }

    private void HandleDestroy()
    {
        Destroy(this.gameObject);

        // GEN debris
        if (debrisPref != null && this.gameObject.transform.lossyScale.magnitude>minDebrisSize)
        {
            var debris = Instantiate(debrisPref, transform.position, transform.rotation);
            var rigidbodies = debris.GetComponentsInChildren<Rigidbody2D>();
            var rigid = this.GetComponent<Rigidbody2D>();

            debris.transform.localScale = this.transform.lossyScale;

            debris.MoveToParrent(this.gameObject);

            rigidbodies.ToList().ForEach(rgb =>
            {
                rgb.GetComponent<DamagebleBehaviour>().debrisPref = debrisPref;

                rgb.TranferPhisics(rigid);
            });

        }

        // Spawn Exlosion
        if (explosionPref != null)
        {
            var explosion = Instantiate(explosionPref, transform.position, transform.rotation);
            explosion.transform.localScale = this.transform.lossyScale*2f;
            explosion.GetComponent<ExplosionBehaviour>().power /= 2;
            explosion.MoveToParrent(this.gameObject);
        }
    }

    private static float ScaleCoeficient(Rigidbody2D rigidbody2D)
    {
        return Math.Abs(rigidbody2D.transform.lossyScale.x);
    }
}
