using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ivegaS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<dataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasena = txtContrasena.Text };
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            DisplayAlert("Alerta", "Estudiante agregado correctamente", "Ok");
            Navigation.PushAsync(new Login());
        }
    }
}