using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DNECore;

namespace DNECore
{
public class CDialogNode : CNode
    {
        public CConnectionPoint1 inPoint;
        public List<CConnectionPoint1> outPoints = new List<CConnectionPoint1>();
        public List<string> triggers = new List<string>();

       

        public string title;
        public string text;

        private float offset;
        private float button_height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing + 4f;
        private bool isAddClicked = false;
        private bool isRemoveClicked = false;
        private Vector2 scroll;

        public CDialogNode(CDialogueNodeEditor editor, Vector2 position): base(editor, position)
        {
            Init(position);
        }
        public CDialogNode(CDialogueNodeEditor editor, NodeInfo info) : base(editor,info)
        {
            Init(new Vector2(info.rect.x, info.rect.y));
            text = info.text;
            title = info.title;
           
        }

        public override void Init(Vector2 position)
        {
       
            width = 300;
            height = 200;
            rect = new Rect(position.x, position.y, width, height);
            //inPoint  new ConnectionPoint(this,ConnectionPointType.Out,editor.O)
            triggers.Add("default");
        }

        public void SetTriggers(List<string> triggers)
        {
            this.triggers = triggers;
        }
        public override void Draw()
        {
            rect.height = offset + ((3 + triggers.Count) * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing)) + 10 + button_height + (EditorGUIUtility.singleLineHeight * 5);

            //inPoint.Draw();
            for (int i = triggers.Count - 1; i>= 0; i--)
            {
                outPoints[i].Draw(rect.y + offset + ((2 + i) * (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing)) - (outPoints[i].rect.height * 0.5f) + (EditorGUIUtility.singleLineHeight * 0.5f) + button_height);

            }
            GUI.Box(rect, title, style);

            GUILayout.BeginArea(new Rect(rect.x, rect.y + offset, rect.width, rect.height - offset));
            GUILayout.BeginVertical();

            title = EditorGUILayout.TextField("Title", title);
            EditorGUILayout.PrefixLabel("Text");
            text = EditorGUILayout.TextArea(text, GUILayout.Height(EditorGUIUtility.singleLineHeight * 5));

            GUILayout.BeginHorizontal();
            isRemoveClicked = GUILayout.Button("-");
            isAddClicked = GUILayout.Button("+");
            GUILayout.EndHorizontal();

            for(int i= 0; i< triggers.Count; i++)
            {
                triggers[i] = EditorGUILayout.TextField("Option " + i, triggers[i]);

            }
            GUILayout.EndVertical();
            GUILayout.EndArea();

        }

        /*
        public override bool ProcessEvents(Event e)
        {
            Pro
        }
        */
        /*
        public override List<CConnectionPoint1> GetConnectionPoints()
        {

            List<CConnectionPoint1> result = new List<CConnectionPoint1> { inPoint };
            result.AddRange(outPoints);
            return result;
        }
        */
        /*
        public override bool ProcessEvents(Event e)
        {
            ProcessDefault(e);
            
            for(int i=0; i<outPoints.Count; i++)
            {
                outPoints[i].ProcessEvents(e);
            }
            if(isAddClicked)
            {
                outPoints.Add(new CConnectionPoint1(this, CConnectionPointType.Out,editor.onc))
            }
        }
        */
        /*
        public override void Init(Vector2 position)
        {
            width = 300;
            height = 200;
            rect = new Rect(position.x, position.y, width, height);
            inPoint= new CConnectionPoint1(this,CConnectionPointType.In, editor)
        }
=        */

    }
}
