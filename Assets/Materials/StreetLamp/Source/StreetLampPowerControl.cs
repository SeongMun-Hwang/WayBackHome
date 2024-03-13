using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLampPowerControl : MonoBehaviour
{
    private Light lampLight;
    private void Start()
    {
        lampLight = GetComponentInChildren<Light>();
    }
    void Update()
    {
        if (MoveSun.Instance.nowTime > 12 && MoveSun.Instance.nowTime < 24)
        {
            lampLight.enabled = true;
        }
        else
        {
            lampLight.enabled = false;
        }
    }
}
