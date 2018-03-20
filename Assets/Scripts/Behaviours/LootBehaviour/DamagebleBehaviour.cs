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
    public bool autoScaleProperties = false;
    //public float ScaleDamagebleObject;
    //public float ScaleDamagebleDebris;
    //public float ScaleExplosionAnimation;

    public float scaleDamageSensivity = 4;

    public bool IsDestoyed { get; private set; }
    public bool IsAlive => this.hp > 0;

    public void Start()
    {
        var rgb = this.GetComponent<Rigidbody2D>();

        this.hp = this.hp * ScaleCoeficient(rgb);
        if(this.autoScaleProperties) rgb.ApplyScale(ScaleCoeficient(rgb));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // missle hits does not count
        if(collision.gameObject.GetComponent<MissleBehaviour>() ==null)
            this.Damage(DamageCalc.PowerFunc(DamageCalc.GetDamageForce(collision), this.scaleDamageSensivity));
    }

    public void Damage(float damage)
    {
        if ((int)(this.hp - damage) <= 0)
        {
            this.hp = 0;
            this.Destroy();
        }
        else
        {
            this.hp -= damage;
        }
    }

    public void Destroy()
    {
        if (!this.IsAlive && !this.IsDestoyed)
        {
            this.HandleDestroy();
            this.IsDestoyed = true;
        }
    }

    #region Help

    private void HandleDestroy()
    {
        Destroy(this.gameObject);

        // GEN debris
        if (this.debrisPref != null && this.gameObject.transform.lossyScale.magnitude> this.minDebrisSize)
        {
            var debris = Instantiate(this.debrisPref, this.transform.position, this.transform.rotation);
            var rigidbodies = debris.GetComponentsInChildren<Rigidbody2D>();
            var rigid = this.GetComponent<Rigidbody2D>();

            debris.transform.localScale = this.transform.lossyScale;

            debris.MoveToParrent(this.gameObject);

            rigidbodies.ToList().ForEach(rgb => 
            {
                rgb.GetComponent<DamagebleBehaviour>().debrisPref = this.debrisPref;

                rgb.TranferPhisics(rigid);
            });

        }

        // Spawn Exlosion
        if (this.explosionPref != null)
        {
            var explosion = Instantiate(this.explosionPref, this.transform.position, this.transform.rotation);
            explosion.transform.localScale = this.transform.lossyScale*2f;
            explosion.GetComponent<ExplosionBehaviour>().power /= 2;
            explosion.MoveToParrent(this.gameObject);
        }
    }

    private static float ScaleCoeficient(Rigidbody2D rigidbody2D)
    {
        return Math.Abs(rigidbody2D.transform.lossyScale.x);
    }

    #endregion
}
