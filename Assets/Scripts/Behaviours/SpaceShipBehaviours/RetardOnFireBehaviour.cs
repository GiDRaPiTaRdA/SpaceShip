using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;

public class RetardOnFireBehaviour : ShipMonoBehaviour {

    public int DelayInMilliseconds = 500;
    Timer timer;
    bool retarding;

	// Use this for initialization
    protected override void Start ()
    {
        base.Start();

	    this.timer = new Timer();
	    this.timer.Elapsed += this.Timer_Elapsed;
	    this.timer.AutoReset = false;
	    this.timer.Interval = this.DelayInMilliseconds;

        this.SpaceShip.OnFire += this.SpaceShip_OnFire;
	}

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        this.retarding = false;
    }

    private void SpaceShip_OnFire(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        this.timer.Stop();
        this.timer.Start();
        this.retarding = true;
    }

    // Update is called once per frame
    void Update () {
            this.SpaceShip.Retard(this.retarding);
	}
}
