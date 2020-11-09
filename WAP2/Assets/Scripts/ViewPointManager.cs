using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ViewPointManager : MonoBehaviour
{
    [SerializeField]
    private Camera playerCam = null;
    [SerializeField]
    private float thirdPersonCameraDistance = 5f;
    private bool isOnFirstPersonMode = false;


    public void ToggleViewPoint()
    {
        if (isOnFirstPersonMode)
            ChangeToThirdPersonMode();
        else
            ChangeToFirstPersoneMode();
    }

    private void ChangeToThirdPersonMode()
    {
        var position = transform.position - transform.forward * thirdPersonCameraDistance;
        position.y += thirdPersonCameraDistance;

        playerCam.transform.position = position;
        playerCam.transform.LookAt(transform.position);
    }

    private void ChangeToFirstPersoneMode()
    {
        var position = transform.position;
        position.y += 1.5f;

        playerCam.transform.position = position;
        playerCam.transform.LookAt(transform.position + transform.forward);
        playerCam.transform.Translate(0, 0, 0.5f);
    }

    private void OnEnable()
    {
        ToggleViewPoint();
    }
}

