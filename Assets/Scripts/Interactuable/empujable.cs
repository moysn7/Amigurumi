﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empujable : MonoBehaviour , Interactuable
{
    Player player;
    public float speed = 2.5f;
    Rigidbody myBody;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        myBody = GetComponent<Rigidbody>();
    }


    public void OnInteraction()
    {
        player.empujar(myBody, null, null,speed);
    }

    bool Interactuable.interactuable(RaycastHit hit)
    {
        return true;
    }

    bool Interactuable.subible()
    {
        return false;
    }
}
