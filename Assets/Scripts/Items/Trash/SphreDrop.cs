using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphreDrop : MonoBehaviour
{
    public GameObject target;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Vector3 cube = player.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < 2.6f)
        {
            itemPick();
        }
    }
    void itemPick()
    {

        Debug.Log("Picked");
        Destroy(this.gameObject);
    }
}