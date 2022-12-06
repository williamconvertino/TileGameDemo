
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public static MovementManager instance;
    
    public Dictionary<int, List<MovableGridObject>> layerMap;

    public bool active = true;
    
    void Awake()
    {
        instance = this;
        layerMap = new Dictionary<int, List<MovableGridObject>>();
    }

    public void AddMovementObject(MovableGridObject o, int layer = 10)
    {
        if (!layerMap.ContainsKey(layer))
        {
            layerMap.Add(layer, new List<MovableGridObject>());
        }
        layerMap[layer].Add(o);
    }

    public void DoTurn()
    {
        if (!active)
        {
            return;
        }
        foreach (int key in layerMap.Keys)
        {
            foreach (MovableGridObject o in layerMap[key])
            {
                o.OnDoTurn();
            }
        }
    }
    
}