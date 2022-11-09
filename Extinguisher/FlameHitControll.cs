using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHitControll : MonoBehaviour
{
    [SerializeField] private FireControler fireControler;
    [SerializeField] private ExtinguisherControler extinguisherControler;
    [SerializeField] private Transform rayCastPoint;

    private float timeToExtingushPerSec = 1f;
    private float timeToExtingushPerSecOther = 0.5f;

    private void Update()
    {
        var ray = new Ray(rayCastPoint.transform.position, rayCastPoint.transform.forward);
        if (Input.GetKey(KeyCode.Space) && !extinguisherControler.isEmpty)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.name == "FireSource")
                {
                    fireControler.Extinguish(timeToExtingushPerSec * Time.deltaTime);
                }
                else if (hit.collider.name == "ExtinguishArea")
                {
                    fireControler.Extinguish(timeToExtingushPerSecOther * Time.deltaTime);
                }
            }

            extinguisherControler.Emptying(0.9f * Time.deltaTime);
        }
    }
}
