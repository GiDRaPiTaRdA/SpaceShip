using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class FuelConsumption : ShipMonoBehaviour
{

    public float consumption =1;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        this.SpaceShip.Consumption = this.consumption;

        this.SpaceShip.OnTrust += this.SpaceShip_OnTrust;
        this.SpaceShip.OnTurn += this.SpaceShip_OnTurn;
        this.SpaceShip.OnStabelize += this.SpaceShip_OnStabelize;
        this.SpaceShip.OnRetard += this.SpaceShip_OnRetard;
    }

    private void SpaceShip_OnTrust(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        this.SpaceShip.FuelConsumption(this.SpaceShip.Consumption);
    }
    private void SpaceShip_OnTurn(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        this.SpaceShip.FuelConsumption(this.SpaceShip.TurnConsumption);
    }
    private void SpaceShip_OnRetard(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        this.SpaceShip.FuelConsumption(this.SpaceShip.Consumption);
    }
    private void SpaceShip_OnStabelize(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        this.SpaceShip.FuelConsumption(this.SpaceShip.StabelizeConsumption*Math.Abs(e.StabelizingForce));
    }

}
