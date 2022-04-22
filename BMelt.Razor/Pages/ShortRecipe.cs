using Microsoft.AspNetCore.Components;

namespace BMelt.Razor.Pages
{
    public partial class ShortRecipe
    {
        [Parameter]
        public ClassLibrary.Models.Recipe Model { get; set; }
    }
}
