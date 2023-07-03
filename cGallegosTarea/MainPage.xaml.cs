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
        private string Url = "http://10.1.0.32/promocion/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Promocion> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();

        }
        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Promocion> listaPost = JsonConvert.DeserializeObject<List<Promocion>>(contenido);
            post = new ObservableCollection<Promocion>(listaPost);
            listaEstudiantes.ItemsSource = post;
        }
        private async void btnMonstrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Promocion> listaPost = JsonConvert.DeserializeObject<List<Promocion>>(contenido);
            post = new ObservableCollection<Promocion>(listaPost);
            listaEstudiantes.ItemsSource = post;
        }
    }
}
