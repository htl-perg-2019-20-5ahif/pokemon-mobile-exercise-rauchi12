using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonMobileExercise
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        //public PokemonDetailed Pokemon { get; set; }
        public DetailPage(PokemonDetailed details)
        {
            InitializeComponent();
            //Pokemon = details;
            BindingContext = details/*this*/;
        }
    }
}