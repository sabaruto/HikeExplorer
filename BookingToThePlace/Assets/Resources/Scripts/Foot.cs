using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : Hand
{
    private void OnMouseDrag()
    {
        if (isIdle) { isIdle = false; }
        // Finds the distance from the mouse position and the body
        Vector3 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePosition.y > body.position.y) { mousePosition = new Vector2(mousePosition.x, transform.position.y); }

        if (Vector3.Distance(mousePosition, body.position) <= 2)
        {
            transform.position = mousePosition;
        }

        else
        {
            transform.position = body.position + (mousePosition - body.position).normalized * 2;
        }

    }
}
