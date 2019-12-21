using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Variables.TransformOperations
{
    class CN_SplitTransform : CN_TransformOperationsBase
    {
        [Input(connectionType = ConnectionType.Override)] public CNV_Transform Transform;
        [Output] public CNV_Vector3 Position;
        [Output] public CNV_Quaternion Rotation;
        [Output] public CNV_Vector3 Scale;
        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "Position":
                    return new CNV_Vector3(InputVarName("Transform") + ".position");
                case "Rotation":
                    return new CNV_Quaternion(InputVarName("Transform") + ".rotation");
                case "Scale":
                    return new CNV_Float(InputVarName("Transform") + ".localscale");
                default:
                    return null;
            }
        }
    }
}