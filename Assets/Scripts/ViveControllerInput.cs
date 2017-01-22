using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInput : MonoBehaviour {
    public string side;
    // 1
    private SteamVR_TrackedObject trackedObj;
    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update () {
        if (SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost) ==
            Controller.index)
        {
            side = "right";
        }
        else
        {
            side = "left";
        }
        // 1
        if (Controller.GetAxis() != Vector2.zero)
        {
            //Debug.Log(gameObject.name + Controller.GetAxis());
        }

        // 2
        if (Controller.GetHairTrigger())
        {
            //Debug.Log(gameObject.name + " Trigger Press");
        }

        // 3
        if (Controller.GetHairTriggerUp())
        {
            //Debug.Log(gameObject.name + " Trigger Release");
        }

        if (Controller.GetHairTriggerDown())
        {
            
            //Debug.Log(transform.rotation.ToEuler());
        }

        // 4
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Press");
        }

        // 5
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log(gameObject.name + " Grip Release");
        }
    }
}
