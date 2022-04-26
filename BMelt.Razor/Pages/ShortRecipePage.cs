using BMelt.ClassLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace BMelt.Razor.Pages
{
    public partial class ShortRecipePage
    {
        [Parameter]
        public Recipe Model { get; set; }
    }
}
