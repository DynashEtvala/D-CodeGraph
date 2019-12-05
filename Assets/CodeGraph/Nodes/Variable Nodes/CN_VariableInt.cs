using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph {
    public class CN_VariableInt : CN_VariableBase
    {

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            AddDynamicOutput(typeof(CNV_Int), ConnectionType.Multiple, TypeConstraint.None, "int");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "int":
                    return new CNV_Int(Name);
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " int " + Name + ";";
        }
    }
}