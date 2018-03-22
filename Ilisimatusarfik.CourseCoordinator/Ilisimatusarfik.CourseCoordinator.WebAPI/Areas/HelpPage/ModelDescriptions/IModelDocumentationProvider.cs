using System;
using System.Reflection;

namespace Ilisimatusarfik.CourseCoordinator.WebAPI.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}