using FruitBaskets.Products.Application;
using FruitBaskets.Products.Infrastructure;

namespace FruitBaskets.Products.API
{
    public static class ServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //SingleTon

            //Scoped
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IProductGetUsecase, ProductGetUsecase>();
            services.AddScoped<IProductCreateUsecase, ProductCreateUsecase>();


            //Transient
            services.AddTransient<IDataPersistency, DataPersistency>();
            services.AddTransient<ExceptionMiddleware>();

            //var types=GetTypes();
            //foreach (var type in types)
            //{

            //}
        }
        //private static IEnumerable<Type> GetTypes()
        //{           
        //    var types=new List<Type>();
        //    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        //    {
        //        if (assembly.GetName().Name.StartsWith("FruitBasket", StringComparison.OrdinalIgnoreCase))
        //        {
        //            foreach (Type type in assembly.GetTypes())
        //            {
        //                if (type.IsClass && (type.IsAssignableTo(typeof(IScoped)) || type.IsAssignableTo(typeof(ITransient))
        //                   || type.IsAssignableTo(typeof(ISingleTon))))
        //                {
        //                   types.Add(type);
        //                }
        //            }
        //        }
        //    }
        //    return types;
        //}
    }
}
