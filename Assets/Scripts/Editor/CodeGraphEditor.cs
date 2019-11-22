using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using UnityEditor;
using XNode;

namespace CodeGraph
{
    [CustomNodeGraphEditor(typeof(CodeGraph))]
    public class CodeGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace == "CodeGraph")
            {
                return base.GetNodeMenuName(type).Replace("Code Graph/CN_", "");
            }
            else
            {
                return null;
            }
        }

        public override void OnGUI()
        {
            GUILayout.BeginVertical();
            {
                GUILayout.Space(35);
                GUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("Build!"))
                    {
                        
                    }
                }
            }
            GUILayout.EndVertical();
        }
    }
}