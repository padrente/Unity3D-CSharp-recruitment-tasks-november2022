using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControler : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float currentLevelOfFlame = 10f;
    private float startLevelOfFlame;

    [SerializeField] private ParticleSystem flamePE;

    [SerializeField] private bool isLit = true;

    private float lastExtinguished = 0;
    private float regenFlameDelay = 1f;
    private float regenRate = 2.5f;

    private void Start()
    {
        startLevelOfFlame = flamePE.emission.rateOverTime.constant;
    }

    private void Update()
    {
        if(isLit && currentLevelOfFlame < 10f && Time.time - lastExtinguished >= regenFlameDelay)
        {
            currentLevelOfFlame += regenRate * Time.deltaTime;
            FlameManipulator();
        }
    }

    public bool Extinguish(float amount) 
    {
        lastExtinguished = Time.time;

        currentLevelOfFlame -= amount;

        FlameManipulator();

        if (isLit && currentLevelOfFlame <= 0)
            isLit = false;

        return currentLevelOfFlame <= 0;
    }

    public void FlameManipulator()
    {
        if(isLit)
        {
            var emission = flamePE.emission;
            emission.rateOverTime = currentLevelOfFlame * startLevelOfFlame / 10;
        }
    }
}
