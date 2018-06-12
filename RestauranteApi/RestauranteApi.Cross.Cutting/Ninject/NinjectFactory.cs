using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteApi.Cross.Cutting.Ninject
{
    public class NinjectFactory : IDisposable
    {
        #region Properties
        private StandardKernel kernel;
        #endregion

        #region Construtor
        public NinjectFactory()
        {
            kernel = new StandardKernel();

            NinjectContainer.Register(kernel);
        }
        #endregion

        #region CreateInstance
        /// <summary>
        /// Criar instancia
        /// </summary>
        /// <typeparam name="T">Interface</typeparam>
        /// <returns></returns>
        public dynamic CreateInstance<T>()
        {
            List<object> parametros = new List<object>();
            Type servico = kernel.Get<T>().GetType();
            var tipos = servico.GetConstructors()[0].GetParameters().Select(p => p.ParameterType);

            foreach (var tipo in tipos)
            {
                parametros.Add(kernel.Get(tipo));
            }

            return Activator.CreateInstance(servico, parametros.ToArray());
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            kernel.Dispose();
        }
        #endregion
    }
}
