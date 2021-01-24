﻿using System;

namespace AlirezaRezaee.BootstrapToastTagHelper
{
    public class Toast
    {
        public ToastType? Type { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime? Time { get; set; }

        public bool? Animation { get; set; }

        public bool? Autohide { get; set; }

        public int? Delay { get; set; }
    }
}
