using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
namespace WordsMarker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //request string: XML: https://www.dictionaryapi.com/api/v1/references/collegiate/xml/hypocrite?key=[YOUR KEY GOES HERE]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //spell check goes here

            String[] RequestURL = new string[]{"https://www.dictionaryapi.com/api/v1/references/collegiate/xml/","?key=2d90f541-ddc2-449d-b028-df8fb2334e58"};
            string url = RequestURL[0] + GUI_key.Text + RequestURL[1];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            String results;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                results= reader.ReadToEnd();
            }
            MessageBox.Show(results);
        }
    }
}
