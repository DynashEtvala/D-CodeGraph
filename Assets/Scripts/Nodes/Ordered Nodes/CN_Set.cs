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

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }
    }
}