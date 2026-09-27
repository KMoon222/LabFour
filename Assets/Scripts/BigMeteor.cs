using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class BigMeteor : MonoBehaviour
{
    private int hitCount = 0;
    private CameraActions camScript;
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        GameObject vCam = GameObject.FindWithTag("Camera");
        camScript = vCam.GetComponent<CameraActions>();
        // set camera to zoom in when this object is instantiated
        camScript.zoom = true;
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            camScript.zoom = false;
            Destroy(this.gameObject);
        }

        if (hitCount >= 5)
        {
            camScript.zoom = false;
            // generate cinemachine impulse source when meteor is hit by laser
            impulseSource.GenerateImpulse();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
