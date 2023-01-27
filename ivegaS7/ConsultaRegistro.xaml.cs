using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ivegaS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Estudiante> _TablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<dataBase>().GetConnection();
            //NavigationPage.SetHasBackButton(this, false);
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(ID));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async override void OnAppearing()
        {
            var ResulRegistros = await _conn.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(ResulRegistros);
            ListaUsuarios.ItemsSource = _TablaEstudiante;
            base.OnAppearing();
        }
    }
}