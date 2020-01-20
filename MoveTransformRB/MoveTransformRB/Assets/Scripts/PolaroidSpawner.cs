using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidSpawner : MonoBehaviour
{
    public Polaroid polaroid;
    public Photo polaroidCamera;
    public CameraFlash flash;
    private Polaroid lastPolaroid;
    private bool isDone = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isDone)
            {
                Snap();
            }
        }
    }

    void Snap()
    {
        var newPolaroid = Instantiate(polaroid, transform.position + transform.up * -0.5f, transform.rotation * Quaternion.Euler(90, 0, 0));
        newPolaroid.transform.parent = transform;
        if (lastPolaroid)
        {
            lastPolaroid.GetComponent<Rigidbody>().isKinematic = false;
            lastPolaroid.hitbox.isTrigger = false;
            lastPolaroid.transform.SetParent(null);
        }
        lastPolaroid = newPolaroid;
        newPolaroid.SetImage(polaroidCamera.GetImage());
        StartCoroutine(NewPolaroid(newPolaroid));
        flash.Flash();
    }

    IEnumerator NewPolaroid(Polaroid polaroid)
    {
        isDone = false;

        var done = Time.time + 1;
        while (Time.time < done)
        {
            polaroid.transform.localPosition += Vector3.forward * Time.deltaTime;
            yield return null;
        }

        isDone = true;
    }
}
