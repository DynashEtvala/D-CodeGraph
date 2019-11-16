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
    public class CN_Var
    {
        public string Name;
        public CN_TYPE CN_Type;
    }

    [Serializable]
    public class CN_Int : CN_Var
    {
        public CN_Int()
        {
            CN_Type = CN_TYPE.CN_INT;
        }

        public CN_Int(string varName) : this()
        {
            Name = varName;
        }
    }

    [Serializable]
    public class CN_Float : CN_Var
    {
    }

    [Serializable]
    public class CN_String : CN_Var
    {
    }

    [Serializable]
    public class CN_Vector2 : CN_Var
    {
    }

    [Serializable]
    public class CN_Vector3 : CN_Var
    {
    }

    [Serializable]
    public class CN_Bool : CN_Var
    {
    }

    [Serializable]
    public class CN_Color : CN_Var
    {
    }

    [Serializable]
    public class CN_Transform : CN_Var
    {
    }

    [Serializable]
    public class CN_GameObject : CN_Var
    {
    }

    [Serializable]
    public class CN_Quaternion : CN_Var
    {
    }

    [Serializable]
    public class CN_Monobehavior : CN_Var
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