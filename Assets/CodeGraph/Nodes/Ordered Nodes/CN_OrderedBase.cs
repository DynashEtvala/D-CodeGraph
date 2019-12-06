using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_OrderedBase : CN_Base
    {
        // Use this for initialization
        protected override void Init()
        {
            base.Init();

            AddDynamicInput(typeof(CN_Coupler), ConnectionType.Override, TypeConstraint.Inherited, "last");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}