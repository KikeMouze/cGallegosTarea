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

namespace cGallegosTarea
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://10.1.0.190:3000/api/v1/products/";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Productos> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();

        }
        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Productos> listaPost = JsonConvert.DeserializeObject<List<Productos>>(contenido);
            post = new ObservableCollection<Productos>(listaPost);
            listaProductos.ItemsSource = post;
        }
        private async void btnMonstrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Productos> listaPost = JsonConvert.DeserializeObject<List<Productos>>(contenido);
            post = new ObservableCollection<Productos>(listaPost);
            listaProductos.ItemsSource = post;
        }
    }
}
