using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public GameObject player;
    public GameObject lookAtTarget;
    float moveSpeed;
    public float minmoveSpeed=0.05f;
    public float maxmoveSpeed = 0.3f;
    public float attackrange = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookAtTarget = GameObject.FindGameObjectWithTag("LookAt");
        UpdateMoveSpeed();
    }
    void UpdateMoveSpeed()
    {
        moveSpeed = Random.Range(minmoveSpeed, maxmoveSpeed);
    }
    void Move()
    {
        if (player == null||lookAtTarget==null)
            return;
        if(Vector3.Distance(transform.position,player.transform.position)>attackrange)
        {
            transform.LookAt(lookAtTarget.transform.position);
            transform.position = Vector3.Lerp(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<ZombieHit>().isAtack = true;
            gameObject.GetComponent<ZombieMove>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
