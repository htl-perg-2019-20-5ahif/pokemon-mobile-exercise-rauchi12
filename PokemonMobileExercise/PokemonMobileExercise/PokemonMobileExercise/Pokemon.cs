using System;
using System.Collections.Generic;
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
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("sprites")]
        public Sprites Sprites { get; set; }
        [JsonPropertyName("abilities")]
        public List<Ability> Abilities { get; set; }
    }
    public class Pokemons
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
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
