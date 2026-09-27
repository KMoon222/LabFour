using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    private EnemyMovement enemyMovement;

    void Start()
    {
        // generate cinemachine impulse source when meteor is hit by laser
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        //transform.Translate(Vector3.down * Time.deltaTime * 2f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);
            impulseSource.GenerateImpulse();
            Destroy(this.gameObject);
        }
    }
}
