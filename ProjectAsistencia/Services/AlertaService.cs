using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ProjectAsistencia.Services
{
    public class AlertaService
    {
        public async Task alerta(string titulo, string mensaje)
        {
            await App.Current.MainPage.DisplayAlert(titulo, mensaje, "OK");
        }

        public async Task<bool> confirmacion(string titulo, string mensaje)
        {
            bool exito = await App.Current.MainPage.DisplayAlert(titulo, mensaje, "Si", "No");
            return exito;
        }
    }
}