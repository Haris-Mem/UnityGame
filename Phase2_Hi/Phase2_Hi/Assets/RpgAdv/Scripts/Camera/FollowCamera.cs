using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        float currentRotationAngle = transform.eulerAngles.y;
        float wantedRotationAngle = target.eulerAngles.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, 0.2f);

        transform.position = new Vector3(target.position.x, 5.0f, target.position.z);

        // rotation around Y axis
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // rotating vector forward
        Vector3 rotationPosition = currentRotation * Vector3.forward;

        transform.position = transform.position - rotationPosition * 10;

        transform.LookAt(target);
    }
}
