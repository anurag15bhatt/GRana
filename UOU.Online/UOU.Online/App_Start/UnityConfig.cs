using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using UOU.Online.BusinessLayer.Repository;

namespace UOU.Online
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}