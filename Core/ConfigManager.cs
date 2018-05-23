using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public class ConfigManager
    {
        public static string Token;

        static ConfigManager()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddInMemoryCollection() //将配置文件的数据加载到内存中
                .SetBasePath(Directory.GetCurrentDirectory()) //指定配置文件所在的目录
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            Token = config["token"];
        }
    }
}
