using GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolKit;
using Assets.Scripts.Entities;
using System.Linq;
using UnityEngine.Video;

public class SpaceShipBehaviour : MonoBehaviour
{
    public float fuel;
    public float hp;

    public SpaceShip SpaceShip { get; private set; }

    void Awake()
    {
        this.SpaceShip = new SpaceShip
        {
            Fuel = this.fuel,
            HP = this.hp
        };
    }
}




