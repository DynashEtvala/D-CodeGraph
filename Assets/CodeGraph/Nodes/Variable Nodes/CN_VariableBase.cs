using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_VariableBase : CN_Base
    {
        public string Name;

        public CN_ACCESSABILITY accessability;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            accessability = CN_ACCESSABILITY.PUBLIC;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}