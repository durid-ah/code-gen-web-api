using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generator
{
    [Generator]
    public class EndpointGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new CustomSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // the generator infrastructure will create a receiver and populate it
            // we can retrieve the populated instance via the context
            CustomSyntaxReceiver syntaxReceiver = (CustomSyntaxReceiver)context.SyntaxReceiver;

            // get the recorded user class
            ClassDeclarationSyntax userClass = syntaxReceiver.ClassToAugment;
            var nameSpace = userClass.Parent as NamespaceDeclarationSyntax;
            ClassDeclarationSyntax suppClass = syntaxReceiver.SupplementClass;

            var s = suppClass.Members.Where(x => x is MethodDeclarationSyntax);

            var supplementClassMembers = suppClass.Members
                .Where(x => x is MethodDeclarationSyntax)
                .Select(m => m as MethodDeclarationSyntax);
                //.SelectMany(m => m.ParameterList.Parameters).Select(m => m.Type.ToString())); // returns the parameter types for a method
                

            // add the generated implementation to the compilation
                SourceText sourceText = SourceText.From($@"
using System;

namespace {nameSpace.Name};
public partial class {userClass.Identifier}
{{
    
    static partial void BuildEndpoints(WebApplication app)
    {{
        app.MapGet(""/test"", () => ""generated"").WithName(""Gen"");
    }}
}}", Encoding.UTF8);

            context.AddSource("EndpointBuilder.g.cs", sourceText);
        }
    }
}
