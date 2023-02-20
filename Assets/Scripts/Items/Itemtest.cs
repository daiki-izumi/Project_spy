using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Itemtest : MonoBehaviour
{
    public UnityEvent onPickUp;
    private GameObject player;
    bool inArea = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        /*
        Vector3 itempos = this.transform.position;
        Vector3 playerpos = 
        if (inArea)
        {
            Debug.Log("in Area");
        }*/
    }
    public void PickUp()
    {
        Debug.Log("Picked");
        //onPickUp.Invoke();
        //Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider collidar)
    {
        if(collidar.gameObject.tag == "Player")
        {
            Debug.Log("In");
            inArea = true;

        }
    }
    public void OnTriggerExit(Collider collidar)
    {
        Debug.Log("Out");
        inArea = false;
    }
}
