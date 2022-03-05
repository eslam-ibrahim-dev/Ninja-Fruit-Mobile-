using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour
{
    Uimanager uimanager;

    private void Start()
    {
        uimanager = FindObjectOfType<Uimanager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fruit")
        {
            print("heelo");
            uimanager.losePoints();
            print(uimanager.lifepoints);
        }
    }
}
