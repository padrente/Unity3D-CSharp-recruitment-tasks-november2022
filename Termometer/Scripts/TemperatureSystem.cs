using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureSystem : MonoBehaviour
{
    [SerializeField] private float minTemp = -100;
    [SerializeField] private float maxTemp = 1000;
    [SerializeField] private float avaverageTemp = 50;
    public float currentTemp = 50;

    [SerializeField] private bool inColdZone = false;
    [SerializeField] private bool inHotZone = false;

    [SerializeField] private bool isOn = false;

    [SerializeField] TermometerControler tempControler;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "HotZone")
            inHotZone = true;
        else
            inColdZone = true;
        //Debug.Log("It's inside");
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "HotZone")
            inHotZone = false;
        else
            inColdZone = false;

        //Debug.Log("It's out");
    }

    private void Start()
    {
        tempControler.UpdateTemperature(avaverageTemp);
    }
    private void FixedUpdate()
    {
        if (!inColdZone && !inHotZone && currentTemp != avaverageTemp && !isOn)
        {
            if (currentTemp < avaverageTemp)
                StartCoroutine(SetHigherTemperature());
            else
                StartCoroutine(SetLowerTemperature());
        }

        else if (inColdZone && currentTemp > minTemp && !isOn)
            StartCoroutine(SetLowerTemperature());
        else if (inHotZone && currentTemp < maxTemp && !isOn)
            StartCoroutine(SetHigherTemperature());
    }
   
    
    private IEnumerator SetLowerTemperature()
    {
        isOn = true;
        currentTemp -= 25f;
        yield return new WaitForSeconds(.3f);
        tempControler.UpdateTemperature(currentTemp);
        isOn = false;
    }
    private IEnumerator SetHigherTemperature()
    {
        isOn = true;
        currentTemp += 50;
        yield return new WaitForSeconds(.3f);
        tempControler.UpdateTemperature(currentTemp);
        isOn = false;
    }
}
