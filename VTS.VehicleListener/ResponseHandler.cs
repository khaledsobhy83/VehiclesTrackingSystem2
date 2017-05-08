using VTS.BL;
using Autofac;
using VTS.DependencyInjectionRegister;

namespace VTS.VehicleListener
{
    public class ResponseHandler : IResponseHandler
    {
        IVehiclesManager _vehicleManager;

        private IContainer _constainer;

        public ResponseHandler()
        {
            var builder = new ContainerBuilder();

            builder = ServiceRegistry.Register(builder);

            _constainer = builder.Build();
        }

        public void HandleResponse(string vehicleId)
        {

            using (var scope = _constainer.BeginLifetimeScope())
            {
                _vehicleManager = scope.Resolve<IVehiclesManager>();
            }

            _vehicleManager.UpdateVehicleStatus(vehicleId, Helpers.Enums.VehicleStatusEnum.Online);
        }
    }
}
