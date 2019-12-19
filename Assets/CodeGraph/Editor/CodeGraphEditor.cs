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
        CodeGraph codeGraph;

        public override void OnCreate()
        {
            codeGraph = window.graph as CodeGraph;
        }

        public override string GetNodeMenuName(System.Type type)
        {
            if (type.Namespace.Contains("CodeGraph"))
            {
                if (base.GetNodeMenuName(type).Contains("Base"))
                {
                    return null;
                }
                else
                {
                    return base.GetNodeMenuName(type).Replace("Code Graph/", "").Replace("CN_", "");
                }
            }
            else
            {
                return null;
            }
        }

        public override void OnGUI()
        {
            GUILayout.Space(window.zoom * window.topPadding);
            GUILayout.BeginVertical();
            {
                if (GUILayout.Button("Build!"))
                {
                    if (codeGraph.FilePath != "")
                    {
                        codeGraph.FilePath = Application.dataPath.Replace("Assets", AssetDatabase.GetAssetPath(codeGraph)).Replace(".asset", ".cs");
                    }
                    codeGraph.BuildComponent();
                }
                GUILayout.BeginHorizontal();
                {
                    
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            window.onLateGUI += OnLateGUI;
        }

        Vector2 leftScrollPos = Vector2.zero;

        public void OnLateGUI()
        {
            
        }
    }
}