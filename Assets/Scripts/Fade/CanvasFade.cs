using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFade : MonoBehaviour
{
    Image sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
        Color color = sprite.material.color;
        color.a = 255f;
        sprite.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        for(float f = 255f;f>=0; f--)
        {
            Color color = sprite.material.color;
            color.a = f;
            sprite.material.color = color;
        }
    }
}
