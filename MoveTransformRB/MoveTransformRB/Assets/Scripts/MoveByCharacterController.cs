using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveByCharacterController : MonoBehaviour {

  [SerializeField]
  float movementSpeed;

  [SerializeField]
  float rotationSpeed;

  [SerializeField]
  float gravity;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    public Transform marker;

    [SerializeField]
    public LineRenderer line;

    [SerializeField]
    public Camera camera;

    [SerializeField]
    private Image image;

    [SerializeField]
    public float fadeDuration;

    [SerializeField]
    public Transform spawnPoint;


    CharacterController characterController;

  // Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
        UnityEngine.Input.GetJoystickNames();
	}
	
	// Update is called once per frame
	void Update () {

        Movement();
        Teleportation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(TeleportToSpawn());
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
        Vector3 deltaPosition = new Vector3(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime);
        deltaPosition = transform.TransformDirection(deltaPosition);
        characterController.SimpleMove(deltaPosition);
    }

    private void Teleportation()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance))
        {
            if (Vector3.Angle(hitInfo.normal, Vector3.up) < 30)
            {
                var overlaps = Physics.OverlapCapsule(hitInfo.point + Vector3.up * 0.55f, hitInfo.point + Vector3.up * 1.5f, 0.5f);
                if (overlaps.Length == 0)
                {
                    marker.gameObject.SetActive(true);
                    marker.transform.position = hitInfo.point;


                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        StartCoroutine(TeleportRoutine(hitInfo.point));
                    }
                    return;


                }
            }
        }

        else
        {
            marker.gameObject.SetActive(false);
        }
    }

    IEnumerator TeleportRoutine(Vector3 position)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / fadeDuration)
        {
            image.color = new Color(0, 0, 0, i);
            yield return null; //wait exactly 1 frame
        }
        transform.position = position + Vector3.up;
        for (float i = 0; i < 1; i += Time.deltaTime / fadeDuration)
        {
            image.color = new Color(0, 0, 0, 1-i);
            yield return null;
        }
    }

    IEnumerator TeleportToSpawn()
    {
        for (float i = 0; i < 1; i += Time.deltaTime / fadeDuration)
        {
            image.color = new Color(0, 0, 0, i);
            yield return null; //wait exactly 1 frame
        }
        transform.position = spawnPoint.position;
        yield return new WaitForSeconds(0.5f);
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
            image.color = new Color(0, 0, 0, 1 - i);
            yield return null;
        }
    }

    private void Movement()
    {

    }
}
