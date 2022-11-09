using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExtinguisherControler : MonoBehaviour
{
    [SerializeField] private Slider angleControll;
    [SerializeField] private Slider currentLevelOfFoamUI;
    [SerializeField] private ParticleSystem extingPE;

    private float currentLevelOfFoam = 10f;
    
    private bool isOn = false;
    public bool isEmpty = false;

    private void Start()
    {
        angleControll.onValueChanged.AddListener(delegate { ChangeAngle(); });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isEmpty)
        {
            extingPE.Play(true);
        }
        else
        {
            extingPE.Stop(true);
            if(currentLevelOfFoam < 10 && Input.GetKeyUp(KeyCode.Space) && !isOn)
            {
                isEmpty = true;
                isOn = true;
                StartCoroutine(ChargingFoam());
            }
        }
    }

    private void ChangeAngle()
    {
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, angleControll.value);
    }

    public bool Emptying(float amount)
    {   
        currentLevelOfFoam -= amount;
        
        ExtinguisherManipulator();

        return currentLevelOfFoam <= 0;
    }


    public void ExtinguisherManipulator()
    {
        currentLevelOfFoamUI.value = currentLevelOfFoam;
        if (currentLevelOfFoam <= 0)
        {
            extingPE.Stop(true);
            if (!isOn)
            {
                isOn = true;
                StartCoroutine(ChargingFoam());
            }
        }
    }

    IEnumerator ChargingFoam()
    {
        isEmpty = true;
        for (float i = currentLevelOfFoam; i <=10; ++i)
        {
            currentLevelOfFoamUI.value = i;
            yield return new WaitForSeconds(0.75f);
        }
        currentLevelOfFoamUI.value = 10f;
        currentLevelOfFoam = 10f;
        isEmpty = false;
        isOn = false;
    }

}
