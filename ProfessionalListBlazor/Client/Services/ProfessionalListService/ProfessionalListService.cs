using Microsoft.AspNetCore.Components;
using ProfessionalListBlazor.Client.Pages;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace ProfessionalListBlazor.Client.Services.ProfessionalListService
{
    public class ProfessionalListService : IProfessionalListService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProfessionalListService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ProfessionalList> Lists { get ; set ; } = new List<ProfessionalList>();
        public List<Style> Styles { get; set; } = new List<Style>();

        public async Task CreateList(ProfessionalList list)
        {
            var result = await _http.PostAsJsonAsync("api/professionallist", list);
            await SetLists(result);
        }

        private async Task SetLists(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ProfessionalList>>();
            Lists = response;
            _navigationManager.NavigateTo("professionallists");
        }

        public async Task DeleteList(int id)
        {
            var result = await _http.DeleteAsync($"api/professionallist/{id}");
            await SetLists(result);
        }

        public async Task GetProfessionalLists()
        {
            var result = await _http.GetFromJsonAsync<List<ProfessionalList>> ("api/professionallist");
            if (result != null)
            {
                Lists = result;
            }
        }

        public async Task<ProfessionalList> GetSingleList(int id)
        {
            var result = await _http.GetFromJsonAsync<ProfessionalList>($"api/professionallist/{id}");
                if (result != null)
                    return result;
                throw new Exception("Professional Not Found. ;/");
            
        }

        public async Task GetStyles()
        {
            var result = await _http.GetFromJsonAsync<List<Style>>("api/professionallist/styles");
            if (result != null)
                Styles = result;
        }

        public async Task UpdateList(ProfessionalList list)
        {
            var result = await _http.PutAsJsonAsync($"api/professionallist/{list.Id}", list);
            await SetLists(result);
        }
    }
}
