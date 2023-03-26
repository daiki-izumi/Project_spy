using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldInfoDisplay : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI dayCount;
    [SerializeField] private TextMeshProUGUI timezoneCount;
    [SerializeField] private WorldSystem worldSystem;

    // Start is called before the first frame update
    void Awake()
    {
        ClearTime();
    }

    // Update is called once per frame
    void Update()
    {
        dayCount.text = worldSystem.nowDays.ToString();
        timezoneCount.text = worldSystem.nowTimeZone.ToString();
    }

    void ClearTime()
    {
        dayCount.text = "";
        timezoneCount.text = "";
    }

}
