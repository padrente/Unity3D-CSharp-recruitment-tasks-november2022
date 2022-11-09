using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeReference] Text pointText;
    int score = 0;


    public void AddPoint()
    {
        ++score;
        pointText.text = score.ToString();
    }
}
