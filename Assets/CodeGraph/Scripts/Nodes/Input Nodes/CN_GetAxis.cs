using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph.Inputs
{
    public class CN_GetAxis : CN_InputBase
    {
        public enum AXISNAME {VERTICAL, HORIZONTAL, FIRE1, FIRE2, FIRE3, JUMP, MOUSE_X, MOUSE_Y, MOUSE_SCROLLWHEEL, SUBMIT, CANCEL}

        public AXISNAME AxisName;

        [Output] public CNV_Float result;

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
                case "result":
                    switch (AxisName)
                    {
                        case AXISNAME.CANCEL:
                            return new CNV_Float("Input.GetAxis(\"Cancel\")");
                        case AXISNAME.FIRE1:
                            return new CNV_Float("Input.GetAxis(\"Fire1\")");
                        case AXISNAME.FIRE2:
                            return new CNV_Float("Input.GetAxis(\"Fire2\")");
                        case AXISNAME.FIRE3:
                            return new CNV_Float("Input.GetAxis(\"Fire3\")");
                        case AXISNAME.HORIZONTAL:
                            return new CNV_Float("Input.GetAxis(\"Horizontal\")");
                        case AXISNAME.JUMP:
                            return new CNV_Float("Input.GetAxis(\"Jump\")");
                        case AXISNAME.MOUSE_SCROLLWHEEL:
                            return new CNV_Float("Input.GetAxis(\"Mouse ScrollWheel\")");
                        case AXISNAME.MOUSE_X:
                            return new CNV_Float("Input.GetAxis(\"Mouse X\")");
                        case AXISNAME.MOUSE_Y:
                            return new CNV_Float("Input.GetAxis(\"Mouse Y\")");
                        case AXISNAME.SUBMIT:
                            return new CNV_Float("Input.GetAxis(\"Submit\")");
                        case AXISNAME.VERTICAL:
                            return new CNV_Float("Input.GetAxis(\"Vertical\")");
                        default:
                            return null;
                    }
                default:
                    return null;
            }
        }
    }
}