﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Destroy : CN_OrderedBase
    {
        [Input(connectionType = ConnectionType.Override, typeConstraint = TypeConstraint.Strict)] public CN_Coupler last;
        [Output] public CN_Coupler Next;
        [Input(connectionType = ConnectionType.Override)] public CNV_GameObject gameObject;
        // Use this for initialization
        protected override void Init()
        {
            base.Init();

        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            return null; // Replace this
        }

        public override string GetResult()
        {
            return "Destroy(" + InputVarName("gameObject") + ");";
        }
    }
}