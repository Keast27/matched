using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour
{
    public bool swiped = false;
    public bool offScreen = false;

    void OnBecameInvisible()
    {
        swiped = true;
        offScreen = true;
        transform.Translate(Vector3.zero);
    }
}
