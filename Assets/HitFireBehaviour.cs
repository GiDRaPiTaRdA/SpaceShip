using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFireBehaviour : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
