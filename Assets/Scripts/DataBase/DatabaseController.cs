using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level DataBase")]
public class DatabaseController : ScriptableObject
{

    [SerializeField] private List<LevelStruct> allLevelData;
    public string[] GetPackList()
    {
        List<string> allPack = new List<string>();

        for (int i = 0; i < allLevelData.Count; i++)
        {
            if (!allPack.Contains(allLevelData[i].packId))
            {
                allPack.Add(allLevelData[i].packId);
            }
        }

        return allPack.ToArray();
    }
    public string[] GetPackLevels(string PackId)
    {

        List<string> allLevels = new List<string>();

        foreach (var level in allLevelData.FindAll(x => x.packId == PackId))
        {
            allLevels.Add(level.levelId);
        }
        return allLevels.ToArray();
    }
    public LevelStruct? GetLevelData(string levelId)
    {
        return allLevelData.Find(x => x.levelId.Equals(levelId));
    }


}
[System.Serializable]
public struct LevelStruct
{
    public string levelId;
    public string packId;

    public string question;
    public string hint;
    public string[] choice;
    public int answer;
}
