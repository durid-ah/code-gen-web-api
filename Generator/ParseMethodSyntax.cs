using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class ParseMethodSyntax
    {
        public static string ParseMethodNodes(IEnumerable<MethodDeclarationSyntax> methods)
        {
            foreach (var item in methods)
            {
                item.Identifier.GetAnnotations();
                var nodes = item.ParameterList.Parameters;//.ChildNodes();
                foreach (var node in nodes)
                {
                    //node
                }
            }

            return "";
        }
    }
}
