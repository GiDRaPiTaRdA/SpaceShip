using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;
using UnityEngine.UI;

public class HealthMonitoring : ShipMonoBehaviour {


    private string preFuelText;

    public Text healthValueText;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        this.preFuelText = this.healthValueText.text;
    }

    // Update is called once per frame
    void Update()
    {
        this.healthValueText.text = this.preFuelText + " " + this.SpaceShip.HP.ToString("000");
    }
}
