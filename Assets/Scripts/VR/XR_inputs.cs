using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum WayOfInputAcces
{
    XR_Node,
    Charecteristics
}

public class XR_inputs : MonoBehaviour
{
    public WayOfInputAcces accessWay;
    Animator anmrHand;
    InputDevice device;
    [Header("Types References")]
    public XRNode handSideNode;
    public InputDeviceCharacteristics handSideCaracteristics;

    float gripOut;
    bool primaryOut;
    bool secoundaryOut;
    float triggerOut;
    // Start is called before the first frame update
    void Start()
    {
        //anmrHand = GetComponent<Animator>();
        GetDeivice();
        transform.eulerAngles = new Vector3(30.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        //https://docs.unity3d.com/Manual/xr_input.html
        //Three fingers ---- uses the grip
        device.TryGetFeatureValue(CommonUsages.grip, out gripOut);
        anmrHand.SetFloat("ThreeFingers", gripOut);

        //Thumb Finger - Touch = Not All the way down, bottom = all the way down ---- primary A/X Secundary B/Y
        device.TryGetFeatureValue(CommonUsages.primaryTouch, out primaryOut);
        if (primaryOut)
        {
            device.TryGetFeatureValue(CommonUsages.primaryButton, out primaryOut);
            if (primaryOut)//Could be change to slow build up
            {
                anmrHand.SetFloat("Thumb", 1f);
                Debug.Log("Se presiono el boton");
            }
            else
            {
                anmrHand.SetFloat("Thumb", 0.5f);
            }
        }

        //Index FInger ---- uses the trigger
        device.TryGetFeatureValue(CommonUsages.trigger, out triggerOut);
        anmrHand.SetFloat("Index", triggerOut);

    }

    void GetDeivice()
    {
        switch (accessWay)
        {
            case WayOfInputAcces.Charecteristics:
                List<InputDevice> devices = new List<InputDevice>();
                InputDevices.GetDevicesWithCharacteristics(handSideCaracteristics,devices);
                if (devices.Count == 1)
                {
                    device = devices[0];
                }
                else if (devices.Count > 0)
                {
                    Debug.LogError("More than one device with specific characteristics");
                }
                else
                {
                    Debug.Log("No controller found");
                }
                break;
            case WayOfInputAcces.XR_Node:
                if(InputDevices.GetDeviceAtXRNode(handSideNode)!= null)
                {
                    device = InputDevices.GetDeviceAtXRNode(handSideNode);
                }
                else
                {
                    Debug.Log("No controller found");
                }
                break;
        }
    }
}
