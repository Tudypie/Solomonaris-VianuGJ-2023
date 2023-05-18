using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMarkers : MonoBehaviour
{
    public Sprite icon;
    [HideInInspector] 
    public Image image;

    public Vector2 Position{
        get{
            return new Vector2 (transform.position.x, transform.position.z);
        }
    }
}
