using UnityEngine;

public class Node
{
    public bool isWalkable;
    public Vector2 worldPosition;

    // Position of the player in node
    public int gridX;
    public int gridY;

    public int hCost;
    public int gCost;

    // Parent of the node
    public Node parent;

    public Node(bool _isWalkable, Vector2 _worldPosition, int _gridX, int _gridY)
    {
        isWalkable = _isWalkable; 
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
    }

    // Calculate the FCost 
    public int FCost
    {
        get { return hCost + gCost; }
    }
}
