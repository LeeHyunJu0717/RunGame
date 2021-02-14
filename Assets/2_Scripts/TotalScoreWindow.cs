using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScoreWindow : MonoBehaviour
{
    [SerializeField] Text score;

    void Start()
    {
        score.text = "";
        
    }

}
