using System;
using System.Reflection;

namespace OpenQbit.PaymentGateway.Presentation.Web.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}