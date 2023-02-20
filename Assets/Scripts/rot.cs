using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("å¸Ç≠ëŒè€")]
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        Debug.Log($"Vector is {quaternion}");
        this.transform.rotation = quaternion;
    }
}
