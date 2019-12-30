using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensetiveX = 3f;
    public float sensetiveY = 3f;

    public float minX = -360;
    public float minY = -60;
    public float maxX = 360;
    public float maxY = 60;

    private Quaternion originalRot;
    private float rotX = 0;
    private float rotY = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb)
        {
            rb.freezeRotation = true;
        }

        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * sensetiveX;
        rotY += Input.GetAxis("Mouse Y") * sensetiveY;

        rotX = rotX % 360;
        rotY = rotY % 360;


        rotX = Mathf.Clamp(rotX, minX, maxX);
        rotY = Mathf.Clamp(rotY, minY, maxY);


        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

        transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }
}
