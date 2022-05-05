using BMelt.ClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace BMelt.Razor.Pages
{
    public partial class RecipeCard
    {
        [Parameter]
        public Recipe Model { get; set; }
    }
}
