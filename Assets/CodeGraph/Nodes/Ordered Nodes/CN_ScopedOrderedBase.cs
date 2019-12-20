using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNode;

namespace CodeGraph
{
    class CN_ScopedOrderedBase : CN_OrderedBase
    {
        public bool Evaluated { get; set; }

        // Use this for initialization
        protected override void Init()
        {
            base.Init();

        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}
