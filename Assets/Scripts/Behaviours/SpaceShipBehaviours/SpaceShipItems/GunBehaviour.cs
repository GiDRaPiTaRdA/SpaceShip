using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolKit;
using Assets.ToolKit;

public class GunBehaviour : MonoBehaviour {

    public GameObject misslePrefab;

	// Use this for initialization
	void Start () {
            GameManager.SpaceShip.OnFire += this.SpaceShip_OnFire;
	}


    private void SpaceShip_OnFire(object sender, Assets.Scripts.Entities.SpaceShipEventArgs e)
    {
        Vector2 shiftForward = new Vector2(0, 0.02f).DirrectionDependentBehavoir(GetComponent<Transform>().eulerAngles.z/Mathf.Rad2Deg);

        var missle = Instantiate(misslePrefab, transform.position + new Vector3(shiftForward.x, shiftForward.y,0), transform.rotation);

        missle.MoveTo(this.transform);
    }

}
