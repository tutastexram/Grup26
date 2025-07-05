using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform hedef; 
    public Vector3 ofset; 
    public float yumusamaHizi = 0.125f; 
    public bool dönmeyiTakipEt = true; 
    void FixedUpdate()
    {
        
        Vector3 hedefPozisyon;

        if (dönmeyiTakipEt)
        {
           
            hedefPozisyon = hedef.position + hedef.TransformDirection(ofset);
        }
        else
        {
            
            hedefPozisyon = hedef.position + ofset;
        }

        
        Vector3 yumusakPozisyon = Vector3.Lerp(transform.position, hedefPozisyon, yumusamaHizi);
        transform.position = yumusakPozisyon;

       
        transform.LookAt(hedef);
    }
}