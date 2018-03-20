using GameControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets.Scripts.GameControls
{
    public class GameInputs : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

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

                // FIRE
                if (CrossPlatformInputManager.GetButtonDown("Fire"))
                    GameManager.SpaceShip.Fire();

                // TRUST
                GameManager.SpaceShip.Trust(CrossPlatformInputManager.GetButton("Trust"));

                // RETARD
                GameManager.SpaceShip.Retard(CrossPlatformInputManager.GetButton("Retard"));

                // TURN LEFT
                GameManager.SpaceShip.TurnLeft(CrossPlatformInputManager.GetButton("TurnLeft"));

                // TURN RIGHT
                GameManager.SpaceShip.TurnRight(CrossPlatformInputManager.GetButton("TurnRight"));
#endif
            }

        }
    }
}
