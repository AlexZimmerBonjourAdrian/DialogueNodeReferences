using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System;
using DNECore;
public class CDialogueNodeEditor : EditorWindow
{
    private List<CNode> nodes;
    private List<CConnection> connections;
    private Vector2 offset;
    private Vector2 drag;

    private CConnectionPoint1 SelectedInPoint;
   private CConnectionPoint1 SelectedoutPoint;

    [MenuItem("Dialog Node Editor/Canvas")]
    private static void OpenWindow()
    {
        CDialogueNodeEditor window = GetWindow<CDialogueNodeEditor>();
        window.titleContent = new GUIContent("Diaog Node Editor");
    }

    
    private void OnGUI()
    {
        
        DrawCanvas(20,2f, Color.blue);
        DrawCanvas(100, 2f, Color.blue);

        //DrawNodes();

       if(GUI.changed)
        {
            Repaint();
        }
        

    }
    
    private void DrawNodes()
    {
        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Draw();
            }
        }
    }
    /*
    private void ProcessNodes(Event e)
    {
        if(nodes != null)
        {
            for(int i = nodes.Count - 1; i >= 0; i--)
            {
                bool guiChanged = nodes[i].ProcessEvents(e);

                if(guiChanged)
                {
                    GUI.changed = true;
                }
            }
        }
    }
    */
    
    /*
    private void DrawConnections()
    {
        if(connections != null)
        {
            for(int i=0;i<connections.Count; i++)
            {
                connections[i].Draw();
            }
        }
    }
    */
    
    private void DrawCanvas(float gridSpacing, float gridOpacity, Color gridColor)
    {
        int widthdivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        offset += drag * 0.5f;
        Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

        for (int i = 0; i < widthdivs; i++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
        }

        for (int i = 0; i < heightDivs; i++)
        {
            Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * i, 0) + newOffset, new Vector3(position.width, gridSpacing * i, 0f) + newOffset);
        }

        Handles.color = Color.white;
        Handles.EndGUI();
    }
    /*Todo:DrawConnectionLine(Event e)
     * Todo:DrawToolbar()
     * 
     */
    /*
   private void ProccessNodes(Event e)
   {
       if (nodes != null)
       {

           for (int i = nodes.Count - 1; i >= 0; i--)
           {
               bool guichanged = nodes[i].ProcessEvents(e);

               if (guichanged)
               {
                   GUI.changed = true;
               }
           }
       }
   }
   */
    /*
    public string SaveCanvas(string path)
    {
        try
        {
            if (nodes == null) nodes = new List<CNode>();
            if (connections == null) connections = new List<CConnection>();
            Ed
        }


        public void BuildCanvas(string path)
        {
            if (nodes == null) nodes = new List<CNode>();
            // if (connections == null) connections = new List<CConnection>();

        }

        private void AddNode(CNode node)
        {
            /*
            if(nodes == null)
            {
                nodes = new List<CNode>();
            }
            if (node.GetType() == typeof())
            
            nodes.Add(node);
        }

        */
        /*
        public void OnClickOutPoint(CConnectionPoint1 outPoint)
    {
        SelectedInPoint = outPoint;

        if(SelectedInPoint != null)
        {
            if(SelectedoutPoint.node != SelectedInPoint.node)
            {
              
            }
        }
    }
    */
        private void AddNode(CNode node)
    {
        if(nodes == null)
        {
            nodes = new List<CNode>();
        }

        //if(node.GetType(typeof(D)))
        nodes.Add(node);
    }
    
    public void ProcessCanvas(Event e)
    {
        drag = Vector2.zero;

        switch(e.type)
        {
            
            case EventType.MouseDown:
                /*
                if(e.button == 0)
                {
                    
                }
                */
            if(e.button == 1)
                {
                    ProcessContextMenu(e.mousePosition);
                }
                break;
                /*
            case EventType.MouseDrag:
                if(e.button ==0)
                {
                     
                }
                */
        }
    }
    

        private void ProcessContextMenu(Vector2 mousePosition)
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Dialog Node"), false, () => AddNode(new CDialogNode(this, mousePosition)));
        genericMenu.ShowAsContext();
    }
        public void OnclickRemoveNode(CNode node)
    {
        if(connections != null)
        {
            List<CConnection> connectionsToRemove = new List<CConnection>();

            for(int i = 0; i < connections.Count; i++)
            {
                if(connections[i].inPoint.node == node || connections[i].outPoint.node == node)
                {
                    connectionsToRemove.Add(connections[i]);
                }
            }
            for(int i=0; i< connectionsToRemove.Count; i++)
            {
                connections.Remove(connectionsToRemove[i]);

            }
            nodes.Remove(node);
        }
    }
}








