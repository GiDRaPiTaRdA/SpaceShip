using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using UnityEngine;

public class TorgueStabelizationBehaviour : MonoBehaviour
{
    public float stabelization = 20;
    Rigidbody2D rigidbodyInstance;

    // Use this for initialization
    void Start()
    {
        rigidbodyInstance = GetComponent<Rigidbody2D>();

        GameManager.SpaceShip.Stabelization = stabelization;
        GameManager.SpaceShip.OnStabelize += this.SpaceShip_OnStabelize;
    }

    // Update is called once per frame
    void Update()
    {
        float stabelisingForce = rigidbodyInstance.angularVelocity * 0.001f * GameManager.SpaceShip.Stabelization * Time.timeScale;

        GameManager.SpaceShip.Stabelize(stabelisingForce);
    }

    private void SpaceShip_OnStabelize(object sender, SpaceShipEventArgs e)
    {
        rigidbodyInstance.AddTorque(-e.StabelizingForce, ForceMode2D.Force);
    }

}
