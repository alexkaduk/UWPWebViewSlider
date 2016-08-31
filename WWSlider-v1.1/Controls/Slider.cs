using System;
using Windows.UI.Xaml.Controls;

namespace WWSlider_v1._1
{
    public class Slider
    {
        private Grid sliderWrap;
        private string[][] urls;

        public Slider(Grid sliderWrap, string[][] urls)
        {
            this.sliderWrap = sliderWrap;
            this.urls = urls;
            CreateSlider();
        }

        private FlipView flipViewWrap;

        private void CreateSlider()
        {
            flipViewWrap = new FlipView();

            WebView[][] webViews = new WebView[urls.Length][];

            FlipView[] flipViews = new FlipView[urls.Length];

            for (int i = 0; i < urls.Length; i++)
            {
                flipViews[i] = new FlipView();
                webViews[i] = new WebView[urls[i].Length];

                for (int j = 0; j < urls[i].Length; j++)
                {
                    webViews[i][j] = new WebView();

                    try
                    {
                        if (String.IsNullOrEmpty(urls[i][j])) throw new Exception();
                        if (urls[i][j].Equals("about:blank")) throw new Exception();
                        if (!urls[i][j].StartsWith("http://") && !urls[i][j].StartsWith("https://"))
                        {
                            urls[i][j] = "http://" + urls[i][j];
                        }

                        Uri targetUri;

                        if (Uri.TryCreate(urls[i][j], UriKind.Absolute, out targetUri)) // && (targetUri.Scheme == Uri.UriSchemeHttp))
                        {
                            webViews[i][j].Navigate(targetUri);
                        }
                        else
                        {
                            throw new Exception();
                        }                        
                    }
                    catch (Exception ex)
                    {
                        webViews[i][j].NavigateToString("<html><body><h2>Can't download " + urls[i][j] + "</h2></body></html>");
                        System.Diagnostics.Debug.Write(ex.ToString());
                    }
                    
                }

                var itemsPanelTemplate = new ItemsPanelTemplate();
                itemsPanelTemplate.SetValue(VirtualizingStackPanel.OrientationProperty, Orientation.Vertical);
                flipViews[i].ItemsPanel = itemsPanelTemplate;
                flipViews[i].ItemsSource = webViews[i];
            }

            flipViewWrap.ItemsSource = flipViews;

            sliderWrap.Children.Add(flipViewWrap);
        }
    }
}
