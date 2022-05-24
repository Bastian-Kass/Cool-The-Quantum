using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class TriggerEvent : UnityEvent { }

public class TriggerWatcher : MonoBehaviour
{
    public TriggerEvent triggerPress;

    private bool lastTriggerState = false;
    private List<InputDevice> devicesWithTrigger;

    private void Awake()
    {
        if (triggerPress == null)
        {
            triggerPress = new TriggerEvent();
        }

        devicesWithTrigger = new List<InputDevice>();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach(InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithTrigger.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out discardedValue))
        {
            devicesWithTrigger.Add(device); // Add any devices that have a primary button.
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithTrigger.Contains(device))
            devicesWithTrigger.Remove(device);
    }

    void Update()
    {
        bool tempState = false;
        foreach (var device in devicesWithTrigger)
        {
            bool triggerButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonState) // did get a value
                        && triggerButtonState // the value we got
                        || tempState; // cumulative result from other controllers
        }

        if (tempState != lastTriggerState) // Button state changed since last frame
        {
            if(tempState)
                triggerPress.Invoke();
                
            lastTriggerState = tempState;
        }
    }
}