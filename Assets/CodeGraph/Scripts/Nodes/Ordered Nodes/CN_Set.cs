using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Variables
{
    public class CN_Set : CN_OrderedBase
    {
        [Input(connectionType = ConnectionType.Override)] public CN_Coupler last;
        [Output(connectionType = ConnectionType.Override)] public CN_Coupler Next;
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val1;
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Var val2;
        [Output(connectionType = ConnectionType.Multiple)] public CNV_Var result;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
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