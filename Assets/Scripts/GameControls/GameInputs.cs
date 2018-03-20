using GameControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Entities;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts.GameControls
{
    public class GameInputs : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Time.timeScale==1) {

#if UNITY_STANDALONE
            // TRUST
                 GameManager.SpaceShip.Trust(Input.GetKey(KeyBinding.TrustUp.GetKeyCode()));

                GameManager.SpaceShip.Retard(Input.GetKey(KeyCode.S));

                // TURN LEFT
                GameManager.SpaceShip.TurnLeft(Input.GetKey(KeyBinding.TurnLeft.GetKeyCode()));

                // TURN RIGHT
                GameManager.SpaceShip.TurnRight(Input.GetKey(KeyBinding.TurnRight.GetKeyCode()));

                if(Input.GetKeyDown(KeyCode.F))
                    GameManager.SpaceShip.Fire();

#else

                SpaceShip ship = GameObject.FindGameObjectWithTag(GameTags.Lander)?.GetComponent<SpaceShipBehaviour>()?.SpaceShip;

                if (ship != null)
                {

                    // FIRE
                    if (CrossPlatformInputManager.GetButtonDown("Fire"))
                        ship.Fire();

                    // TRUST
                    ship.Trust(CrossPlatformInputManager.GetButton("Trust"));

                    // RETARD
                    ship.Retard(CrossPlatformInputManager.GetButton("Retard"));

                    // TURN LEFT
                    ship.TurnLeft(CrossPlatformInputManager.GetButton("TurnLeft"));

                    // TURN RIGHT
                    ship.TurnRight(CrossPlatformInputManager.GetButton("TurnRight"));
                }
#endif
            }

        }
    }
}
