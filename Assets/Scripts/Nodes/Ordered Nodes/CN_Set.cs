using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Set : CN_OrderedBase
    {
        [Output] public CN_Coupler Next;
        [Input] public CN_Var val1;
        [Input] public CN_Var val2;
        [Output] public CN_Var result;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();

        }

        public override void OnCreateConnection(NodePort from, NodePort to)
        {
            base.OnCreateConnection(from, to);
            if(to == GetPort("val1") && !(from.node is CN_Variable))
            {
                to.Disconnect(from);
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    if (GetInputPort("val1").Connection.node is CN_Variable)
                    {
                        return (GetInputPort("val1").GetInputValue() as CN_Var);
                    }
                    return null;
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return (GetInputPort("val1").GetInputValue() as CN_Var).Name + " = " + (GetInputPort("val2").GetInputValue() as CN_Var).Name + ";";
        }
    }
}