using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public float hareketHizi = 5f; 
    public float ziplamaKuvveti = 8f; 
    public Transform yerKontrolcu;
    public LayerMask zeminKatmani; 
    private Rigidbody rb;
    private bool yerdeMi;
    private float yerYaricap = 0.2f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Karakterde Rigidbody bileşeni bulunamadı! Lütfen ekleyin.");
        }
    }

    void Update()
    {
        
        yerdeMi = Physics.CheckSphere(yerKontrolcu.position, yerYaricap, zeminKatmani);

       
        if (Input.GetButtonDown("Jump") && yerdeMi)
        {
            rb.AddForce(Vector3.up * ziplamaKuvveti, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        
        float yatayHareket = Input.GetAxis("Horizontal");
        float dikeyHareket = Input.GetAxis("Vertical"); 

        Vector3 hareket = transform.right * yatayHareket + transform.forward * dikeyHareket;
        rb.MovePosition(rb.position + hareket * hareketHizi * Time.fixedDeltaTime);
    }
}
