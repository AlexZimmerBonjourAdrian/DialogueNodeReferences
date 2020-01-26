using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;




namespace DNECore
{
    public abstract class CNode
    {
        public Rect rect;

        public float width;
        public float height;
        public bool isDragged;
        public DialogNodeEditor editor;
        public CNode(DialogNodeEditor editor, Vector2 position)
        {
            SetStyle();
            this.editor = editor;
        }
        /*
        public CNode(DialogNodeEditor editor, Node)
        */
        public abstract void Draw();
        public abstract void SetStyle();
        //public abstract NodeInfo getInfo();
        public abstract void init(Vector2 position);
        public abstract bool ProccesEvents(Event e);

        

        public virtual void Drag(Vector2 delta)
        {
            rect.position += delta;
        }
       
        public virtual bool ProcessDefault(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                if(e.button == 0)
                {
                    if(rect.Contains(e.mousePosition))
                        {
                            isDragged = true;
                        }
                }
                else if (e.button == 1 && rect.Contains(e.mousePosition))
                    {/*
                GenericMenu genericMenu = new GenericMenu();
                genericMenu.AddItem(new GUIContent("Remove"),false,() ==> )

            */
                  }
                    break;
                case EventType.MouseUp:
                    isDragged = false;
                    break;
                case EventType.MouseDrag:
                    if(e.button == 0 && isDragged)
                    {
                        Drag(e.delta);
                        e.Use();
                        return true;
                    }
                    break;
            }
            return false;
           
        }


    }

    


}
