using UnityEngine;

public class Room : MonoBehaviour
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