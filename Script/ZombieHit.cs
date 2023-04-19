using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    public int health = 3;
    Animator amin;
    private bool isShoot = false;
    public float shootTime = 1;
    public bool isAtack = false;
    public GameObject isHeath;
    public GameObject hit;
    private AudioSource audioHit;
    public AudioClip audioDead;
    public GameObject player;
    public float dame = 1;
    public float AttackTime=3;
    public float lastAttack = 0;
    private GameObject gameController;
    public AudioClip audioAT;
    public bool IsShooten
    {
        get { return isShoot; }
        set
        {
            isShoot = value;
            upDateLastShootedTime();
        }
    }
    void UpdateLastAtack()
    {
        lastAttack = Time.time;
    }
    private float lastShootedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        amin = gameObject.GetComponent<Animator>();
        ShootenAmin(false);
        IsShooten = false;
        amin.SetBool("isDead", false);
        audioHit = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }
    void upDateLastShootedTime()
    {
        lastShootedTime = Time.time;
    }
    void ShootenAmin(bool isShooten)
    {
        amin.SetBool("isShooten", isShooten);
    }
    public void GetHit(int dame)
    {
        ShootenAmin(true);
        IsShooten = true;
        health -= dame;
        GameObject ish = Instantiate(isHeath, hit.transform.position, hit.transform.rotation) as GameObject;
        audioHit.Play();
        Destroy(ish, 0.5f);
        if (health <= 0)
        {

            Dead();
        }
        
    }
    void Dead()
    {
        audioHit.clip = audioDead;
        audioHit.Play();
        amin.SetBool("isDead", true);
        gameController.GetComponent<GameController>().getPoint();
        Destroy(gameObject,3f);
    }
    void Attack()
    {
        
        amin.SetBool("isAttack", isAtack);
        if(lastAttack+AttackTime<=Time.time)
        {
            audioHit.clip = audioAT;
            audioHit.Play();
            player.GetComponent<PlayerController>().GetHit(dame);
            UpdateLastAtack();
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        if(IsShooten && Time.time>=lastShootedTime+shootTime)
            ShootenAmin(false);
        if(isAtack)
        {
            Attack();

        }
    }
}
