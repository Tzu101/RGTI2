using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SetLevelManager : MonoBehaviour
{
    public static char[] completed;
    private static string path = "Assets/Resources/Data/levelsComplete.txt";
    public GameObject[] lvl;
    public GameObject[] lvlDone;
    void Start()
    {
        StreamReader reader = new StreamReader(SetLevelManager.path);
        SetLevelManager.completed = reader.ReadToEnd().ToCharArray();
        reader.Close();

        for(int i = 0; i < 20; i++){
            if(SetLevelManager.completed[i] == '1'){
                lvl[i].SetActive(false);
                lvlDone[i].SetActive(true);
            }
        }
    }       
}
