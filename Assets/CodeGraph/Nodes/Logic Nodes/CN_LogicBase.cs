using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XNode;

namespace CodeGraph.Logic
{
    class CN_LogicBase : CN_Base
    {
        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
