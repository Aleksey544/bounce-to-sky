using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isShowedByCamera;

    private void OnBecameVisible()
    {
        isShowedByCamera = true;
    }

    private void OnBecameInvisible()
    {
        if (isShowedByCamera)
        {
            DeActivate();
        }
    }

    public void DeActivate()
    {
        Debug.Log("Deactivate "+gameObject.name);
        isShowedByCamera = false;
        gameObject.SetActive(false);
    }
}
