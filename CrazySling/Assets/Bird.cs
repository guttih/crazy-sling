using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    
    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
