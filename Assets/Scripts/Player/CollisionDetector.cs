using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    public TriggerEvent onTriggerStay = new TriggerEvent();
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }
    //[Serializable]
    public class TriggerEvent: UnityEvent<Collider>
    {

    }
}
