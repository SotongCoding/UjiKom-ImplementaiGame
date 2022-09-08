using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackData : MonoBehaviour
{
    [SerializeField] private PackDataUI packUI;
    private string packId;

    public void Initial(string packId, string packName)
    {
        this.packId = packId;
        bool isFinish = false;
        bool isPackUnlock = true;//SaveData.Instacnce.IsPackUnlock(packId);

        packUI.SetInfo(packName, CommonVariable.PACK_PRIZE, isFinish, isPackUnlock);
        packUI.SetButtonEvent(SelectPack,PurchasePack);
        
    }

    void PurchasePack()
    {
        // if(Currency.UnlockPack()){
        //     SaveData.Instance.AddUnlockPack(packId);
        //     Analytic.TrackUnlockPack();
        // }
    }

    void SelectPack()
    {
        Debug.Log("SelectPack : " + packId);
        PlayerPrefs.SetString(CommonVariable.SAVED_SELECTED_PACK, packId);
    }
}
