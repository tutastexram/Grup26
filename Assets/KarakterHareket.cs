using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public float hareketHizi = 5f;
    public float ziplamaKuvveti = 8f;

    [Header("Zıplama Ayarları")]
    public Transform yerKontrolcu;
    public LayerMask zeminKatmani;
    public float yerYaricap = 0.2f;

    private Rigidbody rb;
    private bool yerdeMi;

    void Start()
    {
        // Rigidbody bileşeni alınır
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Karakterde Rigidbody bileşeni bulunamadı! Lütfen ekleyin.");
        }

        // Yer kontrolcüsü atanmadıysa sahneden 'GroundCheck' objesi aranır
        if (yerKontrolcu == null)
        {
            GameObject found = GameObject.Find("GroundCheck");
            if (found != null)
            {
                yerKontrolcu = found.transform;
            }
        }
    }
}