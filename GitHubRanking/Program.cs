using System;
using Core;

namespace GitHubRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GitHubProxy.GetRepositories("c#"));

            Console.WriteLine("please enter graphql string");

            while (true)
            {
                var graphql = Console.ReadLine();
                var response = GitHubProxy.Request(graphql);
                Console.WriteLine(response);
                Console.WriteLine("--------------");
            }
        }
    }
}