using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNode;

namespace CodeGraph.Variables
{
    class CN_VariableBool : CN_VariableBase
    {
        [Output] public CNV_Bool Bool;

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
                case "Bool":
                    return new CNV_Bool(Name);
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " bool " + Name + ";";
        }
    }
}
