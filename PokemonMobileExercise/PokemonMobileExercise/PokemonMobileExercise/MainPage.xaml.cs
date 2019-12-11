using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PokemonMobileExercise
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PokemonDetailed> PokemonDetaileds { get; set; }

        //****************************
        //  TODO:
        //
        //  - Show Sprites on
        //      - MainPage
        //      - DetailPage
        //
        //****************************


        private static readonly HttpClient HttpClient = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            PokemonDetaileds = new ObservableCollection<PokemonDetailed>();
            BindingContext = this;
        }
        public async Task<Pokemons> GetPokemon()
        {
            var pokemonResponse = await HttpClient.GetAsync("https://pokeapi.co/api/v2/pokemon");
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemons = JsonSerializer.Deserialize<Pokemons>(responseBody);
            pokemons.Results.ForEach(p => Console.WriteLine(p.Name));
            return pokemons;
        }

        public async Task<PokemonDetailed> GetPokemonDetailed(Pokemon pokemon)
        {
            var pokemonResponse = await HttpClient.GetAsync(pokemon.Url);
            pokemonResponse.EnsureSuccessStatusCode();
            var responseBody = await pokemonResponse.Content.ReadAsStringAsync();
            var pokemonDetailed = JsonSerializer.Deserialize<PokemonDetailed>(responseBody);
            pokemonDetailed.Name = pokemon.Name;
            return pokemonDetailed;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pokemons = await GetPokemon();
            foreach(var pokemon in pokemons.Results)
            {
                var pokemonDetailed = await GetPokemonDetailed(pokemon);
                PokemonDetaileds.Add(pokemonDetailed);
            }
        }

        public async void ListView_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var details = e.Item as PokemonDetailed;
                await Navigation.PushModalAsync(new DetailPage(details));
            }
        }
    }
}
