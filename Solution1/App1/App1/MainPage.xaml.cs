using App1.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        private List<Acao> acaoes;
        private JsonSerializer _serializer = new JsonSerializer();
        private String url = "http://localhost:2947/api/acao";

        public MainPage()
        {
            InitializeComponent();

            InicializeList();
        }

        private async void InicializeList()
        {
            acaoes = await Get();
            lstItens.ItemsSource = acaoes;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                Acao acao = new Acao();
                acao.StockFund = StockFund.Text;
                acao.Amount = Amount.Text;
                acao.Price = Price.Text;
                string json = JsonConvert.SerializeObject(acao);
                
             
               
                
                var result = await client.PostAsync(url, new StringContent(json));


                if (result.IsSuccessStatusCode)
                {
                   
                    StockFund.Text = "";
                    Amount.Text = "";
                    Price.Text = "";
                    await DisplayAlert("Success!", "Fund added with success", "OK");

                }
                else
                {
                    await DisplayAlert("Error! ;(", "Something went work, try again later!", "OK");
                }
            }
            

            
        }
        private async Task<List<Acao>> Get()
        {
            using (var client = new HttpClient())
            {
               
                var result = await client.GetStringAsync(url);

                return JsonConvert.DeserializeObject<List<Acao>>(result);
            }
        }
    }
}
