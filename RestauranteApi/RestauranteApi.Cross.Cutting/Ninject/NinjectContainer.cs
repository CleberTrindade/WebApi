using Ninject;
namespace RestauranteApi.Cross.Cutting.Ninject
{
    public class NinjectContainer
    {
        #region Register
        public static void Register(IKernel kernel)
        {
            RegisterRepositories(kernel);
            RegisterServices(kernel);
        }
        #endregion


        #region RegisterServices
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(Domain.Interfaces.Services.IServiceBase<>)).To(typeof(Domain.Services.ServiceBase<>));

            kernel.Bind<Domain.Interfaces.Services.IRestauranteService>().To<Domain.Services.RestauranteService>();
            kernel.Bind<Domain.Interfaces.Services.IPratoService>().To<Domain.Services.PratoService>();
        }
        #endregion

        #region RegisterRepositories
        private static void RegisterRepositories(IKernel kernel)
        {
            kernel.Bind(typeof(Domain.Interfaces.Repositories.IRepositoryBase<>)).To(typeof(Data.Repositories.RepositoryBase<>));

            kernel.Bind<Domain.Interfaces.Repositories.IRestauranteRepository>().To<Data.Repositories.RestauranteRepository>();
            kernel.Bind<Domain.Interfaces.Repositories.IPratoRepository>().To<Data.Repositories.PratoRepository>();
        }
        #endregion
    }
}
