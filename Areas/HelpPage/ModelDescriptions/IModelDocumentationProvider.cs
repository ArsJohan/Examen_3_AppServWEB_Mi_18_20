using System;
using System.Reflection;

namespace Examen_3_AppServWEB_Mi_18_20.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}