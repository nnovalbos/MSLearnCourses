using System;
using Xamarin.Forms;

namespace SmartHome
{
    public class DeviceTemplateSelector : DataTemplateSelector
    {
        private DataTemplate _doorBellTemplate;
        private DataTemplate _smokeDetectorTemplate;
        private DataTemplate _thermostatTemplate;

        public DeviceTemplateSelector()
        {
            _doorBellTemplate = new DataTemplate(typeof(DoorBellViewCell));
            _smokeDetectorTemplate = new DataTemplate(typeof(SmokeDetectorViewCell));
            _thermostatTemplate = new DataTemplate(typeof(ThermostatViewCell));
        }

        

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if(item is DoorBell)
            {
                return _doorBellTemplate;
            }

            if (item is SmokeDetector)
            {
                return _smokeDetectorTemplate;
            }

            if (item is Thermostat)
            {
                return _thermostatTemplate;
            }
     
            throw new NotSupportedException("Type no supported");
         
        }
    }
}
