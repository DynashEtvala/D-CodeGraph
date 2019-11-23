﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace CodeGraph
{
    public enum CN_TYPE { CN_INT, CN_FLOAT, CN_STRING, CN_VECTOR2, CN_VECTOR3, CN_BOOL, CN_COLOR, CN_TRANSFORM, CN_GAMEOBJECT, CN_QUATERNION, CN_MONOBEHAVIOUR };
    public enum CN_ACCESSABILITY { PUBLIC, PRIVATE, PROTECTED, PRIVATE_SERIALIZABLE };

    [Serializable]
    public class CN_Coupler { }

    [Serializable]
    public class CNV_Var
    {
        public string Name;
        public CN_TYPE CN_Type;
    }

    [Serializable]
    public class CNV_Int : CNV_Var
    {
        public CNV_Int()
        {
            CN_Type = CN_TYPE.CN_INT;
        }

        public CNV_Int(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_Float : CNV_Var
    {
        public CNV_Float()
        {
            CN_Type = CN_TYPE.CN_FLOAT;
        }

        public CNV_Float(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_String : CNV_Var
    {
        public CNV_String()
        {
            CN_Type = CN_TYPE.CN_STRING;
        }

        public CNV_String(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_Vector2 : CNV_Var
    {
        public CNV_Vector2()
        {
            CN_Type = CN_TYPE.CN_VECTOR2;
        }

        public CNV_Vector2(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_Vector3 : CNV_Var
    {
        public CNV_Vector3()
        {
            CN_Type = CN_TYPE.CN_VECTOR3;
        }

        public CNV_Vector3(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_Bool : CNV_Var
    {
    }

    [Serializable]
    public class CNV_Color : CNV_Var
    {
    }

    [Serializable]
    public class CNV_Transform : CNV_Var
    {
        public CNV_Transform()
        {
            CN_Type = CN_TYPE.CN_TRANSFORM;
        }

        public CNV_Transform(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_GameObject : CNV_Var
    {
    }

    [Serializable]
    public class CNV_Quaternion : CNV_Var
    {
        public CNV_Quaternion()
        {
            CN_Type = CN_TYPE.CN_QUATERNION;
        }

        public CNV_Quaternion(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CNV_Monobehavior : CNV_Var
    {
    }

    public class CN_Base : Node
    {
        /// <summary>
        /// Return the code to be generated by this node.
        /// </summary>
        /// <returns></returns>
        public virtual string GetResult()
        {
            return null;
        }

        /// <summary>
        /// Get the CN_Var from the selected port.
        /// </summary>
        /// <param name="portName">Name of the port to be pulled from</param>
        /// <returns></returns>
        protected CNV_Var InputVar(string portName)
        {
            return (GetInputPort(portName).GetInputValue() as CNV_Var);
        }

        /// <summary>
        /// Get the Name value from the selected port's CN_Var.
        /// </summary>
        /// <param name="portName">Name of the port to be pulled from</param>
        /// <returns></returns>
        protected string InputVarName(string portName)
        {
            return (GetInputPort(portName).GetInputValue() as CNV_Var).Name;
        }

        /// <summary>
        /// Returns the selected CN_TYPE as a string of the type it represents.
        /// </summary>
        /// <param name="cn_type"></param>
        /// <returns></returns>
        public static string CNTypeToString(CN_TYPE cn_type)
        {
            switch (cn_type)
            {
                case CN_TYPE.CN_INT:
                    return "int";
                case CN_TYPE.CN_FLOAT:
                    return "float";
                case CN_TYPE.CN_STRING:
                    return "string";
                case CN_TYPE.CN_VECTOR2:
                    return "Vector2";
                case CN_TYPE.CN_VECTOR3:
                    return "Vector3";
                case CN_TYPE.CN_BOOL:
                    return "bool";
                case CN_TYPE.CN_COLOR:
                    return "Volor";
                case CN_TYPE.CN_TRANSFORM:
                    return "Transform";
                case CN_TYPE.CN_GAMEOBJECT:
                    return "GameObject";
                case CN_TYPE.CN_QUATERNION:
                    return "Quaternion";
                case CN_TYPE.CN_MONOBEHAVIOUR:
                    return "MonoBehaviour";
                default:
                    throw new Exception("Invalid CN_TYPE");
            }
        }

        /// <summary>
        /// Returns the selected CN_ACCESSABILITY as a string of the accessability type it represents.
        /// </summary>
        /// <param name="cn_type"></param>
        /// <returns></returns>
        public static string CNAccessabilityToString(CN_ACCESSABILITY cn_accessability)
        {
            switch (cn_accessability)
            {
                case CN_ACCESSABILITY.PUBLIC:
                    return "public";
                case CN_ACCESSABILITY.PRIVATE:
                    return "private";
                case CN_ACCESSABILITY.PROTECTED:
                    return "protected";
                case CN_ACCESSABILITY.PRIVATE_SERIALIZABLE:
                    return "[SerializeField] private";
                default:
                    throw new Exception("Invalid CN_ACCESSABILITY");
            }
        }
    }
}