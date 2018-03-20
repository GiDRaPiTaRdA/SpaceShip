using GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolKit;
using Assets.Scripts.Entities;
using Assets.Scripts.GameControls;
using System.Linq;

public class SpaceShipBehaviour : MonoBehaviour
{

    public float fuel;
    public float hp;

    private SpaceShipModifications shipModifications;
    public SpaceShipModifications ShipModifications { get { return shipModifications ?? (shipModifications = new SpaceShipModifications(this.gameObject)); } }

    void Start()
    {
        this.gameObject.tag = GameTags.Lander;

        GameManager.SpaceShip.Fuel = fuel;
        GameManager.SpaceShip.HP = hp;

        GameManager.Initialize();
    }
}




