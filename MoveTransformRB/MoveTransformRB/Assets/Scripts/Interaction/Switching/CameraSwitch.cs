using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CameraSwitch : MonoBehaviour
{
    public MeshRenderer Mesh = null;
    public GameObject controller = null;

    public void Awake()
    {
        Mesh = GetComponentInChildren<MeshRenderer>();
    }
    public void CameraSwitching()
    {
        if (Mesh.enabled == false)
        {
            Mesh.enabled = true;
            controller.SetActive(false);
        }
        else
        {
            Mesh.enabled = false;
            controller.SetActive(true);
        }
    }
}
