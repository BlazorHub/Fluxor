﻿using FluxorBlazorWeb.MiddlewareTutorial.Shared;
using Fluxor;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluxorBlazorWeb.MiddlewareTutorial.Client.Store.WeatherUseCase
{
	public class Effects
	{
		private readonly HttpClient Http;

		public Effects(HttpClient http)
		{
			Http = http;
		}

		[EffectMethod]
		public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
		{
			var forecasts = await Http.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
			dispatcher.Dispatch(new FetchDataResultAction(forecasts));
		}
	}
}
