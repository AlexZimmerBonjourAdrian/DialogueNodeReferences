using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


// esto es la clase de control que controla los elementos de donde se conectan
namespace DNECore { 
public enum CConnectionPointType { In, Out }

public class CConnectionPoint1
{
    public Rect rect;

    public CConnectionPointType type;

    public CNode node;

    public GUIStyle style = new GUIStyle();

    public Action<CConnectionPoint1> OnClickConnectionPoint;

        public bool isClicked = false;
    public CConnectionPoint1(CNode node, CConnectionPointType type, GUIStyle style, Action<CConnectionPoint1> OnClickConnectionPoint)
    {
        this.node = node;
        this.type = type;
        this.style = style;
        this.OnClickConnectionPoint = OnClickConnectionPoint;
        rect = new Rect(0, 0, 10f, 20f);
    }
        public void ProcessEvents(Event e)
        {
            if(isClicked)
            {
                if(OnClickConnectionPoint != null)
                {
                    OnClickConnectionPoint(this);
                }
            }
        }
        public void Draw(float y)
        {
            rect.y = y;

            switch(type)
            {
                case CConnectionPointType.In:
                    rect.x = node.rect.x - rect.width + 0f;
                    break;
            }
            isClicked = GUI.Button(rect, "", style);

        }

        public void Draw()
        {
            Draw(node.rect.y + (node.rect.height * 0.5f) - (rect.height * 0.5f));
        }

        public void setStyl()
        {
            style.normal.background = AssetDatabase.LoadAssetAtPath("Assets/Editor/DialogNodeEditor/Textures/grayTex.png", typeof(Texture2D)) as Texture2D;
            style.active.background = AssetDatabase.LoadAssetAtPath("Assets/Editor/DialogNodeEditor/Textures/grayDarkTex.png", typeof(Texture2D)) as Texture2D;

        }
        public void Rebuild(CNode node, CConnectionPointType type, Action<CConnectionPoint1> OnClickConnectionPoint)
        {
            this.node = node;
            this.type = type;
            this.OnClickConnectionPoint = OnClickConnectionPoint;
        }
        /*
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
    */
}
}
/*
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
*/


