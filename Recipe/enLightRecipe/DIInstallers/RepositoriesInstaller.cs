using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using enLightRecipe.Models;

namespace enLightRecipe.DIInstallers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IRepository>().ImplementedBy<Repository>().LifestylePerWebRequest());
            container.Register(
                Component.For<enLightRecipeContext>());
        }
    }
}