using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph {
    public class CN_VariableVector3 : CN_VariableBase
    {

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            AddDynamicOutput(typeof(CNV_Vector3), ConnectionType.Multiple, TypeConstraint.None, "vector3");
            AddDynamicOutput(typeof(CNV_Float), ConnectionType.Multiple, TypeConstraint.None, "x");
            AddDynamicOutput(typeof(CNV_Float), ConnectionType.Multiple, TypeConstraint.None, "y");
            AddDynamicOutput(typeof(CNV_Float), ConnectionType.Multiple, TypeConstraint.None, "z");
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "vector3":
                    return new CNV_Vector3(Name);
                case "x":
                    return new CNV_Float(Name + ".x");
                case "y":
                    return new CNV_Float(Name + ".y");
                case "z":
                    return new CNV_Float(Name + ".z");
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " Vector3 " + Name + ";";
        }
    }
}