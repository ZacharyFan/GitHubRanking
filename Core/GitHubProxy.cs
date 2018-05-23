using System;
using System.Net.Http.Headers;
using Core.Models;
using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Newtonsoft.Json;

namespace Core
{
    public class GitHubProxy
    {
        public static string Request(string graphql)
        {
            try
            {
                var heroRequest = new GraphQLRequest
                {
                    Query = graphql
                };

                var graphQLClient = new GraphQLClient("https://api.github.com/graphql");

                graphQLClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Safari", "537.36"));
                graphQLClient.DefaultRequestHeaders.Add("Authorization", "bearer " + ConfigManager.Token);
                var graphQLResponse = graphQLClient.PostAsync(heroRequest).Result;
                return graphQLResponse.Data.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static SearchResult GetRepositories(string language, string cursor = "")
        {
            string graphql = @"fragment repFragment on Repository {
  name,
  forkCount,
  url,
  createdAt,
  updatedAt,
  licenseInfo{
    nickname
  },
  stargazers{
    totalCount
  }
}

query {
  search(query:" + "\"" + string.Format("language:{0}", language) + "\"" + @",type:REPOSITORY,first:100" + (cursor == "" ? "" : string.Format(",after:\"{0}\"", cursor)) + @"){
                repositoryCount,
                edges{
                cursor,
                node{
                        ...repFragment
                }
            }
        }
    }";

            var searchResult = JsonConvert.DeserializeObject<SearchResult>(Request(graphql));
            return searchResult;
        }
    }
}
