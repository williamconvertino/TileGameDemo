
using Unity.VisualScripting;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    public Coordinate coordinate;

    private void Awake()
    {
        coordinate = new Coordinate((int)transform.position.x, (int)transform.position.z);
        
        //GridManager.instance.AddGridItem(this);
    }

    public bool MoveTo(int x, int z)
    {
        bool success = GridManager.instance.MoveGridItem(this, new Coordinate(x, z));
        if (!success)
        {
            return success;
        }
        transform.position = new Vector3(coordinate.x, transform.position.y, coordinate.z);
        return true;
    }

    public bool Move(int x, int z)
    {
        return MoveTo(coordinate.x + x, coordinate.z + z);
    }

    private void OnDrawGizmos()
    {
        coordinate = new Coordinate((int)transform.position.x, (int)transform.position.z);
    }
}