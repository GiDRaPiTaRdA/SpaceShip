using GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolKit;
using Assets.Scripts.Entities;
using Assets.Scripts.GameControls;
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


    private SpaceShipModifications shipModifications;
    public SpaceShipModifications ShipModifications => this.shipModifications ?? (this.shipModifications = new SpaceShipModifications(this.gameObject));

}




