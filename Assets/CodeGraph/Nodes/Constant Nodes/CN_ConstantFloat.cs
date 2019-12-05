using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_ConstantFloat : CN_ConstantBase
    {
        // Use this for initialization
        protected override void Init()
        {
            base.Init();

            AddDynamicOutput(typeof(CNV_Vector3), ConnectionType.Multiple, TypeConstraint.None, "value");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}