using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphreDrop : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < 2.6f)
        {
            SphereGravity();
        }
    }

    void SphereGravity()
    {
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log($"In distance");
    }
}