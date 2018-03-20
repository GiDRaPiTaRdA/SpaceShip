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
        ApplicationKeyBindings.TrustUp = this.trustUp;
        ApplicationKeyBindings.TurnLeft = this.turnLeft;
        ApplicationKeyBindings.TurnRight = this.turnRight;
    }
}
