using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace IOT_Hub_sender
{
    class Program
    {
        static ServiceClient serviceClient;
        static string connectionString = "HostName=vishaliothub.azure-devices.net;DeviceId=VishalIotDevice;SharedAccessKey=kjzugZtDGYALkwnF/ILciH+9pai6RTLBmk/dQKJV6kg=";
        static void Main(string[] args)
        {
            Console.WriteLine("Send message to IOT device");
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            Console.WriteLine("Press any key to send message");
            Console.ReadLine();
            SendC2DMsgAsync().Wait();
            Console.ReadLine();
        }
        private async static Task SendC2DMsgAsync() 
        {
            var commandMessage = new
                Message(Encoding.ASCII.GetBytes("Sending message from Cloud to device"));
            await serviceClient.SendAsync("VishalIotDevice",commandMessage);
        }
    }
}
