using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Messages
{
    public class OnCollisionEnter : CN_MessageBase
    {
        [Output] public CNV_GameObject otherObject;
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
                case "otherObject":
                    return new CNV_GameObject("collision.gameObject");
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return "private void OnCollisionEnter(Collision collision)";
        }
    }
}