using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    protected Collider2D nearestCollder;
    protected new Collider2D collider;

    protected bool isIdle = false;
    protected bool isDragged = false;

    protected float idleDistance = 2;

    private Vector3 dir;

    [SerializeField]
    protected Transform body;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        nearestCollder = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            transform.position = body.position + dir * idleDistance;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnMouseDrag()
    {
        if (isIdle) { isIdle = false; }
        if (!isDragged) { isDragged = true; }

        // Finds the distance from the mouse position and the body
        Vector3 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector3.Distance(mousePosition, body.position) <= idleDistance)
        {
            transform.position = mousePosition;
        }

        else
        {
            transform.position = body.position  + (mousePosition - body.position).normalized * idleDistance;
        }
        
    }

    private void OnMouseUp()
    {
        if (collider.IsTouching(nearestCollder))
        {
            transform.position = nearestCollder.transform.position;
        }
        else
        {
            isIdle = true;
            dir = (transform.position - body.transform.position).normalized;
        }

        isDragged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Node")
        {
            nearestCollder = collision;
        }
    }

    public bool GetIdle() { return isIdle; }
    public bool GetDragged() { return isDragged; }
}
