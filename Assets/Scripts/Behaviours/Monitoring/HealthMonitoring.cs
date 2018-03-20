using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMonitoring : MonoBehaviour {


    private string preFuelText;

    public Text healthValueText;

    // Use this for initialization
    void Start()
    {
        preFuelText = healthValueText.text;
    }

    // Update is called once per frame
    void Update()
    {
        healthValueText.text = preFuelText + " " + GameManager.SpaceShip.HP.ToString("000");
    }
}
