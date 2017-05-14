using VTS.BL;
using Autofac;
using VTS.DependencyInjectionRegister;
using System.Text;

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

        public string HandleResponse(byte[] response, int responseSize)
        {
            var vehicleId = Encoding.ASCII.GetString(response, 0, responseSize);

            using (var scope = _constainer.BeginLifetimeScope())
            {
                _vehicleManager = scope.Resolve<IVehiclesManager>();
            }

            _vehicleManager.UpdateVehicleStatus(vehicleId, Helpers.Enums.VehicleStatusEnum.Online);

            return vehicleId;
        }
    }
}
