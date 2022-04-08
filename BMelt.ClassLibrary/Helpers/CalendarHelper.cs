using Microsoft.AspNetCore.Components;
using System.Text;

namespace BMelt.ClassLibrary.Helpers
{
    public class CalendarHelper
    {
        public MarkupString RenderView()
        {
            var sb = new StringBuilder();
            sb.Append("<td>");
            sb.Append("<label for= />");
            sb.Append("</td>");
            return (MarkupString)sb.ToString();
        }
    }
}
