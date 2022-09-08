using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PackDataUI
{
    [SerializeField] private Button purchaseBtn;
    [SerializeField] private Button selectBtn;

    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI packNameText;

    [SerializeField] private Image completeImage;


    public void SetInfo(string packName, int packPrize, bool isFinish, bool isPackUnlock)
    {

        priceText.text = packPrize.ToString();
        packNameText.text = packName;

        completeImage.enabled = isFinish;
        
        purchaseBtn.interactable = !isPackUnlock;
        purchaseBtn.gameObject.SetActive(!isPackUnlock);
        
        selectBtn.interactable = isPackUnlock;
    }

    public void SetButtonEvent(System.Action selectBtnEvent, System.Action purchaseBtnEvent)
    {
        purchaseBtn.onClick.AddListener(purchaseBtnEvent.Invoke);
        selectBtn.onClick.AddListener(selectBtnEvent.Invoke);
    }

}
