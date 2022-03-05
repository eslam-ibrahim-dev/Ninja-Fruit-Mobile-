using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegtables : MonoBehaviour
{
    public bool ISActive { set; get; }
    private float veritcalvelcity, speed;
    private const float Gravity = 2f;

    public void Launchvega(float vvelcity,float xspeed ,float xstart)
    {
        ISActive = true;
        speed = xspeed;
        veritcalvelcity = vvelcity;
        transform.position = new Vector3(xstart, 0, 0);
    }
    private void Start()
    {
        Launchvega(2f, 1f, 1f);
    }
    void Update()
    {
        if(!ISActive)
        {
            return;
        }
        veritcalvelcity -= Gravity * Time.deltaTime;
        transform.position += new Vector3(speed, veritcalvelcity, 0) * Time.deltaTime;
        if(transform.position.y < -1)
        {
            ISActive = false;
        }
    }
    public void Slice()
    {
        if(veritcalvelcity < 0.5f)
        {
            veritcalvelcity = 0.5f;
        }
        speed = speed * 0.5f;
    }
}
