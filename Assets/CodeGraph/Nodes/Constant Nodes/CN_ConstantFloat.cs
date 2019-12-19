using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Constants
{
    public class CN_ConstantFloat : CN_ConstantBase
    {
        public float Value;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();

            AddDynamicOutput(typeof(CNV_Float), ConnectionType.Multiple, TypeConstraint.None, "value");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "value":
                    return new CNV_Float((Value.ToString() + "f"));
                default:
                    return null;
            }
        }
    }
}