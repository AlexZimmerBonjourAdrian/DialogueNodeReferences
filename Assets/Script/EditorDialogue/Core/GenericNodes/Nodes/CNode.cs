using System;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace DNECore {
    public abstract class CNode
    {
        public Rect rect;
        //public string title;
       // public bool isDragged;
        public bool isSelected;

        //public CConnectionPoint1 inPoint;
       // public CConnectionPoint1 outPoint;
        public CDialogueNodeEditor editor;
        public GUIStyle style = new GUIStyle();
        //public GUIStyle style;
        //public GUIStyle defaultNodeStyle;
        //public GUIStyle selectedNodeStyle;
        public float width;
        public float height;
        public bool isDragged;
        //public Action<CNode> OnRemoveNode;


        public CNode(CDialogueNodeEditor editor, Vector2 position)
        {
            this.editor = editor;
        }
    
        public CNode(CDialogueNodeEditor editor, NodeInfo info)
        {

            this.editor = editor;
        }
        
    public virtual void Drag(Vector2 delta)
    {
        rect.position += delta;
    }
        public abstract void Init(Vector2 delta);
        public abstract void Draw();

        //public abstract bool ProcessEvents(Event e);

        //public abstract void SetStyle();

        //public abstract List<CConnectionPoint1> GetConnectionPoints();

        //public abstract NodeInfo GetInfo();

        // public abstract void Rebuild(List<CConnectionPoint1> cp);





        public virtual bool ProcessDefault(Event e)
        {
            //adds clickdrag
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        if (rect.Contains(e.mousePosition))
                        {
                            isDragged = true;
                        }
                    }
                    else if (e.button == 1 && rect.Contains(e.mousePosition))
                    {
                        //delete node
                        GenericMenu genericMenu = new GenericMenu();
                        genericMenu.AddItem(new GUIContent("Remove"), false, () => editor.OnclickRemoveNode(this));
                        genericMenu.ShowAsContext();
                        e.Use();
                    }
                    break;
                case EventType.MouseUp:
                    isDragged = false;
                    break;
                case EventType.MouseDrag:
                    if (e.button == 0 && isDragged)
                    {
                        Drag(e.delta);
                        e.Use();
                        return true;
                    }
                    break;
            }

            return false;
        }
    
    /*
private void ProcessContextMenu()
{
    GenericMenu genericMenu = new GenericMenu();
    genericMenu.AddItem(new GUIContent("Remove node"), false, OnClickRemoveNode);
    genericMenu.ShowAsContext();
}
*/
    /*
private void OnClickRemoveNode()
{
    if (OnRemoveNode != null)
    {
        OnRemoveNode(this);
    }
}
*/
}
}
/*
public class CNode
{
    public Rect rect;
    public string title;
    public bool isDragged;
    public bool isSelected;

    public CConnectionPoint1 inPoint;
    public CConnectionPoint1 outPoint;

    public GUIStyle style;
    public GUIStyle defaultNodeStyle;
    public GUIStyle selectedNodeStyle;

    public Action<CNode> OnRemoveNode;

    public CNode(Vector2 position, float width, float height, GUIStyle nodeStyle, GUIStyle selectedStyle, GUIStyle inPointStyle, GUIStyle outPointStyle, Action<CConnectionPoint1> OnClickInPoint, Action<CConnectionPoint1> OnClickOutPoint, Action<CNode> OnClickRemoveNode)
    {
        rect = new Rect(position.x, position.y, width, height);
        style = nodeStyle;
        inPoint = new CConnectionPoint1(this, CConnectionPointType.In, inPointStyle, OnClickInPoint);
        outPoint = new CConnectionPoint1(this, CConnectionPointType.Out, outPointStyle, OnClickOutPoint);
        defaultNodeStyle = nodeStyle;
        selectedNodeStyle = selectedStyle;
        OnRemoveNode = OnClickRemoveNode;
    }

    public void Drag(Vector2 delta)
    {
        rect.position += delta;
    }

    public void Draw()
    {
        inPoint.Draw();
        outPoint.Draw();
        GUI.Box(rect, title, style);
    }

    public bool ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0)
                {
                    if (rect.Contains(e.mousePosition))
                    {
                        isDragged = true;
                        GUI.changed = true;
                        isSelected = true;
                        style = selectedNodeStyle;
                    }
                    else
                    {
                        GUI.changed = true;
                        isSelected = false;
                        style = defaultNodeStyle;
                    }
                }

                if (e.button == 1 && isSelected && rect.Contains(e.mousePosition))
                {
                    ProcessContextMenu();
                    e.Use();
                }
                break;

            case EventType.MouseUp:
                isDragged = false;
                break;

            case EventType.MouseDrag:
                if (e.button == 0 && isDragged)
                {
                    Drag(e.delta);
                    e.Use();
                    return true;
                }
                break;
        }

        return false;
    }

    private void ProcessContextMenu()
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Remove node"), false, OnClickRemoveNode);
        genericMenu.ShowAsContext();
    }

    private void OnClickRemoveNode()
    {
        if (OnRemoveNode != null)
        {
            OnRemoveNode(this);
        }
    }
}

*/
