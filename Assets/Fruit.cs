using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject SlicedFruit;
    public float startforce = 15f;
    public bool issliced;
    Rigidbody2D rd;

    Uimanager uimanager;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.AddForce(transform.up * startforce, ForceMode2D.Impulse);
        uimanager = FindObjectOfType<Uimanager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag =="Blade")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject spawnfurit= Instantiate(SlicedFruit, transform.position, rotation);
            Destroy(spawnfurit, 5f);
            Destroy(gameObject);
            issliced = true;
            uimanager.increamentscore(1);
        }
    }
}
