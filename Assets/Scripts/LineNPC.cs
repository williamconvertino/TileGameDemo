
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LineNPC : MovableGridObject
{

    public Grid myGrid;

    public Coordinate direction;
    
    private void Start()
    {
        MovementManager.instance.AddMovementObject(this);
    }
    public override void OnDoTurn()
    {
        if (!Move(direction.x, direction.z))
        {
            direction.x *= -1;
            direction.z *= -1;
            Move(direction.x, direction.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Coordinate currentCoord = new Coordinate(coordinate.x, coordinate.z);
        
        while (myGrid.inBounds(currentCoord))
        {
            Gizmos.DrawWireCube(new Vector3(currentCoord.x, 0, currentCoord.z), new Vector3(0.5f,0.5f,0.5f));
            currentCoord.x += direction.x;
            currentCoord.z += direction.z;
        }
    }
}
