using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Add : CN_MathBase
    {
        [Input] public CN_Var val1;
        [Input] public CN_Var val2;

        [Output] public CN_Var result;

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
                    CN_Var valResult = new CN_Var();
                    valResult.CN_Type = val1.CN_Type;
                    valResult.Name = (GetInputPort("val1").GetInputValue() as CN_Var).Name + " + " + (GetInputPort("val2").GetInputValue() as CN_Var).Name;
                    return valResult;
                default:
                    return null;
            } 
        }
    }
}