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

    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;

    void Awake()
    {
        templates = this;
    }
}
