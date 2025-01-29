using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D DefualtMouse;
    public Texture2D PressMouse;
    public Texture2D TriggerMouse;
    Vector2 hotspot = Vector2.zero;
    CursorMode CursorMode = CursorMode.Auto;


    private void Start()
    {
        Defualtcursor();
    }


    
    private void Triggercursor()
    {
        Cursor.SetCursor(TriggerMouse, hotspot, CursorMode);

    }
    private void Defualtcursor()
    {
        Cursor.SetCursor(DefualtMouse, hotspot, CursorMode);
    }
    private void Presstcursor()
    {
        Cursor.SetCursor(PressMouse, hotspot, CursorMode);
    }

    private void OnMouseUp()
    {
       

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if(hit.collider != null  && hit.collider.gameObject == gameObject)
        {
            Triggercursor();

        }
        else
        {
            Defualtcursor();

        }
    }

    private void OnMouseEnter()
    {
        //if (!isDragging)
        { Triggercursor(); }
        Debug.Log("OnTriggerCursor");
       
    }
    private void OnMouseExit()
    {
        //if(!isDragging)
        { Defualtcursor(); }
      

    }
  
    private void OnMouseDown()
    {
        Presstcursor();
    }


}
