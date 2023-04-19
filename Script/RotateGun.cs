using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    
    public Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCursor();
        
    }
    void LookAtCursor()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition); //tia vuông góc với màn hình đi qua tọa độ chuột
        RaycastHit hit;// vật thể tia trên chạm đến
        if(Physics.Raycast(ray,out hit))
        {
            target = hit.point;
        }
        transform.LookAt(target);
    }
}
