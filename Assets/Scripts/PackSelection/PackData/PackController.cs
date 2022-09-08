using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackController : MonoBehaviour
{

    [SerializeField] private PackData basePackPrefab;
    [SerializeField] private Transform packPos;
    [SerializeField] private DatabaseController levelDatabase;

    private void Start() {
        ShowAllPack();
    }

    public void ShowAllPack(){
        var allAvaiablePack = levelDatabase.GetPackList();

        foreach (var item in allAvaiablePack)
        {
            var pack = Instantiate(basePackPrefab,packPos);
            pack.Initial(item, "Level Pack "+ item);

        }
    }

    
}
