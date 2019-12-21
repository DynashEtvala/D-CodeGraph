using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Constants
{
    public class CN_ConstantInt : CN_ConstantBase
    {
        public float Value;
        [Output] public CNV_Int value;

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
                case "value":
                    return new CNV_Float(Value.ToString());
                default:
                    return null;
            }
        }
    }
}