using UnityEngine;
using System.Collections.Generic;

public class DungeonGenerator : MonoBehaviour
{
    public int dungeonWidth = 50;
    public int dungeonHeight = 50;
    public int minRoomSize = 5;
    public int maxRoomSize = 15;
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public float wallHeight = 3.0f;
    public int corridorWidth = 3; // Ancho del pasillo

    private List<Room> rooms = new List<Room>();
    private List<Vector2Int> corridors = new List<Vector2Int>();

    void Start()
    {
        GenerateDungeon(new Rect(1, 1, dungeonWidth - 2, dungeonHeight - 2));
        ConnectRooms();
        DrawDungeon();
    }

    void GenerateDungeon(Rect region)
    {
        if (region.width < minRoomSize || region.height < minRoomSize)
            return;

        int roomWidth = Random.Range(minRoomSize, Mathf.Min(maxRoomSize, (int)region.width));
        int roomHeight = Random.Range(minRoomSize, Mathf.Min(maxRoomSize, (int)region.height));
        int x = (int)region.x + Random.Range(1, (int)region.width - roomWidth - 1);
        int y = (int)region.y + Random.Range(1, (int)region.height - roomHeight - 1);

        Room newRoom = new Room(x, y, roomWidth, roomHeight);

        bool roomIntersects = false;
        foreach (Room room in rooms)
        {
            if (RoomsIntersect(newRoom, room))
            {
                roomIntersects = true;
                break;
            }
        }

        if (!roomIntersects)
        {
            rooms.Add(newRoom);
        }

        Rect leftRegion = new Rect(region.x, region.y, x - region.x, region.height);
        Rect rightRegion = new Rect(x + roomWidth, region.y, region.width - (x - region.x) - roomWidth, region.height);
        Rect topRegion = new Rect(region.x, region.y, region.width, y - region.y);
        Rect bottomRegion = new Rect(region.x, y + roomHeight, region.width, region.height - (y - region.y) - roomHeight);

        GenerateDungeon(leftRegion);
        GenerateDungeon(rightRegion);
        GenerateDungeon(topRegion);
        GenerateDungeon(bottomRegion);
    }

    bool RoomsIntersect(Room room1, Room room2)
    {
        return room1.x < room2.x + room2.width &&
               room1.x + room1.width > room2.x &&
               room1.y < room2.y + room2.height &&
               room1.y + room1.height > room2.y;
    }

    void ConnectRooms()
    {
        for (int i = 0; i < rooms.Count - 1; i++)
        {
            ConnectTwoRooms(rooms[i], rooms[i + 1]);
        }
    }

    void ConnectTwoRooms(Room room1, Room room2)
    {
        Vector2Int start = new Vector2Int(room1.x + room1.width / 2, room1.y + room1.height / 2);
        Vector2Int end = new Vector2Int(room2.x + room2.width / 2, room2.y + room2.height / 2);

        Vector2Int current = start;
        Vector2Int direction = GetNormalizedDirection(start, end);

        while (current != end)
        {
            corridors.Add(current);
            current += direction;
        }
    }

    Vector2Int GetNormalizedDirection(Vector2Int start, Vector2Int end)
    {
        Vector2Int direction = end - start;
        int gcd = GCD(Mathf.Abs(direction.x), Mathf.Abs(direction.y));
        return new Vector2Int(direction.x / gcd, direction.y / gcd);
    }

    int GCD(int a, int b)
    {
        if (b == 0)
            return a;
        return GCD(b, a % b);
    }

    void DrawDungeon()
    {
        foreach (Room room in rooms)
        {
            Instantiate(floorPrefab, new Vector3(room.x + room.width / 2, 0.0f, room.y + room.height / 2), Quaternion.identity);

            for (int x = room.x; x < room.x + room.width; x++)
            {
                for (int y = room.y; y < room.y + room.height; y++)
                {
                    if (x == room.x || x == room.x + room.width - 1 || y == room.y || y == room.y + room.height - 1)
                    {
                        Instantiate(wallPrefab, new Vector3(x, wallHeight / 2, y), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(floorPrefab, new Vector3(x, 0.0f, y), Quaternion.identity);
                    }
                }
            }
        }

        foreach (Vector2Int corridor in corridors)
        {
            int corridorHalfWidth = corridorWidth / 2;

            for (int i = -corridorHalfWidth; i <= corridorHalfWidth; i++)
            {
                for (int j = -corridorHalfWidth; j <= corridorHalfWidth; j++)
                {
                    Vector3 position = new Vector3(corridor.x + i, wallHeight / 2, corridor.y + j);
                    Instantiate(wallPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
