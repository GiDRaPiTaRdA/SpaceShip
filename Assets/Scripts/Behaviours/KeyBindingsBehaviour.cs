using GameControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingsBehaviour : MonoBehaviour {

    public KeyCode trustUp;
    public KeyCode turnLeft;
    public KeyCode turnRight;

    // Use this for initialization
    void Start () {
        ApplicationKeyBindings.TrustUp = trustUp;
        ApplicationKeyBindings.TurnLeft = turnLeft;
        ApplicationKeyBindings.TurnRight = turnRight;
    }
}
