using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtPoint;
    public float currentPoint = 0;
    public GameObject menu;
    void Start()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void getPoint()
    {
        currentPoint++;
        txtPoint.text = "Point: " + currentPoint.ToString();
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Debug.Log("end");
        menu.SetActive(true);
    }
}
