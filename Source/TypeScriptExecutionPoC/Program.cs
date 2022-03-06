using Jering.Javascript.NodeJS;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace TypeScriptExecutionPoC;

public class Program
{
    public static void Main()
    {
        try
        {
            var services = new ServiceCollection();

            services.AddNodeJS();
            services.AddScoped<ScriptFactory>();
            services.AddScoped<IJavascriptExecutor, JavascriptExecutor>();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IJavascriptExecutor>();
            var ast = service?.Execute("generateAst", new object[] { "Resources/SampleSmartContract.sol" }).Result;
            var code = service?.Execute("generateCode", new object[] { JsonConvert.DeserializeObject<JavascriptResponse>(ast)?.Data }).Result;

            Console.WriteLine(code);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}