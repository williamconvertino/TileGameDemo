using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Grid : MonoBehaviour
{
    public int xWidth = 0;
    public int zWidth = 0;
    
    public float offset = 0.5f;

    public GameObject tile1;
    public GameObject tile2;

    public float xStart;
    public float xEnd;
    public float zStart;
    public float zEnd;


    private void Start()
    {
        Vector2 xEndpoints = getEndPoints(xWidth);
        Vector2 zEndpoints = getEndPoints(zWidth);

        xStart = xEndpoints.x;
        xEnd = xEndpoints.y;
        
        zStart = zEndpoints.x;
        zEnd = zEndpoints.y;

        for (float x = xStart; x < xEnd; x++)
        {
            for (float z = zStart; z < zEnd; z++)
            {
                if (x%2 + z%2 == 0 || x%2 + z%2 == 2 || x%2 + z%2 == -2)
                {
                    Instantiate(tile1, this.transform).transform.position = new Vector3(x + offset, -1, z + offset);
                }
                else
                {   
                    Instantiate(tile2, this.transform).transform.position = new Vector3(x+offset, -1, z+offset);
                }
            }
        }
    }
    
    public Vector2 getEndPoints(int width)
    {
        float start = -(width/2.0f);
        float end = (width/2.0f);
        
        if (start == Mathf.Floor(start))
        {
            start += offset;
            end += offset;
        }

        return new Vector2(start, end);
    }

    public bool inBounds(Coordinate testCoord)
    {
        return !(testCoord.x > xEnd || testCoord.x < xStart || testCoord.z > zEnd || testCoord.z < zStart);
    }
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector2 xEndpoints = getEndPoints(xWidth);
        Vector2 zEndpoints = getEndPoints(zWidth);

        xStart = xEndpoints.x;
        xEnd = xEndpoints.y;
        
        zStart = zEndpoints.x;
        zEnd = zEndpoints.y;

        for (float x = xStart; x <= xEnd; x++)
        {
            Gizmos.DrawLine(new Vector3(x, -offset, zStart), new Vector3(x, -offset, zEnd));
        }
        
        for (float z = zStart; z <= zEnd; z++)
        {
            Gizmos.DrawLine(new Vector3(xStart, -offset, z), new Vector3(xEnd, -offset, z));
        }

        for (float x = xStart - offset + 1; x <= xEnd - offset; x++ )
        {
            for (float z = zStart - offset + 1; z <= zEnd - offset; z++)
            {
                Handles.Label(new Vector3(x,-0.5f,z), x + ", " + z);
            }
        }
    }
}
