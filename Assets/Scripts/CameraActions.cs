using Unity.Cinemachine;
using UnityEngine;

public class CameraActions : MonoBehaviour
{
    private CinemachineCamera vCam;
    public bool zoom = false;

    void Start()
    {
        vCam = GetComponent<CinemachineCamera>();
    }

    void Update()
    {
        // zoom camera out when a big meteor spawns
        if (zoom == true)
        {
            float target = zoom ? 85f : 60f;
            vCam.Lens.FieldOfView = Mathf.Lerp(vCam.Lens.FieldOfView, 85f, Time.deltaTime * 2f);
        }
        else
        {
            vCam.Lens.FieldOfView = Mathf.Lerp(vCam.Lens.FieldOfView, 60f, Time.deltaTime * 2f);
        }
    }
}
