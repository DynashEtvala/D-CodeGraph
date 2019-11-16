using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XNode;

namespace CodeGraph
{
    public class CN_MathBase : CN_Base
    {
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