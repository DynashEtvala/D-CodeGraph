using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Set : CN_OrderedBase
    {
        [Output] public CN_Coupler Next;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            
            AddDynamicInput(typeof(CNV_Var), ConnectionType.Override, TypeConstraint.Inherited, "val1");
            AddDynamicInput(typeof(CNV_Var), ConnectionType.Override, TypeConstraint.None, "val2");
            AddDynamicOutput(typeof(CNV_Var), ConnectionType.Multiple, TypeConstraint.None, "result");
        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            if (to == GetPort("val1") && !(from.node is CN_VariableBase || from.node is CN_UnityAccessBase))
            {
                to.Disconnect(from);
                return;
            }
            base.OnCreateConnection(from, to);
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    return (GetInputPort("val1").GetInputValue() as CNV_Var);
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return (GetInputPort("val1").GetInputValue() as CNV_Var).Name + " = " + (GetInputPort("val2").GetInputValue() as CNV_Var).Name + ";";
        }
    }
}