using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeManager : MonoBehaviour
{
    private GameObject EnemyCanvas;
    public Slider slider;
    private Text EnemyNameText;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCanvas = GameObject.FindGameObjectWithTag("EnemyCanvas");
        EnemyNameText = EnemyCanvas.transform.Find("EnemyName").GetComponent<Text>();

        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            EnemyNameText.gameObject.SetActive(true);
            EnemyNameText.text = "É{Å[Éã";
            slider.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        EnemyNameText.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
    }
}