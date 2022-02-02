using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generator
{
    public class CustomSyntaxReceiver : ISyntaxReceiver
    {
        public ClassDeclarationSyntax ClassToAugment { get; private set; }
        public ClassDeclarationSyntax SupplementClass { get; private set; }

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            // Business logic to decide what we're interested in goes here
            if (syntaxNode is ClassDeclarationSyntax cds &&
                cds.Identifier.ValueText == "EndpointBuilder")
            {
                ClassToAugment = cds;
            }

            // Business logic to decide what we're interested in goes here
            if (syntaxNode is ClassDeclarationSyntax cd &&
                cd.Identifier.ValueText == "SomeTestMethods")
            {
                SupplementClass = cd;
            }
        }
    }
}