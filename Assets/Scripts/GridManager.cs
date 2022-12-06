
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    
    public Dictionary<Coordinate, List<GridObject>> gridMap;

    private Grid grid;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gridMap = new Dictionary<Coordinate, List<GridObject>>();
        grid = GetComponent<Grid>();
    }

    public void AddGridItem(GridObject o)
    {
        List<GridObject> coordList = gridMap.GetValueOrDefault(o.coordinate, new List<GridObject>());
        coordList.Add(o);
        gridMap[o.coordinate] = coordList;
    }

    public void RemoveGridItem(GridObject o)
    {
        if (!gridMap.ContainsKey(o.coordinate))
        {
            return;
        }
        List<GridObject> coordList = gridMap[o.coordinate];
        coordList.Remove(o);
        if (coordList.Count == 0)
        {
            gridMap.Remove(o.coordinate);
        }
    }

    public bool CheckCollision(GridObject o, string targetTag)
    {
        var coordItems = gridMap[o.coordinate];
        foreach (GridObject other in coordItems)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                return true;
            }
        }

        return false;
    }
    
    public bool MoveGridItem(GridObject o, Coordinate newCoordinate)
    {
        if (!grid.inBounds(newCoordinate))
        {
            return false;
        }
        RemoveGridItem(o);
        o.coordinate = newCoordinate;
        AddGridItem(o);
        if ((o.gameObject.CompareTag("Enemy") && CheckCollision(o, "Player")) || (o.gameObject.CompareTag("Player") && CheckCollision(o, "Enemy")))
        {
            print("HIT");
            MovementManager.instance.active = false;
        }
        return true;
    }
    
}