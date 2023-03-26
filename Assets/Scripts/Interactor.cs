using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyparas;

public class Interactor : MonoBehaviour
{
    //=====定義領域=====
    //キー配置のクラス
    private KeyParameter parasKey;
    public Transform InteractionPoint;
    public LayerMask InteractionLayer;
    public float InteractionPointRadius = 1f;

    public bool IsInteracting { get; private set; }

    private void Awake()
    {
        //キー配置の読み込み
        parasKey = new KeyParameter();
    }
    private void Update()
    {
        var collidars = Physics.OverlapSphere(InteractionPoint.position, InteractionPointRadius, InteractionLayer);

        if (Input.GetKeyDown(parasKey.pickup))
        {
            Debug.Log("Pressed");
            for (int i = 0; i < collidars.Length; i++)
            {
                var interactable = collidars[i].GetComponent<IInteractable>();
                if (interactable != null) StartInteraction(interactable);
            }
        }
    }
    void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccessful);
        IsInteracting = true;
    }
    void EndInteraction()
    {
        IsInteracting = false;
    }
}
