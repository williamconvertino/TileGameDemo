
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MovingNPC : MovableGridObject
{

    public List<Coordinate> path;
    private int pathIndex = 1;
    private int pathStep = 1;

    private void Start()
    {
        path.Insert(0,coordinate);
        MovementManager.instance.AddMovementObject(this);
    }
    public override void OnDoTurn()
    {
        if (path.Count < 2)
        {
            return;
        }
        Coordinate newCoord = path[pathIndex];

        if (MoveTo(newCoord.x, newCoord.z))
        {
            pathIndex += pathStep;
        }

        if (pathIndex >= path.Count || pathIndex < 0)
        {
            pathStep *= -1;
            pathIndex += pathStep * 2;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (Coordinate coord in path)
        {
            Gizmos.DrawWireCube(new Vector3(coord.x, 0, coord.z), new Vector3(0.5f,0.5f,0.5f));
        }
    }
}
