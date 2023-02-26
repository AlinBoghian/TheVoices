using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTest : MonoBehaviour
{
    private AIAdapter _ai;
    private float _time;
    void Start()
    {
        _ai = global::AIAdapter.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 1)
        {
            _time = 0;
            _ai.startRecord();
            _ai.stopRecord();
        }
        else
        {
            _time += Time.deltaTime;
        }
    }
}
