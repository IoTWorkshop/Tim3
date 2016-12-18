using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MsgToIoTHub
{
    public sealed partial class MainPage : Page
    {

        static string connectionString = "HostName=SecuritySysteHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=8xNbj+v0tzkzwLMlvLJiucEsbuy1pPUDdfMYtGzpRk0=";
    
        static ServiceClient serviceClient;

        private static int i = 2;

        public MainPage()
        {
            InitializeComponent();
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (i % 2 == 0)
                await SendCloudToDeviceMessageAsync("1");
            else
                await SendCloudToDeviceMessageAsync("0");
            i++;

        }
        private async static Task SendCloudToDeviceMessageAsync(string podaci)
        {
            var commandMessage = new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes(podaci));
            //promjenit deviceid
            await serviceClient.SendAsync("Vedo", commandMessage);
        }
    }
}
