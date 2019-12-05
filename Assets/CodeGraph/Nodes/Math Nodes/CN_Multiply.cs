using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph {
    public class CN_Multiply : CN_MathBase
    {

        // Use this for initialization
        protected override void Init()
        {
            base.Init();

            AddDynamicInput(typeof(CNV_Var), ConnectionType.Override, TypeConstraint.Inherited, "val1");
            AddDynamicInput(typeof(CNV_Var), ConnectionType.Override, TypeConstraint.None, "val2");
            AddDynamicOutput(typeof(CNV_Var), ConnectionType.Multiple, TypeConstraint.None, "result");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    CNV_Var valResult = new CNV_Var();
                    valResult.CN_Type = InputVar("val1").CN_Type;
                    valResult.Name = InputVarName("val1") + (GetPort("val2").ConnectionCount > 0 ? " * " + InputVarName("val2") : "");
                    return valResult;
                default:
                    return null;
            }
        }
    }
}