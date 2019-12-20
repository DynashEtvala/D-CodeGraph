using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNode;

namespace CodeGraph.Logic
{
    class CN_If:CN_ScopedOrderedBase
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Strict)] public CN_Coupler last;
        [Output(connectionType = ConnectionType.Override)] public CN_Coupler True;
        [Output(connectionType = ConnectionType.Override)] public CN_Coupler Next;
        [Input(connectionType = ConnectionType.Override)] public CNV_Bool condition;

        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            return base.GetValue(port);
        }

        public override string GetResult()
        {
            return "if(" + InputVarName("condition") + ")";
        }
    }
}
