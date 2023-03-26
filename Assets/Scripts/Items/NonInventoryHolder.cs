using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace inventory
{
    [System.Serializable]
    public class NonInventoryHolder : MonoBehaviour
    {
        //=====�ϐ��̐錾=====
        //ItemObject
        //[SerializeField] private int inventorySize;
        public ItemSystemObject itemSystemObject;
        [SerializeField] public NonInventorySystem noninventorySystem;
        public NonInventorySystem NonInventorySystem => noninventorySystem;
        public static UnityAction<NonInventorySystem> OnInventorySystemRequested;
        private void Awake()
        {
            noninventorySystem = new NonInventorySystem(itemSystemObject);
            var gmobject = noninventorySystem.DropItem();
            Debug.Log($"�I�΂ꂽ�A�C�e����{gmobject}");
            Instantiate(gmobject.prefab, new Vector3(0, 0, 0), Quaternion.identity);
            //Debug.Log($"�I�΂ꂽ�A�C�e����{noninventorySystem.RandomChooseItem()}");
        }

    }
}

