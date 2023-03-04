using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Xml;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.XML
{
    public static class XmlInputExtension
    {
        public static IServiceCollection AddXmlInput(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new ProducesAttribute("text/xml"));
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter(new XmlWriterSettings
                {
                        OmitXmlDeclaration = false
                }));
            })
            .AddXmlSerializerFormatters()
            .AddXmlDataContractSerializerFormatters();

            return services;
        }
    }
}
