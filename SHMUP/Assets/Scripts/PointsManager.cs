using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    public TMP_Text numText;

    // Start is called before the first frame update
    void Start()
    {
        StaticFields.pointsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        numText.text = StaticFields.pointsNum.ToString();
    }
}
