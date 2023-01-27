using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace HospitalManager.Helpers
{
	public static class GenerateDashboard
	{

		public static IHtmlContent CardWithButton(this IHtmlHelper html, string title, string text, string buttonText, string buttonUrl)
		{
			string card = $"<div class='card col'>" +
			              $"<div class='card-header'>" +
			              $"<h4>{title}</h4>" +
			              $"</div>" +
			              $"<div class='card-body'>" +
			              $"<p>{text}</p>" +
			              $"<a href='{buttonUrl}' class='btn btn-primary'>{buttonText}</a>" +
			              $"</div>" +
			              $"</div>";
			return html.Raw(card);
		}

		public static IHtmlContent CardWithCounter(this IHtmlHelper html, string title, string text,
			int counter)
		{
			string card = $"<div class='card col'>" +
			              $"<div class='card-header'>" +
			              $"<h4>{title}</h4>" +
			              $"</div>" +
			              $"<div class='card-body'>" +
			              $"<p>{text} <span>{counter}</span></p>" +
			              $"</div>" +
			              $"</div>";
			return html.Raw(card);
		}

	}
}