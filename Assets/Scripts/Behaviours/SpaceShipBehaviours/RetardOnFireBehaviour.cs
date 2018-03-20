using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class RetardOnFireBehaviour : MonoBehaviour {

    public int DelayInMilliseconds = 500;
    Timer timer;
    bool retarding;

	// Use this for initialization
	void Start () {
        timer = new Timer();
        timer.Elapsed += this.Timer_Elapsed;
        timer.AutoReset = false;
        timer.Interval = DelayInMilliseconds;

        GameManager.SpaceShip.OnFire += this.SpaceShip_OnFire;
	}

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        retarding = false;
    }

    private void SpaceShip_OnFire(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        timer.Stop();
        timer.Start();
        retarding = true;
    }

    // Update is called once per frame
    void Update () {
            GameManager.SpaceShip.Retard(retarding);
	}
}
