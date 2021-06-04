using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPDonation : MonoBehaviour
{
    private string small = "com.ossiandackfors.cubicvoid.smallDonation";
    private string medium = "com.ossiandackfors.cubicvoid.mediumDonation";
    private string big = "com.ossiandackfors.cubicvoid.bigDonation";

    [SerializeField] private GameObject thanks;

    public void OnPurchaseCompleted(Product product)
    {
        thanks.SetActive(true);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {

    }

}
