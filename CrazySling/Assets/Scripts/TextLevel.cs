using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevel : MonoBehaviour
{
    public static string DisplayText;
    Text TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        TextComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextComponent.text = DisplayText;        
    }
}
