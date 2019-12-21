using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_GameObject : CN_Base
    {
        [Output] public CNV_GameObject gameObject;
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
                case "gameObject":
                    return new CNV_GameObject("gameObject");
                default:
                    return null;
            }
        }
    }
}