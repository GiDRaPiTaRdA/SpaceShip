using GameControls;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolKit;
using Assets.Scripts.Entities;
using System.Linq;

public partial class SpaceShipModsBehaviour : MonoBehaviour
{
    private SpaceShipModifications shipModifications;
    public SpaceShipModifications ShipModifications => this.shipModifications ?? (this.shipModifications = new SpaceShipModifications(this.gameObject));
}




