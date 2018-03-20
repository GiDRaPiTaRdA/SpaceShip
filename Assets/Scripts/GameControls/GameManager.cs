using Assets.Scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToolKit;
using Assets.Scripts.Entities.Modifications.Mods;

public class GameManager : MonoBehaviour {

    public static SpaceShip SpaceShip { get; set; }

	// Use this for initialization
	void Awake() {
        SpaceShip = new SpaceShip();
    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public static event EventHandler OnInitialize;

    public static void Initialize()
    {
        OnInitialize.SafeInvoke(null, EventArgs.Empty);
    }

    public void ResetLevel(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
	}

    public void TogglePause(Boolean value)
    {
        Time.timeScale = value ? 0 : 1;
    }

    public void ToggleGravityMode(Boolean value)
    {
        var lander = GameObject.FindGameObjectWithTag(GameTags.Lander);
        if (lander!=null)
            lander.GetComponent<SpaceShipBehaviour>().ShipModifications.ToggleModifiCation<AntiGravitySpeedModification>(value);
    }
}
