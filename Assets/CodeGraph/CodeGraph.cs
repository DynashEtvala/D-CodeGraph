using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
using CodeGraph.Messages;
using CodeGraph.Variables;

namespace CodeGraph
{
    [CreateAssetMenu]
    public class CodeGraph : NodeGraph
    {
        public string ComponentName;

        string CodeStr;

        List<CN_VariableBase> VNs;
        List<CN_MessageBase> SNs;
        List<CN_Base> LoopStack;
        int Scope;

        CodeGraph()
        {
            ComponentName = "Component Name";

            CodeStr = "";

            VNs = new List<CN_VariableBase>();
            SNs = new List<CN_MessageBase>();
            LoopStack = new List<CN_Base>();
            Scope = 0;
        }

        /// <summary>
        /// Iterate through all nodes and compile them into a string of c# code as a unity script.
        /// </summary>
        //[ContextMenu("Build!")] //If build button is disabled, uncomment this line
        public void BuildComponent()
        {
            PrepBuild();

            //Populate Variable list
            foreach (Node n in nodes)
            {
                //Check if n is a CN_Variable node
                if (n is CN_VariableBase)
                {
                    //add node to VNs list
                    VNs.Add((CN_VariableBase)n);
                }
            }
            
            //Populate Starter list
            foreach(Node n in nodes)
            {
                //Check if n is a CN_MessageBase
                if (n is CN_MessageBase)
                {
                    //add node to SNs list
                    SNs.Add((CN_MessageBase)n);
                }
            }

            //Add usings
            Appln("using System;");
            Appln("using System.Collections;");
            Appln("using System.Collections.Generic;");
            Appln("using UnityEngine;");

            Appln();

            //Class Header
            Appln("public class " + name + " : MonoBehaviour");
            OpenScope();
            {
                //Loop through and set up variables
                foreach(CN_VariableBase n in VNs)
                {
                    Appln(n.GetResult());
                }

                //Loop through StartNodes (Update, Start, etc. + any methods)
                foreach(CN_MessageBase n in SNs)
                {
                    //cosmetic spacing
                    Appln();

                    //Add current StartNode's method header (Start, Update, etc.)
                    Appln(n.GetResult());
                    OpenScope();

                    CN_OrderedBase curNode = null;

                    if (n.GetPort("Next").IsConnected)
                    {
                        curNode = (CN_OrderedBase)n.GetPort("Next").Connection.node;
                    }
                    //step through connected order dependant nodes (set, loops, method calls, etc)
                    while(curNode != null)
                    {
                        //determine node type and begin performance of actions
                        if(curNode is CN_OrderedBase)
                        {
                            Appln(curNode.GetResult());
                        }

                        //if loop, add to LoopStack and iterate through loop. When completed, make next node to procede to use continuation port node

                        //set curNode to next node
                        if (curNode.GetPort("Next").IsConnected)
                        {
                            curNode = (CN_OrderedBase)curNode.GetPort("Next").Connection.node;
                        }
                        else
                        {
                            curNode = null;
                        }
                    }
                    CloseScope();
                }
            }
            CloseScope();
            Debug.Log(CodeStr);

            PrepBuild();
        }

        /// <summary>
        /// Adds an open curly brace to CodeStr, adds a carriage return, then increments the Scope by 1.
        /// </summary>
        void OpenScope()
        {
            Appln("{");
            Scope++;
        }

        /// <summary>
        /// Increments the Scope by -1, adds a closing curly brace to CodeStr, then adds a carriage return.
        /// </summary>
        void CloseScope()
        {
            Scope--;
            Appln("}");
        }

        /// <summary>
        /// Adds a semicolon to CodeStr then adds a carriage return.
        /// </summary>
        void Endln()
        {
            Appln(";");
        }

        /// <summary>
        /// Adds to the end of the CodeStr string.
        /// </summary>
        /// <param name="str">The string to append</param>
        void App(string str)
        {
            CodeStr += str;
        }

        /// <summary>
        /// Adds to the end of the CodeStr string, adds a carriage return, then indents based on current Scope.
        /// </summary>
        /// <param name="str"></param>
        void Appln(string str = "")
        {
            for (int i = 0; i < Scope; i++)
            {
                App("\t");
            }
            App(str + "\n");
        }

        /// <summary>
        /// Clears the VNs and SNs lists.
        /// </summary>
        void PrepBuild()
        {
            CodeStr = "";
            VNs.Clear();
            SNs.Clear();
            Scope = 0;
        }
    }
}