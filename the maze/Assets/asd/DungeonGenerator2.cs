using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator2 : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public int minRoomSize = 5;
    public int maxRoomSize = 15;
    public GameObject wallPrefab; // Prefab para las paredes
    public GameObject floorPrefab; // Prefab para el suelo

    private List<Room> rooms = new List<Room>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
{
    // Crea una habitación inicial que abarca todo el espacio.
    Room initialRoom = new Room(0, 0, width, height);
    rooms.Add(initialRoom);

    Split(initialRoom);
    
    // Crea las estructuras visuales de las habitaciones y pasillos.
    foreach (Room room in rooms)
    {
        // Crea el suelo de la habitación
        GameObject floor = Instantiate(floorPrefab, new Vector3(room.x + room.width / 2, 0.0f, room.y + room.height / 2), Quaternion.identity);
        floor.transform.localScale = new Vector3(room.width, 0.1f, room.height);

        // Crea las paredes alrededor de la habitación
        for (int x = room.x; x < room.x + room.width; x++)
        {
            for (int y = room.y; y < room.y + room.height; y++)
            {
                if (x == room.x || x == room.x + room.width - 1 || y == room.y || y == room.y + room.height - 1)
                {
                    // Estás en el borde de la habitación, crea una pared.
                    Instantiate(wallPrefab, new Vector3(x, 0.0f, y), Quaternion.identity);
                }
            }
        }
    }
}




void Split(Room room)
{
    if (room.width <= maxRoomSize && room.height <= maxRoomSize)
    {
        // La habitación ya es lo suficientemente pequeña.
        return;
    }

    bool splitHorizontally = Random.value > 0.5f; // Decide si se dividirá horizontalmente o verticalmente.

    int splitSize = Random.Range(minRoomSize, (splitHorizontally ? room.width : room.height) - minRoomSize);

    int roomWidth = splitHorizontally ? room.width : splitSize;
    int roomHeight = splitHorizontally ? splitSize : room.height;

    int secondRoomX = splitHorizontally ? room.x : room.x + roomWidth;
    int secondRoomY = splitHorizontally ? room.y + roomHeight : room.y;

    Room firstRoom = new Room(room.x, room.y, roomWidth, roomHeight);
    Room secondRoom = new Room(secondRoomX, secondRoomY, room.width - roomWidth, room.height - roomHeight);

    rooms.Add(firstRoom);
    rooms.Add(secondRoom);

    Split(firstRoom);
    Split(secondRoom);
}

public class Room 
{
    public int x, y;      // Esquina superior izquierda de la habitación.
    public int width, height;

    public Room(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
}

}