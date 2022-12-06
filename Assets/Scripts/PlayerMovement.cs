using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GridObject _playerObject;

    private void Start()
    {
        _playerObject = GetComponent<GridObject>();
    }

    private void Update()
    {
        Vector2Int movement = new Vector2Int();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.x -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.y -= 1;
        }

        if (movement.Equals(Vector2Int.zero))
        {
            return;
        }

        if (_playerObject.Move(movement.x, movement.y))
        {
            MovementManager.instance.DoTurn();
        }
    }
}
