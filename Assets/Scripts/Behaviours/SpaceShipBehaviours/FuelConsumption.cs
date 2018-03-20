using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelConsumption : MonoBehaviour
{

    public float consumption =1;

    // Use this for initialization
    void Start()
    {
        GameManager.SpaceShip.Consumption = consumption;

        GameManager.SpaceShip.OnTrust += this.SpaceShip_OnTrust;
        GameManager.SpaceShip.OnTurn += this.SpaceShip_OnTurn;
        GameManager.SpaceShip.OnStabelize += this.SpaceShip_OnStabelize;
        GameManager.SpaceShip.OnRetard += this.SpaceShip_OnRetard;
    }

    private void SpaceShip_OnTrust(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        GameManager.SpaceShip.FuelConsumption(GameManager.SpaceShip.Consumption);
    }
    private void SpaceShip_OnTurn(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        GameManager.SpaceShip.FuelConsumption(GameManager.SpaceShip.TurnConsumption);
    }
    private void SpaceShip_OnRetard(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        GameManager.SpaceShip.FuelConsumption(GameManager.SpaceShip.Consumption);
    }
    private void SpaceShip_OnStabelize(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        GameManager.SpaceShip.FuelConsumption(GameManager.SpaceShip.StabelizeConsumption*Math.Abs(e.StabelizingForce));
    }

}
