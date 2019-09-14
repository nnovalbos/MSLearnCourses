using Xamarin.Forms;
using System.Linq;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var itemsGroupByLetter = DeviceManager.Instance.Value.Devices.OrderBy(x => x.Name).ToLookup(device => device.Name[0]);

            //por tipos de sipositivo
            var itemsGroupByDeviceType = DeviceManager.Instance.Value.Devices.ToLookup(device =>  device.GetType().Name);


            BindingContext = itemsGroupByDeviceType;

            // BindingContext = DeviceManager.Instance.Value.Devices;
        }
    }
}
