using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

namespace CodeGraph.Math
{
    [CustomNodeEditor(typeof(CN_Add))]
    public class AddEditor : NodeEditor
    {
        private CN_Add targetNode;

        public override void OnBodyGUI()
        {
            if (targetNode == null)
            {
                targetNode = target as CN_Add;
            }

            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("val1"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("val2"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("result"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
