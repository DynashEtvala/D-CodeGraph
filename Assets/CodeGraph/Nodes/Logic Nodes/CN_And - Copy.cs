﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Logic
{
    class CN_Not : CN_LogicBase
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Inherited)] public CNV_Bool val;
        [Output] public CNV_Bool result;

        protected override void Init()
        {
            base.Init();
        }

        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    return new CNV_Bool("!" + InputVarName("val"));
                default:
                    return null;
            }
        }
    }
}