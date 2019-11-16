using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public class CN_Variable : CN_Base
    {
        public string Name;

        public CN_TYPE type;

        public CN_ACCESSABILITY accessability;

        [Output] public CN_Var result;

        // Use this for initialization
        protected override void Init()
        {
            base.Init();
            type = CN_TYPE.CN_INT;
            accessability = CN_ACCESSABILITY.PUBLIC;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
            switch (port.fieldName)
            {
                case "result":
                    CN_Var valResult;
                    switch (type)
                    {
                        case CN_TYPE.CN_INT:
                            valResult = new CN_Int(Name);
                            break;
                        default:
                            return null;
                    }
                    return valResult;
                default:
                    return null;
            }
        }

        public override string GetResult()
        {
            return CNAccessabilityToString(accessability) + " " + CNTypeToString(type) + " " + Name + ";";
        }
    }
}