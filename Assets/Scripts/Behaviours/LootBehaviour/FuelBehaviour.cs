using Assets.Scripts.GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class FuelBehaviour : ShipMonoBehaviour {

    public int fuel = 50;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == GameTags.Lander)
            this.SpaceShip.Fuel += this.fuel;
    }
}
