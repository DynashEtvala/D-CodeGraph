using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

namespace CodeGraph.Variables
{
    [CustomNodeEditor(typeof(CN_Set))]
    public class SetEditor : NodeEditor
    {
        private CN_Set targetNode;

        public override void OnBodyGUI()
        {
            if (targetNode == null)
            {
                targetNode = target as CN_Set;
            }

            serializedObject.Update();
            
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("last"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Next"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("val1"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("val2"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("result"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}