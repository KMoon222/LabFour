using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    // assign the gameobjects that are the centers of the player and enemy 
    public Transform playerCenter;
    public Transform enemyCenter;

    // assign starting values as a baseline, though they change dynamically
    public float speed = 45f;
    private float radius = 5f;
    private float currentAngle = 0f;

    // player and enemy positions, to calculate magnitude/ distance between them
    private Vector3 playerPos;
    private Vector3 enemyPos;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (playerCenter == null)
        {
            playerCenter = player.transform;
            enemyCenter = transform;
        }

    }

    void Update()
    {
        if (player != null)
        {
            // calculate magnitude/ distance between the player and enemy
            playerPos = playerCenter.position;
            enemyPos = enemyCenter.position;
            radius = (playerPos - enemyPos).magnitude;

            // change speed based on how far away the enemy is from the player
            var distanceSquared = (playerPos - enemyPos).sqrMagnitude;
            speed = Mathf.Lerp(20f, 120f, Mathf.Clamp01(distanceSquared / 5f));

            //      if speed is getting faster the closer the enemy gets, use the following
            //speed = distanceSquared * 2.5f;
            //speed = Mathf.Lerp(180f, 20f, Mathf.Clamp01(radius / 5f));
            //Debug.Log(distanceSquared);

            // find angle to use for rotation, set offset to move
            currentAngle += speed * Time.deltaTime;
            Quaternion rot = Quaternion.Euler(0f, 0f, currentAngle);
            Vector3 offset = rot * Vector3.right * radius;

            // move enemy around player, and rotate it to face the player
            transform.position = playerCenter.position + offset;
            transform.rotation = rot * Quaternion.Euler(0, 0, 90f);
        }
    }

}

