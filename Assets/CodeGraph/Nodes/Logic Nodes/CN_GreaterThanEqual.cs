using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Logic
{
    class CN_GreaterThanEqual : CN_LogicBase
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val1;
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val2;
        [Output] public CNV_Bool result;

        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    return new CNV_Bool("(" + InputVarName("val1") + " >= " + InputVarName("val2") + ")");
                default:
                    return null;
            }
        }
    }
}