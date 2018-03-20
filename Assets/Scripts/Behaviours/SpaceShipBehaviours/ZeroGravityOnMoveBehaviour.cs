using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravityOnMoveBehaviour : MonoBehaviour {

    Rigidbody2D rigidBodyInstance;
    float defaultGravityScale;

	// Use this for initialization
	void Start () {
        rigidBodyInstance = GetComponent<Rigidbody2D>();
        defaultGravityScale = rigidBodyInstance.gravityScale;

    }
	
	// Update is called once per frame
	void Update () {
        rigidBodyInstance.gravityScale = GravityFunc(defaultGravityScale,rigidBodyInstance.velocity.magnitude);
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
