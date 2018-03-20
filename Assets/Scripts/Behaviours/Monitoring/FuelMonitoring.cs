using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;
using UnityEngine.UI;

public class FuelMonitoring : ShipMonoBehaviour {

    private string preFuelText;

    public Text fuelValueText;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        this.preFuelText = this.fuelValueText.text;
	}
	
	// Update is called once per frame
	void Update () {
	    this.fuelValueText.text = this.preFuelText + " " + this.SpaceShip.Fuel.ToString("000");
    }
}
