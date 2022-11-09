using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    GameObject destroyPoint;

    private void Start()
    {
        destroyPoint = GameObject.FindGameObjectWithTag("DestroyPoint");
    }

    private void Update()
    {
        if (transform.position.y < destroyPoint.transform.position.y)
            Destroy(gameObject);
    }
}
