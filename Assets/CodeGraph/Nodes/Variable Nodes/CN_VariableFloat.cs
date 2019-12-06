using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_VariableFloat : CN_VariableBase
    {

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            AddDynamicOutput(typeof(CNV_Float), ConnectionType.Multiple, TypeConstraint.None, "float");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "float":
                    return new CNV_Float(Name);
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " float " + Name + ";";
        }
    }
}