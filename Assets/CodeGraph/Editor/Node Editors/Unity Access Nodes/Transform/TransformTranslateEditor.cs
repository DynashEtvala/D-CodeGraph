using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

namespace CodeGraph
{
    [CustomNodeEditor(typeof(CN_TransformTranslate))]
    public class TransformTranslateEditor : NodeEditor
    {
        private CN_TransformTranslate targetNode;

        public override void OnBodyGUI()
        {
            if(targetNode == null)
            {
                targetNode = target as CN_TransformTranslate;
            }

            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("last"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Next"));

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("InputType"));

            targetNode.UpdatePorts();

            switch (targetNode.InputType)
            {
                case CN_TransformTranslate.INPUT_TYPE.VECTOR3:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Direction"));
                    break;
                case CN_TransformTranslate.INPUT_TYPE.FLOATS:
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("x"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("y"));
                    NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("z"));
                    break;
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
