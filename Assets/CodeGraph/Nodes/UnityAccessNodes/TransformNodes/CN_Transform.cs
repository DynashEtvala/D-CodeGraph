using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Transform : CN_UnityAccessBase
    {
        [Output] public CNV_Transform Transform;
        public bool local;
        [Output] public CNV_Vector3 Position;
        [Output] public CNV_Quaternion Rotation;
        [Output] public CNV_Vector3 Scale;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            local = false;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "Transform":
                    return new CNV_Transform("transform");
                case "Position":
                    if (local)
                    {
                        return new CNV_Vector3("transform.localPosition");
                    }
                    else
                    {
                        return new CNV_Vector3("transform.position");
                    }
                case "Rotation":
                    if (local)
                    {
                        return new CNV_Vector3("transform.localRotation");
                    }
                    else
                    {
                        return new CNV_Quaternion("transform.rotation");
                    }
                case "Scale":
                    return new CNV_Vector3("transform.localScale");
                default:
                    return null;
            }
        }
        
    }
}