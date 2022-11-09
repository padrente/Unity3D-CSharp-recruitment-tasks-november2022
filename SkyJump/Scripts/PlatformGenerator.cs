using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformObj;
    [SerializeField] Transform generatePlatformPoint;
    float distanceBetween;


    private void Update()
    {
        if(transform.position.y < generatePlatformPoint.position.y)
        {

            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), transform.position.y + Mathf.Clamp(distanceBetween, 2.5f, 4.75f), transform.position.z);

            Instantiate(platformObj, transform.position, transform.rotation);
        }


    }
}
