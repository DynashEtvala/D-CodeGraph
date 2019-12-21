using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Math
{
    public class CN_Add : CN_MathBase
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val1;
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val2;
        [Output(connectionType = ConnectionType.Multiple)] public CNV_Var result;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    CNV_Var valResult = new CNV_Var();
                    valResult.CN_Type = InputVar("val1").CN_Type;
                    valResult.Name = "(" + InputVarName("val1") + (GetPort("val2").ConnectionCount > 0 ? " + " + InputVarName("val2") : "") + ")";
                    return valResult;
                default:
                    return null;
            } 
        }
    }
}