using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Variables.VectorOperations
{
    class CN_NormalizedVector3 : CN_Vector3OperationsBase
    {
        [Input(connectionType = ConnectionType.Override)] public CNV_Vector3 vector3;
        [Output] public CNV_Vector3 result;
        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    return new CNV_Float(InputVarName("vector3") + ".normalized");
                default:
                    return null;
            }
        }
    }
}