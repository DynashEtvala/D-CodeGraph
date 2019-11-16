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
                //case "result":
                //    Type val1Type = val1.GetType();
                //    dynamic valResult = Activator.CreateInstance(val1Type);
                //    return valResult.Name = val1.Name + " + " + val2.Name;
                default:
                    return null;
            } 
        }
    }
}