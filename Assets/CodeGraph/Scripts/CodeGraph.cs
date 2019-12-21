using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using XNode;
using CodeGraph.Logic;

namespace CodeGraph
{
    [CreateAssetMenu]
    public class CodeGraph : NodeGraph
    {
        public string ComponentName;
        public string FilePath;

        string CodeStr;

        List<CN_VariableBase> VNs;
        List<CN_MessageBase> SNs;
        Stack<CN_OrderedBase> ScopeStack;
        int Scope;

        CodeGraph()
        {
            CodeStr = "";

            VNs = new List<CN_VariableBase>();
            SNs = new List<CN_MessageBase>();
            ScopeStack = new Stack<CN_OrderedBase>();
            Scope = 0;
        }

        /// <summary>
        /// Iterate through all nodes and compile them into a string of c# code as a unity script.
        /// </summary>
        //[ContextMenu("Build!")] //If build button is disabled, uncomment this line
        public void BuildComponent()
        {
            PrepBuild();

            Appln("//" + FilePath);

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

                    if (n.GetPort("Next").IsConnected)
                    {
                        ScopeStack.Push((CN_OrderedBase)n.GetPort("Next").Connection.node);
                    }
                    
                    //step through connected order dependant nodes (set, loops, method calls, etc)
                    while(ScopeStack.Count != 0)
                    {
                        CN_OrderedBase curNode = ScopeStack.Peek();
                        //determine node type and begin performance of actions
                        if (curNode is CN_ScopedOrderedBase)
                        {
                            //has the node been evaluated already?
                            if(!(curNode as CN_ScopedOrderedBase).Evaluated)
                            {
                                Appln(curNode.GetResult());
                            }
                        }
                        else
                        {
                            Appln(curNode.GetResult());
                        }

                        if (!(curNode is CN_ScopedOrderedBase))
                        {
                            ScopeStack.Pop();
                            if (curNode.GetOutputPort("Next").IsConnected)
                            {
                                ScopeStack.Push(curNode.GetOutputPort("Next").GetConnection(0).node as CN_OrderedBase);
                            }
                            else if(ScopeStack.Count > 1)
                            {
                                CloseScope();
                            }
                            continue;
                        }
                        if(curNode is CN_If)
                        {
                            if (!(curNode as CN_If).Evaluated)
                            {
                                OpenScope();
                                ScopeStack.Push(curNode.GetOutputPort("True").GetConnection(0).node as CN_OrderedBase);
                                (curNode as CN_If).Evaluated = true;
                                continue;
                            }
                            else
                            {
                                CloseScope();
                                ScopeStack.Pop();
                                if (curNode.GetOutputPort("Next").IsConnected)
                                {
                                    ScopeStack.Push(curNode.GetOutputPort("Next").GetConnection(0).node as CN_OrderedBase);
                                }
                                else if (ScopeStack.Count > 1)
                                {
                                    CloseScope();
                                }
                                (curNode as CN_If).Evaluated = false;
                                continue;
                            }
                        }
                    }
                    CloseScope();
                }
            }
            CloseScope();
            Debug.Log(CodeStr);

            File.WriteAllBytes(FilePath, new UTF8Encoding(true).GetBytes(""));

            using (FileStream fs = File.OpenWrite(FilePath))
            {
                AddTextToFile(fs, CodeStr);
            }
            
            PrepBuild();
        }

        private static void AddTextToFile(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
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
            ComponentName = name;
            CodeStr = "";
            VNs.Clear();
            SNs.Clear();
            Scope = 0;
        }
    }
}