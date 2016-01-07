﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EasyPocket.UWP.UI
{
    public class WebViewHtmlExtension
    {
        public static string GetHTML(DependencyObject obj)
        {
            return (string)obj.GetValue(HTMLProperty);
        }

        public static void SetHTML(DependencyObject obj, string value)
        {
            obj.SetValue(HTMLProperty, value);
        }

        // Using a DependencyProperty as the backing store for HTML.  This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty HTMLProperty = DependencyProperty.RegisterAttached("HTML", typeof(string), typeof(WebViewHtmlExtension), new PropertyMetadata("", new PropertyChangedCallback(OnHTMLChanged)));

        private static void OnHTMLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebView wv = d as WebView;
            if (wv != null)
            {
//                < style >
//    * {
//                    max - width: 100 %;
//                    overflow: auto;
//                }
//                img {
//                    display: block;
//                    max - width: 100 %;
//                    height: auto;
//                }
//</ style >
                string content = @"<!DOCTYPE html>
<html>
<head>
<link rel=""stylesheet"" href=""ms-appx-web:///css/ui-dark.min.css"" />
<style>
    html {
        overflow: initial;
    }
</style>
</head>
<body>
" + (string)e.NewValue + @"

</body>
</html>
";
                wv.NavigateToString(content);
            }
        }

    }
}
