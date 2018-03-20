using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityOnMoveBehaviour : MonoBehaviour {

    Rigidbody2D rigidBodyInstance;
    float defaultGravityScale;

	// Use this for initialization
	void Start () {
	    this.rigidBodyInstance = this.GetComponent<Rigidbody2D>();
	    this.defaultGravityScale = this.rigidBodyInstance.gravityScale;

    }
	
	// Update is called once per frame
	void Update () {
	    this.rigidBodyInstance.gravityScale = GravityFunc(this.defaultGravityScale, this.rigidBodyInstance.velocity.magnitude);
    }

    private static float GravityFunc(float gravity, float speed)
    {
        float funcResult = 0;
        //float speedTreshold = 1;

        if (speed <= 1)
        {
            funcResult = gravity;
        }
        else
        {
            funcResult = (1 / speed) * 0.1f;
        }

        return funcResult;
    }
}
