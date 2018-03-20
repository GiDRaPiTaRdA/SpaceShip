using Assets.ToolKit;
using System.Collections;
using System.Collections.Generic;
using ToolKit;
using UnityEngine;

public class MissleBehaviour : MonoBehaviour {

    public float speed = 50;
    public int damage = 10;

    public GameObject hitPrefab;

	// Use this for initialization
	void Start () {
        Vector2 deltaVelocity = new Vector2(0, speed);

        GetComponent<Rigidbody2D>().AddForce(deltaVelocity.DirrectionDependentBehavoir(this.transform)*this.gameObject.GetComponent<Rigidbody2D>().mass*10);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitPrefab != null)
        {
            var explosion = Instantiate(hitPrefab, transform.position, Quaternion.identity);

            explosion.MoveToParrent(this.gameObject);
        }

        var damageble = collision.gameObject.GetComponent<DamagebleBehaviour>();
        if (damageble != null)
        {
            damageble.hp -= damage;
        }

        Destroy(this.gameObject);
    }
}
