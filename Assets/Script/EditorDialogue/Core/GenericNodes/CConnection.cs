﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class CConnection : MonoBehaviour
{
    public CConnectionPoint1 inPoint;
    public CConnectionPoint1 outPoint;
    public Action<CConnection> OnclickRemoveConnection;

    public CConnection(CConnectionPoint1 inPoint, CConnectionPoint1 outPoint,Action<CConnection> OnclickRemoveConnection)
    {
        this.inPoint = inPoint;
        this.outPoint = outPoint;
        this.OnclickRemoveConnection = OnclickRemoveConnection;
    }
    public void Draw()
    {
        Handles.DrawBezier(
            inPoint.rect.center, outPoint.rect.center, inPoint.rect.center + Vector2.left, outPoint.rect.center - Vector2.left * 50f, Color.white, null, 2f);

        if (Handles.Button((inPoint.rect.center + outPoint.rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap))
        {
            if(OnclickRemoveConnection != null)
            {
                OnclickRemoveConnection(this);
            }
        }
    }
}
