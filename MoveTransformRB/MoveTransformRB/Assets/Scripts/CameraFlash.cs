using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlash : MonoBehaviour
{

    public void Flash()
    {
        StartCoroutine(FlashCo());
    }

    IEnumerator FlashCo()
    {
        var light = GetComponent<Light>();
        light.intensity = 0;

        for (float i = 0; i < 0.03f; i += Time.deltaTime)
        {
            light.intensity += i * 333;
            yield return new WaitForSeconds(i);
        }
        for (float i = 0; i < 0.03f; i += Time.deltaTime)
        {
            light.intensity -= i * 333;
            yield return new WaitForSeconds(i);
        }

        light.intensity = 0;
    }
}
