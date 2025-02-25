﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class ButtonPress : MonoBehaviour
{
    public GameObject platform;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject gear;
    PlatformMovement PMS;
    GearStay GSS;
    Renderer rend;

    public bool active = false;

	void Start ()
    {
        PMS = platform.GetComponent<PlatformMovement>();
        GSS = gear.GetComponent<GearStay>();
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            rend.enabled = true;
            if (other.gameObject == LeftHand || other.gameObject == RightHand)
            {
                PMS.riding = true;
                GSS.rotate = true;
                Destroy(gameObject);
            }
        }        
    }
}