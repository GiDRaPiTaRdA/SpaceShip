﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    public GameObject followingObject;

    private Vector2 viewBox;

    // Use this for initialization
    void Start()
    {
        viewBox = new Vector2(12,6);
    }

    // Update is called once per frame
    void Update()
    {
        if (followingObject != null)
        {
            var objPosition = followingObject.transform.position;
            var camPosition = this.transform.position;

            var deltaPos = new Vector2(camPosition.x - objPosition.x, camPosition.y - objPosition.y);


            var shifPos = new Vector2();

            Debug.Log(deltaPos.x + " " + deltaPos.y);

            if ((viewBox.x / 2 - Math.Abs(deltaPos.x)) < 0){
                shifPos.x = (viewBox.x / 2 - Math.Abs(deltaPos.x)) * (deltaPos.x > 0 ? 1 : -1);
            }

            if ((viewBox.y / 2 - Math.Abs(deltaPos.y)) < 0)
            {
				shifPos.y = (viewBox.y / 2 - Math.Abs(deltaPos.y))*(deltaPos.y>0?1:-1);
            }


            //shifPos = new Vector2(
            //   (viewBox.x / 2 - Math.Abs(deltaPos.x)) * (deltaPos.x > 0 ? 1 : -1),
            //   (viewBox.y / 2 - Math.Abs(deltaPos.y)) * (deltaPos.y > 0 ? 1 : -1));

            //shifPos = new Vector2(
            //    (viewBox.x / 2 - Math.Abs(deltaPos.x)) * (deltaPos. > 0 ? 1 : -1),
            //    (viewBox.y / 2 - Math.Abs(deltaPos.y)) * (deltaPos.y > 0 ? 1 : -1));



            this.transform.position = new Vector3(
                this.transform.position.x+shifPos.x,
                this.transform.position.y+shifPos.y,
                this.transform.position.z);
        }
    }
}