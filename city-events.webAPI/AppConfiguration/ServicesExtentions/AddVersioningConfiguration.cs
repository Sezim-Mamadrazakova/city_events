using Microsoft.AspNetCore.Mvc;
namespace city_events.webAPI.AppConfiguration.ServicesExtentions{
    public static partial class ServicesExtentions{
        public static void AddVersioningConfiguration(this IServiceCollection services){
            services.AddVersionedApiExplorer(option =>{
                option.GroupNameFormat="'v' VVV";
                option.SubstituteApiVersionInUrl=true;

            });
            services.AddApiVersioning(option=>{
                option.ReportApiVersions=true;
                option.AssumeDefaultVersionWhenUnspecified=true;
                option.DefaultApiVersion=new ApiVersion(1,0);

            });
        }
    }
}