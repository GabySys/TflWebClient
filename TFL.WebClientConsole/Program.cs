using System;

namespace TFL.WebClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {   
            string appID = Properties.Settings.Default.AppId;            
            string appKey = Properties.Settings.Default.AppKey;

            Client client = new Client(new ClientWrapper());

            if (args.Length == 0)
            {
                Console.WriteLine($"The client requires one argumen.");
                Environment.Exit(2);
            }
            try
            {
                RoadCorridor roadInfo = client.Run(args[0], appID, appKey).GetAwaiter().GetResult();
                
                if (roadInfo == null)
                {
                    Environment.Exit(2);
                }

                Console.WriteLine($"The status of the {roadInfo.DisplayName} is as follows");
                Console.WriteLine($"        Road Status is {roadInfo.StatusSeverity}");
                Console.WriteLine($"        Road Status Description is {roadInfo.StatusSeverityDescription}");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"{args[0]} is not a valid road. Error:{ex.ApiError.Message}");
                Environment.Exit(1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(2);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
