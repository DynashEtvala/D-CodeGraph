using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_TransformTranslate : CN_UnityAccessBase
    {
        public enum INPUT_TYPE{VECTOR3, FLOATS};

        [Input(connectionType = ConnectionType.Override)] public CN_Coupler Last;
        [Output(connectionType = ConnectionType.Override)] public CN_Coupler Next;

        public INPUT_TYPE InputType = INPUT_TYPE.VECTOR3;

        [Input(connectionType = ConnectionType.Override)] public CNV_Vector3 Direction;

        [Input(connectionType = ConnectionType.Override)] public CNV_Float x;
        [Input(connectionType = ConnectionType.Override)] public CNV_Float y;
        [Input(connectionType = ConnectionType.Override)] public CNV_Float z;

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
            switch (InputType)
            {
                case INPUT_TYPE.VECTOR3:
                    return "transform.Translate(" + InputVarName("Direction") + ");";
                case INPUT_TYPE.FLOATS:
                    return "transform.Translate(" + InputVarName("x") + "," + InputVarName("y") + "," + InputVarName("z") + ");";
                default:
                    throw new System.Exception("Invalid INPUT_TYPE");
            }
        }

        public void UpdatePorts()
        {
            switch (InputType)
            {
                case INPUT_TYPE.VECTOR3:
                    while (GetPort("x").ConnectionCount > 0)
                    {
                        GetPort("x").Disconnect(0);
                    }
                    while (GetPort("y").ConnectionCount > 0)
                    {
                        GetPort("y").Disconnect(0);
                    }
                    while (GetPort("z").ConnectionCount > 0)
                    {
                        GetPort("z").Disconnect(0);
                    }
                    break;
                case INPUT_TYPE.FLOATS:
                    while (GetPort("x").ConnectionCount > 0)
                    {
                        GetPort("Direction").Disconnect(0);
                    }
                    break;
            }
        }
    }
}