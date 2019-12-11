using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace PokemonMobileExercise
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }

    }

    public class PokemonDetailed
    {
        public string Name { get; set; }
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }
        [JsonPropertyName("abilities")]
        public List<AbilitySlot> AbilitySlots { get; set; }
    }
    public class Pokemons
    {
        [JsonPropertyName("results")]
        public ObservableCollection<Pokemon> Results { get; set; }
    }

    public class AbilitySlot
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class Sprites
    {
        [JsonPropertyName("front_default")]
        public string ImageFrontUrl { get; set; }
        [JsonPropertyName("back_default")]
        public string ImageBackUrl { get; set; }
    }
}
