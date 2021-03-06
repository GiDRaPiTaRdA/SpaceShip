﻿using Assets.Scripts.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ToolKit;
using Assets.Scripts.Entities.Modifications.Mods;

public class GameManager : MonoBehaviour {

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
            lander.GetComponent<SpaceShipModsBehaviour>().ShipModifications.ToggleModifiCation<AntiGravitySpeedModification>(value);
    }
}
