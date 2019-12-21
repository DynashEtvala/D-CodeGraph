using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNode;

namespace CodeGraph.Variables
{
    class CN_VariableTransform : CN_VariableBase
    {
        [Output] public CNV_Transform Transform;

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
                case "Transform":
                    return new CNV_Transform(Name);
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " Transform " + Name + ";";
        }
    }
}
