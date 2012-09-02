using System;
using System.Collections.Generic;
using Rapptor.Mods.Feathers.Tagging.Domain;
using Rapptor.Mods.Feathers.Tagging.Domain.Request;
using RestSharp;

namespace Rapptor.Mods.Feathers.Tagging.Api.ApiCaller
{
	public class RestSharpTaggingApiCaller : ITaggingApiCaller
	{
		private readonly string _apiBase;
		private readonly RestClient _apiClient;
		
		public RestSharpTaggingApiCaller(string apiBase)
		{
			_apiBase = apiBase;
			_apiClient = new RestClient(_apiBase);
		}

		private static void ProcessRequestParameters(IRestRequest request, IEnumerable<RequestParameter> requestParameters)
		{
			foreach (var requestParameter in requestParameters)
			{
				request.AddParameter(requestParameter.Name, requestParameter.Value);
			}
		}

		public TReturn ApiGet<TReturn>(string endpointToCall, params RequestParameter[] requestParameters) where TReturn : new()
		{
			var request = new RestRequest(endpointToCall, Method.GET) { RequestFormat = DataFormat.Json };

			if (requestParameters != null)
				ProcessRequestParameters(request, requestParameters);

			var response = _apiClient.Execute<TReturn>(request);

			if(response.ErrorException != null)
				throw response.ErrorException;

			if(response.ErrorMessage != null)
				throw new Exception(string.Format("Api Get of type {0} to endpoint {1} failed with message {2}", typeof(TReturn), _apiBase + endpointToCall, response.ErrorMessage));

			return response.Data;
		}

		public TReturn ApiPost<TBody, TReturn>(string endpointToCall, TBody body = null, params RequestParameter[] requestParameters) where TReturn : new() where TBody : class, new()
		{
			var request = new RestRequest(endpointToCall, Method.POST) { RequestFormat = DataFormat.Json };
			request.AddHeader("Content-Type", "application/json");

			if(body != null)
				request.AddBody(body);

			if (requestParameters != null)
				ProcessRequestParameters(request, requestParameters);

			var response = _apiClient.Execute<TReturn>(request);

			if (response.ErrorException != null)
				throw response.ErrorException;

			if (response.ErrorMessage != null)
				throw new Exception(string.Format("Api Post of type {0} to endpoint {1} failed with message {2}", typeof(TReturn), _apiBase + endpointToCall, response.ErrorMessage));

			return response.Data;
		}

		public TReturn ApiPost<TReturn>(string endpointToCall, params RequestParameter[] requestParameters) where TReturn : new()
		{
			var response = ApiPost<object, TReturn>(endpointToCall, requestParameters);

			return response;
		}

		public TReturn ApiDelete<TReturn>(string endpointToCall) where TReturn : new()
		{
			var request = new RestRequest(endpointToCall, Method.DELETE)  { RequestFormat = DataFormat.Json };

			var response = _apiClient.Execute<TReturn>(request);

			if (response.ErrorException != null)
				throw response.ErrorException;

			if (response.ErrorMessage != null)
				throw new Exception(string.Format("Api Delete of type {0} to endpoint {1} failed with message {2}", typeof(TReturn), _apiBase + endpointToCall, response.ErrorMessage));

			return response.Data;
		}
	}
}
