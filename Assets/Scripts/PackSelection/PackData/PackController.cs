using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PackController
{
    [SerializeField] private PackData basePackPrefab;
    [SerializeField] private Transform packPos;
    [SerializeField] private DatabaseController levelDatabase;

    public void ShowAllPack()
    {
        var allAvaiablePack = levelDatabase.GetPackList();

        foreach (var item in allAvaiablePack)
        {
            var pack = MonoBehaviour.Instantiate(basePackPrefab, packPos);
            pack.Initial(item, "Level Pack " + item);

        }
    }


}
