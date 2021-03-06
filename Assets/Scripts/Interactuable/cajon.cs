﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajon : MonoBehaviour,Interactuable
{
    Player player;
    public Transform limitMin, limitMax,endPos;
    public float speed = 2.5f;
    Rigidbody myBody;
    BoxCollider myCollider;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        myBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<BoxCollider>();
    }

    //0 para empujar
    //1 para subir
    public void OnInteraction(Ray ray, RaycastHit hit, int control)
    {
        Vector3 dir = ray.direction;
        dir.y = 0;
        dir.Normalize();
        if (control == 0)
        {
            Vector3 pushPos;
            pushPos = hit.point - dir;
            pushPos.y = transform.position.y;
            player.empujar(myBody, limitMin, limitMax, speed, pushPos);
        }
        else
        {
            
            Vector3 end = dir;
            end.y = endPos.position.y;
            Vector3 start = hit.point - dir*2;
            start.y = endPos.position.y;
            player.saltar(start,end);
        }
        
    }

    bool Interactuable.interactuable(RaycastHit hit)
    {
        Vector3 producto = Vector3.Cross( Quaternion.Euler(0, transform.eulerAngles.y, 0) * transform.right, hit.normal);

        return producto.y > 0;
    }

    bool Interactuable.subible(RaycastHit hit)
    {
        
        Vector3 producto = Vector3.Cross(Quaternion.Euler(0, transform.eulerAngles.y, 0) * transform.right,
                                                               player.myPos.position - transform.position );

        return producto.y > 0 && hit.normal.y == 0 && (limitMin.position - transform.position).magnitude <= 0.5;
    }
}
