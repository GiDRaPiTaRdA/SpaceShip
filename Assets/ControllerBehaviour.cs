using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using GameControls;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControllerBehaviour : MonoBehaviour
{
    public GameObject controlledObject;

    private SpaceShip ship;

    // Use this for initialization
    void Start()
    {
        this.ship = this.controlledObject.GetComponent<SpaceShipBehaviour>().SpaceShip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (this.ship != null)
            {

#if UNITY_STANDALONE //PC

                // FIRE
                if(Input.GetKeyDown(KeyCode.F))this.ship.Fire();

                // TRUST
                this.ship.Trust(Input.GetKey(KeyBinding.TrustUp.GetKeyCode()));

                // RETARD
                this.ship.Retard(Input.GetKey(KeyCode.S));

                // TURN LEFT
                this.ship.TurnLeft(Input.GetKey(KeyBinding.TurnLeft.GetKeyCode()));

                // TURN RIGHT
                this.ship.TurnRight(Input.GetKey(KeyBinding.TurnRight.GetKeyCode()));
               
                    
#elif UNITY_ANDROID // PHONE

                // FIRE
                if (CrossPlatformInputManager.GetButtonDown("Fire")) this.ship.Fire();

                // TRUST
                this.ship.Trust(CrossPlatformInputManager.GetButton("Trust"));

                // RETARD
                this.ship.Retard(CrossPlatformInputManager.GetButton("Retard"));

                // TURN LEFT
                this.ship.TurnLeft(CrossPlatformInputManager.GetButton("TurnLeft"));

                // TURN RIGHT
                this.ship.TurnRight(CrossPlatformInputManager.GetButton("TurnRight"));
#endif
            }
        }
    }
}
