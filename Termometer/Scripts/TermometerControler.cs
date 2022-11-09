using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TermometerControler : MonoBehaviour
{
    [SerializeField] Material baseMaterial;
    [SerializeField] TextMeshProUGUI tempCounter;

    public void UpdateTemperature(float temp)
    {
        tempCounter.text = temp.ToString();

        if (temp >= 100)
            baseMaterial.color = Color.red;
        else if (temp < 100 && temp > -20)
            baseMaterial.color = Color.green;
        else if (temp <= -20)
            baseMaterial.color = Color.blue;
    }
}
