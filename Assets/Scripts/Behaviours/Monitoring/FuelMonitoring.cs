using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelMonitoring : MonoBehaviour {

    private string preFuelText;

    public Text fuelValueText;

    // Use this for initialization
    void Start () {
        preFuelText = fuelValueText.text;
	}
	
	// Update is called once per frame
	void Update () {
        fuelValueText.text = preFuelText + " " + GameManager.SpaceShip.Fuel.ToString("000");
    }
}
