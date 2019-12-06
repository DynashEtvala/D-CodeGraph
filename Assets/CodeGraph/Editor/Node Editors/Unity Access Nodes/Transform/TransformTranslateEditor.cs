using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

namespace CodeGraph
{
    [CustomNodeEditor(typeof(CN_TransformTranslate))]
    public class TransformTranslateEditor : NodeEditor
    {
        private CN_TransformTranslate translateNode;

        public override void OnBodyGUI()
        {
            if(translateNode == null)
            {
                translateNode = target as CN_TransformTranslate;
            }

            serializedObject.Update();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Last"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Next"));

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("InputType"));

            translateNode.UpdatePorts();

            switch (translateNode.InputType)
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
