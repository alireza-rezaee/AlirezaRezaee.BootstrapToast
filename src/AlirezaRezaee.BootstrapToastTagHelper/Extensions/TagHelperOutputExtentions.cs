using AlirezaRezaee.BootstrapToastTagHelper.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace AlirezaRezaee.BootstrapToastTagHelper.Extensions
{

    public static class TagHelperOutputExtensions
    {
        public static void BindToast(this TagHelperOutput tagHelperOutput,
            string message,
            ToastType type = ToastType.Information,
            bool hasAnimation = true,
            bool hasAutoHide = true,
            int delay = 500,
            bool hasBootstrapIconFont = false)
        {
            tagHelperOutput.TagName = "div";
            BindToastOptions(ref tagHelperOutput, hasAnimation: hasAnimation, hasAutoHide: hasAutoHide, delay: delay);

            tagHelperOutput.Attributes.SetAttribute("class", $"toast d-flex align-items-center text-white {PrintColor(type)}");
            tagHelperOutput.Content.SetHtmlContent($"<div class=\"toast-body\">\n{message}\n</div>"
                + "<button type=\"button\" class=\"btn-close ms-auto me-2\" data-bs-dismiss=\"toast\" aria-label=\"Close\"></button>");
        }

        public static void BindToast(this TagHelperOutput tagHelperOutput,
            string message,
            string title,
            ToastType type = ToastType.Information,
            bool hasAnimation = true,
            bool hasAutoHide = true,
            int delay = 500,
            bool hasBootstrapIconFont = false)
        {
            tagHelperOutput.TagName = "div";
            BindToastOptions(ref tagHelperOutput, hasAnimation: hasAnimation, hasAutoHide: hasAutoHide, delay: delay);

            tagHelperOutput.Content.SetHtmlContent("<div class=\"toast-header\">\n"
                + PrintIcon(type, hasBootstrapIconFont)
                + $"<strong class=\"me-auto\">{title}</strong>"
                + "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"toast\" aria-label=\"Close\"></button>"
                + $"</div>\n<div class=\"toast-body\">\n{message}\n</div>");
        }

        public static void BindToast(this TagHelperOutput tagHelperOutput,
            string message,
            string title,
            DateTime dateTime,
            ToastType type = ToastType.Information,
            bool hasAnimation = true,
            bool hasAutoHide = true,
            int delay = 500,
            bool hasBootstrapIconFont = false)
        {
            tagHelperOutput.TagName = "div";
            BindToastOptions(ref tagHelperOutput, hasAnimation: hasAnimation, hasAutoHide: hasAutoHide, delay: delay);

            tagHelperOutput.Attributes.SetAttribute("class", $"toast text-white {PrintColor(type)}");
            tagHelperOutput.Content.SetHtmlContent("<div class=\"toast-header\">\n"
                + PrintIcon(type, hasBootstrapIconFont)
                + $"<strong class=\"me-auto\">{title}</strong>"
                + ((dateTime != null) ? $"<time class=\"text-muted small timeago fa-num\" datetime=\"{dateTime:s}\"></time>" : string.Empty)
                + "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"toast\" aria-label=\"Close\"></button>"
                + $"</div>\n<div class=\"toast-body\">\n{message}\n</div>");
        }

        private static void BindToastOptions(ref TagHelperOutput tagHelperOutput,
            bool hasAnimation = true,
            bool hasAutoHide = true,
            int delay = 500)
        {
            tagHelperOutput.Attributes.SetAttribute("data-bs-animation", hasAnimation ? "true" : "false");
            tagHelperOutput.Attributes.SetAttribute("data-bs-autohide", hasAutoHide ? "true" : "false");
            tagHelperOutput.Attributes.SetAttribute("data-bs-delay", delay);
        }

        private static string PrintIcon(ToastType type, bool hasBootstrapIconFont = true)
        {
            switch (type)
            {
                case ToastType.Error:
                    return hasBootstrapIconFont ? ToastBootstrapIconHtml.Error : ToastIconHtml.Error;
                case ToastType.Warning:
                    return hasBootstrapIconFont ? ToastBootstrapIconHtml.Warning : ToastIconHtml.Warning;
                case ToastType.Success:
                    return hasBootstrapIconFont ? ToastBootstrapIconHtml.Success : ToastIconHtml.Success;
                case ToastType.Information:
                    return hasBootstrapIconFont ? ToastBootstrapIconHtml.Information : ToastIconHtml.Information;
                default:
                    return string.Empty;
            }
        }

        private static string PrintColor(ToastType type)
        {
            switch (type)
            {
                case ToastType.Error:
                    return ToastBackgroundClassName.Error;
                case ToastType.Warning:
                    return ToastBackgroundClassName.Warning;
                case ToastType.Success:
                    return ToastBackgroundClassName.Success;
                case ToastType.Information:
                    return ToastBackgroundClassName.Information;
                default:
                    return string.Empty;
            }
        }
    }
}
