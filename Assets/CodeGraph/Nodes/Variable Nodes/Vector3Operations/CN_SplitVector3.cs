using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Variables.VectorOperations
{
    class CN_SplitVector3 : CN_Vector3OperationsBase
    {
        [Input(connectionType = ConnectionType.Override)] public CNV_Vector3 vector3;
        [Output] public CNV_Float x;
        [Output] public CNV_Float y;
        [Output] public CNV_Float z;
        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "x":
                    return new CNV_Float(InputVarName("vector3") + ".x");
                case "y":
                    return new CNV_Float(InputVarName("vector3") + ".y");
                case "z":
                    return new CNV_Float(InputVarName("vector3") + ".z");
                default:
                    return null;
            }
        }
    }
}