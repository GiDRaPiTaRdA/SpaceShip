using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour {

    public float radius = 3;
    public float power = 50;
    public float minDistance = 2f;

    // Use this for initialization
    void Start () {
        this.Exp();
	}
	

    void Exp()
    {
        Vector2 explosionPos = this.transform.position;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPos, this.radius)
            .Where(c => c.gameObject.tag != GameTags.LazerBeam).ToArray();

        foreach (Collider2D hit in colliders)
        {
            var hitBody = hit.GetComponent<Rigidbody2D>();

            if (hitBody != null)
            {
                Vector2 vector = hitBody.position - explosionPos;

                var distance = vector.magnitude;

                vector.Normalize();


                Vector2 force = vector * (float)(this.power * this.transform.localScale.x / (distance < this.minDistance ? this.minDistance : distance));

                hitBody.AddForce(force);
            }
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
