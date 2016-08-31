using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WWSlider_v1._1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Slider webViewSlider;
        string[][] urls = new string[][]
            {
                new string[] { "google.com", "http://yandex.ru" },
                new string[] { "http://news.google.com", "http://news.yandex.ru" },
                new string[] { "http://gmail.com", "http://mail.yandex.ru" }
            };

        public MainPage()
        {
            this.InitializeComponent();
            try
            {
                webViewSlider = new Slider(sliderWrap, urls);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }
    }
}
