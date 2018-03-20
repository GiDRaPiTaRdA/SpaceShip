using Assets.Scripts.GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehaviour : MonoBehaviour {

    public int fuel = 50;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == GameTags.Lander)
            GameManager.SpaceShip.Fuel += fuel;
    }
}
