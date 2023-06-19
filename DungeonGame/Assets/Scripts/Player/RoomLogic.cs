using System;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    private GeneratorOptions gOptions;
    private GenerateRoom roomObj = null;
    public void StartRoomLogic(GeneratorOptions options, ref int roomNumber)
    {
        this.gOptions = options;
        this.roomObj = null;
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] roomCenterPoints = GameObject.FindGameObjectsWithTag("RoomCenterPoint");

        string nearestRoomCenterPointName = "";
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject roomCenterPoint in roomCenterPoints)
        {
            float distance = Vector3.Distance(player.transform.position, roomCenterPoint.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestRoomCenterPointName = roomCenterPoint.name;
            }
        }

        //Debug.Log("Nearest RoomCenterPoint to player: " + nearestRoomCenterPointName);
        
        string[] splitString = nearestRoomCenterPointName.Split('_');
        string numberString = splitString[1];
        roomNumber = Int32.Parse(numberString);
	        
        //Debug.Log(numberString + "----------");
    }
    
    
    public void OpenRoom(int number)
    {
        //Debug.Log("number: " + number);
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjects)
        {
            if (obj.name == number.ToString())
            {
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = gOptions.doorOpen.GetComponent<SpriteRenderer>().sprite;
                
                GenerateRoom roomObj = obj.GetComponent<RoomReference>().room;
                roomObj.SetRoomDone();
                //Debug.Log("ID Up: " + roomObj.GetTelIdUp() + " ID Down: " + roomObj.GetTelIdDown() + " ID Left: " + roomObj.GetTelIdLeft() + " ID Right: " + roomObj.GetTelIdRight());
                
                 this.roomObj = roomObj;
            }
        }
    }

    public void TeleportToNextRoom(Quaternion rotation)
    {
        int roomID = 0;
        if (roomObj != null && roomObj.GetRoomDone())
        {
            GameObject teleportPoint = null;
            if (rotation.y == 0)
            {
                roomID = roomObj.GetTelIdUp();
                string roomCenterPointName = "RoomCenterPoint_" + roomID;
                teleportPoint = GameObject.Find(roomCenterPointName);
            }
            else if (rotation.y == 90)
            {
                roomID = roomObj.GetTelIdLeft();
                string roomCenterPointName = "RoomCenterPoint_" + roomID;
                teleportPoint = GameObject.Find(roomCenterPointName);
            }
            else if (rotation.y == 180)
            {
                roomID = roomObj.GetTelIdDown();
                string roomCenterPointName = "RoomCenterPoint_" + roomID;
                teleportPoint = GameObject.Find(roomCenterPointName);
            }
            else if (rotation.y == 270)
            {
                roomID = roomObj.GetTelIdRight();
                string roomCenterPointName = "RoomCenterPoint_" + roomID;
                teleportPoint = GameObject.Find(roomCenterPointName);
            }
            
            
            if (teleportPoint != null)
            {
                GameObject player = GameObject.FindWithTag("Player");

                //Todo-Kreni Kammera anpassen
                player.transform.position = teleportPoint.transform.position;
                player.transform.rotation = teleportPoint.transform.rotation;
                CameraController camera = FindObjectOfType<CameraController>();
                if (camera != null)
                {
                    camera.StartCamera(roomID);
                }
                else
                {
                    Debug.LogError("Error: CameraController script not found!");
                }

            }
        }
    }




}
