using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject BladeTrail;
    public float Mintrail = 0.01f;

    Vector2 Previousframe;
    GameObject CurrentTrail;
    Camera cam;
    Rigidbody2D rb2d;
    CircleCollider2D DetectBlade;
    Uimanager uimanager;

    bool IsCutting = false;
    
    void Start()
    {
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        DetectBlade = GetComponent<CircleCollider2D>();
        uimanager = FindObjectOfType<Uimanager>();
    }

    void Update()
    {
        if(uimanager.ispaused)
        {
            return;
        }
        InputMouse();
        if (IsCutting)
        {
            UodateCutting();
        }
    }

    private void UodateCutting()
    {
            Vector2 newposition = cam.ScreenToWorldPoint(Input.mousePosition);
            rb2d.position = newposition;
            float veclocity = (newposition - Previousframe).magnitude;
            if(veclocity > Mintrail)
            {
                DetectBlade.enabled = true;
            }
            else
            {
                DetectBlade.enabled = false;
            }
            Previousframe = newposition;
    }

    private void InputMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
    }

    private void StartCutting()
    {
        IsCutting = true;
        CurrentTrail = Instantiate(BladeTrail, transform);
        DetectBlade.enabled = false;
    }
    private void StopCutting()
    {
        IsCutting = false;
        CurrentTrail.transform.SetParent(null);
        Destroy(CurrentTrail, 2f);
        DetectBlade.enabled = false;
    }
}
