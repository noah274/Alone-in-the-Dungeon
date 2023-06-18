using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class MapsArray : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString("firstJason") == "")
        {
            Debug.Log("create-firstJason");
            SaveRoomBuild(roomBuild);
        }
    }
    
    public void SaveRoomBuild(string[,,] roomBuild)
    {
        string jsonString = JsonConvert.SerializeObject(roomBuild);
        //Debug.Log(jsonString);
        PlayerPrefs.SetString("firstJason", jsonString);

    }
    
    
    public static string[,,] spawnBuild =
    {
        {
            { "wUpLeft", "wUp", "wUp", "wUp", "wUp", "wUp", "dUp", "wUp", "wUp", "wUp", "wUp", "wUp", "wUpRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "dLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fSpawnPoint", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "dRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wDownLeft", "wDown" , "wDown" , "wDown" , "wDown", "wDown", "dDown", "wDown", "wDown" , "wDown" , "wDown", "wDown", "wDownRight" },
        }
    };
    
    public static string[,,] bossBuild =
    {
        {
            { "wUpLeft", "wUp", "wUp", "wUp", "wUp", "wUp", "dUp", "wUp", "wUp", "wUp", "wUp", "wUp", "wUpRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "dLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "dRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wDownLeft", "wDown" , "wDown" , "wDown" , "wDown", "wDown", "dDown", "wDown", "wDown" , "wDown" , "wDown", "wDown", "wDownRight" },
        }
    };

    public static string[,,] roomBuild =
    {
        //y
        {
            { "wUpLeft", "wUp", "wUp", "wUp", "wUp", "wUp", "dUp", "wUp", "wUp", "wUp", "wUp", "wUp", "wUpRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "dLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "dRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wDownLeft", "wDown" , "wDown" , "wDown" , "wDown", "wDown", "dDown", "wDown", "wDown" , "wDown" , "wDown", "wDown", "wDownRight" },
        }, 
        {
            { "wUpLeft", "wUp", "wUp", "wUp", "wUp", "wUp", "dUp", "wUp", "wUp", "wUp", "wUp", "wUp", "wUpRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "dRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "dLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wDownRight", "", "wDown", "wDown", "wDown", "wDownRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight", "", "", "", "", "" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight", "", "", "", "", "" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight", "", "", "", "", "" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight", "", "", "", "", "" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight", "", "", "", "", "" },
            { "wDownLeft", "wDown" , "wDown" , "dDown" , "wDown", "wDown", "wDown", "wDownRight", "" , "" , "", "", "" },
        },
        {
            { "wUpLeft", "wUp", "wUp", "wUp", "wUp", "wUp", "dUp", "wUp", "wUp", "wUp", "wUp", "wUp", "wUpRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "dLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "dRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wLeft", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "fGrass", "wRight" },
            { "wDownLeft", "wDown" , "wDown" , "wDown" , "wDown", "wDown", "dDown", "wDown", "wDown" , "wDown" , "wDown", "wDown", "wDownRight" },
            { "", "", "", "", "", "", "", "", "", "", "", "", "" },
            { "", "", "", "", "", "", "", "", "", "", "", "", "" },
        }
    };

}
