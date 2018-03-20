using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class StarBehaviour : ShipMonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameTags.Lander)
            this.SpaceShip.Stars += 1;
    }
}
