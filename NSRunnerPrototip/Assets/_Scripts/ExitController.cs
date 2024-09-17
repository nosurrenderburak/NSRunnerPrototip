using System;
using System.Collections;
using System.Collections.Generic;
using NoSurrender;
using UnityEngine;

public class ExitController : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConsts.HERO_BUFFER))
        {
            Destroy(other.gameObject);
        }
    }
}
