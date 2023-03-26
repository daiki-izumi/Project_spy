using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using playerinfo;

public class DisplayHPvar : MonoBehaviour
{
    public Slider slider;
    public GameObject MaingameObject;
    // Start is called before the first frame update
    void Start()
    {
        var system = MaingameObject.GetComponent<PlayerHolder>();
        slider.value = system.characterSystem.NowHp;
        Debug.Log($"HP‚Í{system.characterSystem.NowHp}");
    }
    void Update()
    {
        //slider.value = system.characterSystem.NowHp;
    }

}
