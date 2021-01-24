using AlirezaRezaee.BootstrapToastTagHelper.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace AlirezaRezaee.BootstrapToastTagHelper
{
    [HtmlTargetElement("toast")]
    public class ToastTagHelper : TagHelper
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public ToastType? Type { get; set; }

        public DateTime? DateTime { get; set; }

        public bool? Animation { get; set; }

        public bool? Autohide { get; set; }

        public int? Delay { get; set; }

        public bool? HasBootstrapIconFont { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Type == null) Type = ToastType.Information;
            if (Animation == null) Animation = true;
            if (Autohide == null) Autohide = true;
            if (Delay == null) Delay = 500;
            if (HasBootstrapIconFont == null) HasBootstrapIconFont = false;

            if (string.IsNullOrEmpty(Message))
                throw new ArgumentException("Toast Message can not be null or empty.", nameof(Message));
            else if (string.IsNullOrEmpty(Title))
                output.BindToast(Message, (ToastType)Type, (bool)Animation, (bool)Autohide, (int)Delay, (bool)HasBootstrapIconFont);
            else if (DateTime == null)
                output.BindToast(Message, Title, (ToastType)Type, (bool)Animation, (bool)Autohide, (int)Delay, (bool)HasBootstrapIconFont);
            else
                output.BindToast(Message, Title, (DateTime)DateTime, (ToastType)Type, (bool)Animation, (bool)Autohide, (int)Delay, (bool)HasBootstrapIconFont);

        }
    }
}
