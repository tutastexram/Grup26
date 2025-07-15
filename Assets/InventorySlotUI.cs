using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI elemanları (Image) için
using TMPro; // TextMeshPro metin bileşenleri için

public class InventorySlotUI : MonoBehaviour
{
    // Inspector'dan atanacak referanslar
    public Image itemIcon;    // Eşyanın simgesini gösterecek Image bileşeni
    public TextMeshProUGUI itemCountText; // Eşyanın miktarını gösterecek TextMeshPro metin bileşeni

    // Dışarıdan atanacak eşya bilgileri
    private Sprite currentItemIcon;
    private int currentItemCount;

    void Awake()
    {
        // Referansların doğru atanıp atanmadığını kontrol et (eğer Inspector'dan atama yapılmadıysa otomatik bulmaya çalışır)
        if (itemIcon == null)
        {
            // Çocuk objeler arasında "ItemIcon" adında bir Image bileşeni ara
            Transform iconTransform = transform.Find("ItemIcon");
            if (iconTransform != null) itemIcon = iconTransform.GetComponent<Image>();
            if (itemIcon == null) Debug.LogError("ItemIcon Image bulunamadı! Lütfen atayın veya çocuğun adını 'ItemIcon' yapın.", this);
        }
        if (itemCountText == null)
        {
            // Çocuk objeler arasında "ItemCount" adında bir TextMeshProUGUI bileşeni ara
            Transform textTransform = transform.Find("ItemCount");
            if (textTransform != null) itemCountText = textTransform.GetComponent<TextMeshProUGUI>();
            if (itemCountText == null) Debug.LogError("ItemCount TextMeshProUGUI bulunamadı! Lütfen atayın veya çocuğun adını 'ItemCount' yapın.", this);
        }
        
        ClearSlot(); // Başlangıçta slotu temizle
    }

    // Slotu belirli bir eşya ile güncelle
    public void SetSlot(Sprite icon, int count)
    {
        currentItemIcon = icon;
        currentItemCount = count;

        if (itemIcon != null)
        {
            itemIcon.sprite = currentItemIcon;
            itemIcon.enabled = true; // İkonu görünür yap
        }

        if (itemCountText != null)
        {
            itemCountText.text = currentItemCount.ToString();
            itemCountText.enabled = true; // Metni görünür yap
        }
    }

    // Slotu boşalt
    public void ClearSlot()
    {
        currentItemIcon = null;
        currentItemCount = 0;

        if (itemIcon != null)
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false; // İkonu gizle
        }

        if (itemCountText != null)
        {
            itemCountText.text = ""; // Metni temizle
            itemCountText.enabled = false; // Metni gizle
        }
    }

    // Şu anki eşya ikonunu döndürür (dışarıdan erişim için)
    public Sprite GetItemIcon()
    {
        return currentItemIcon;
    }

    // Şu anki eşya miktarını döndürür (dışarıdan erişim için)
    public int GetItemCount()
    {
        return currentItemCount;
    }
}