﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper : MonoBehaviour
{
    public float speed = 5, damage = 50;
    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
