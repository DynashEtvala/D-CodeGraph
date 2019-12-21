using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNode;

namespace CodeGraph.Constants
{
    class CN_ConstantBool : CN_ConstantBase
    {
        public bool Value = true;
        [Output] public CNV_Bool value;

        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "value":
                    return new CNV_Bool(Value ? "true" : "false");
                default:
                    return null;
            }
        }
    }
}
