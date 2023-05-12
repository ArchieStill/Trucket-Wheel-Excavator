using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{
    public Camera FollowCamera;
    public Camera StaticCamera;
    public Camera EndingCamera;

    void Start()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        FollowCamera.enabled = true;
        StaticCamera.enabled = false;
        EndingCamera.enabled = false;

        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        StaticCamera.GetComponent<AudioListener>().enabled = false;
        EndingCamera.GetComponent<AudioListener>().enabled = false;
    }
}
