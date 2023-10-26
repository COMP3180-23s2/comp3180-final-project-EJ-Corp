using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateRooms : MonoBehaviour
{
    static private TemplateRooms templates;
    static public TemplateRooms Templates
    {
        get
        {
            return templates;
        }
    }

    public RoomHandler[] topRooms;
    public RoomHandler[] leftRooms;
    public RoomHandler[] bottomRooms;
    public RoomHandler[] rightRooms;

    void Awake()
    {
        templates = this;
    }
}
