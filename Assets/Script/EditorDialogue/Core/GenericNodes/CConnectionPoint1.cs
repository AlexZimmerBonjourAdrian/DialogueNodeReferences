using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// esto es la clase de control que controla los elementos de donde se conectan
public enum CConnectionPointType { In, Out }

public class CConnectionPoint1
{
    public Rect rect;

    public CConnectionPointType type;

    public CNode node;

    public GUIStyle style;

    public Action<CConnectionPoint1> OnClickConnectionPoint;

    public CConnectionPoint1(CNode node, CConnectionPointType type, GUIStyle style, Action<CConnectionPoint1> OnClickConnectionPoint)
    {
        this.node = node;
        this.type = type;
        this.style = style;
        this.OnClickConnectionPoint = OnClickConnectionPoint;
        rect = new Rect(0, 0, 10f, 20f);
    }

    public void Draw()
    {
        rect.y = node.rect.y + (node.rect.height * 0.5f) - rect.height * 0.5f;

        switch (type)
        {
            case CConnectionPointType.In:
                rect.x = node.rect.x - rect.width + 8f;
                break;

            case CConnectionPointType.Out:
                rect.x = node.rect.x + node.rect.width - 8f;
                break;
        }

        if (GUI.Button(rect, "", style))
        {
            if (OnClickConnectionPoint != null)
            {
                OnClickConnectionPoint(this);
            }
        }
    }
}


