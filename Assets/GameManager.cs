using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Vegtables> vaggi = new List<Vegtables>();
    public GameObject vagetableprefab;

    private float lastspawn;
    private float deltaspawn = 1f;

    public Transform trail;
    private Collider2D[] vaggggie;
   
    void Update()
    {
        if(Time.time - lastspawn > deltaspawn)
        {
            Vegtables v = GETVeg();
            float randomx = Random.Range(-1.65f, 1.65f);
            v.Launchvega(Random.Range(1.85f, 2.75f), randomx, -randomx);
            lastspawn = Time.time;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 1;
            trail.position = pos;
           
           vaggggie= Physics2D.OverlapPointAll(new Vector2(pos.x, pos.y),LayerMask.GetMask("vagi"));
            //foreach(Collider2D c2 in vaggggie)
        }
    }

    private Vegtables GETVeg()
    {
        Vegtables v = vaggi.Find(x => !x.ISActive);
        if(v == null)
        {
            v = Instantiate(vagetableprefab).GetComponent<Vegtables>();
            vaggi.Add(v);
        }
        return v;
    }
}
