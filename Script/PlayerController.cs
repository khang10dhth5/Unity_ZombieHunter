using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int dame = 1;
    public float TimeHit = 0.3f;
    public float LastHitTime = 0;
    private Animator amin;
    public GameObject smoke;
    public GameObject GunHit;
    private AudioSource audio;
    public float playerheath = 10;
    private GameObject gameController;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLastHitTime();
        amin = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        slider.maxValue = playerheath;
        slider.value = playerheath;
        slider.minValue = 0;
    }
    void UpdateLastHitTime()
    {
        LastHitTime = Time.time;
    }
    void setFireAmin(bool isGun)
    {
        amin.SetBool("isGun", isGun);
    }
    void Fire()
    {
        if(Time.time>=LastHitTime+TimeHit)
        {
            #if UNITY_IOS || UNITY_ANDROID
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //tia vuông góc với màn hình đi qua tọa độ chuột
                RaycastHit hit;// vật thể tia trên chạm đến
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag.Equals("Zombie"))
                    {
                        
                        setFireAmin(true);
                        
                        hit.transform.gameObject.GetComponent<ZombieHit>().GetHit(dame);
                    }
                }
            #else
                RaycastHit hit;// vật thể tia trên chạm đến
                if (Physics.Raycast(GunHit.transform.position,GunHit.transform.forward, out hit))
                {
                    if (hit.transform.tag.Equals("Zombie"))
                    {
                        
                        setFireAmin(true);
                        hit.transform.gameObject.GetComponent<ZombieHit>().GetHit(dame);
                    }
                }
            #endif

            UpdateLastHitTime();
        }
        else
        {
            setFireAmin(false);
        }
        

    }
    public void GetHit(float damehit)
    {
        playerheath = playerheath - damehit;
        slider.value = playerheath;
        if(playerheath <= 0)
        {
            gameController.GetComponent<GameController>().EndGame();
        }
    }
    void InsSmoke()
    {
        GameObject sm = Instantiate(smoke, GunHit.transform.position, GunHit.transform.rotation) as GameObject;
        Destroy(sm, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Fire();
            audio.Play();
            InsSmoke();
        }
    }
}
