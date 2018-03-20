using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Behaviours
{
    public class StarsMonitoring : MonoBehaviour
    {

        public int countStars = 0;

        SpriteRenderer render;

        // Use this for initialization
        void Start()
        {
            render = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.SpaceShip.Stars >= countStars)
            {
                render.maskInteraction = SpriteMaskInteraction.None;
            }
        }
    }
}
