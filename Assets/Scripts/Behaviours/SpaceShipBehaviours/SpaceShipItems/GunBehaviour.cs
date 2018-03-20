using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Behaviours.SpaceShipBehaviours;
using UnityEngine;
using ToolKit;
using Assets.ToolKit;

public class GunBehaviour : ShipMonoBehaviour {

    public GameObject misslePrefab;

	// Use this for initialization
	protected override void Start ()
	{
	    base.Start();

        this.SpaceShip.OnFire += this.SpaceShip_OnFire;
	}


    private void SpaceShip_OnFire(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        Vector2 shiftForward = new Vector2(0, 0.02f).DirrectionDependentBehavoir(this.GetComponent<Transform>().eulerAngles.z/Mathf.Rad2Deg);

        var missle = Instantiate(this.misslePrefab, this.transform.position + new Vector3(shiftForward.x, shiftForward.y,0), this.transform.rotation);

        missle.MoveTo(this.transform);
    }

}
