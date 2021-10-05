using P1_AP1_Felix_20180570.BLL;
using P1_AP1_Felix_20180570.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P1_AP1_Felix_20180570.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rAportes.xaml
    /// </summary>
    public partial class rAportes : Window
    {
        private Aportes aporte = new Aportes();
        public rAportes()
        {
            InitializeComponent();
            this.DataContext = aporte;

        }

        private bool Validar()
        {
            bool esValido = true;


            if (PersonaTextBox.Text.Length == 0 || AporteIDTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida, El campo Aporte ID o Persona no puede estar vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;

        }
        private void Limpiar()
        {
            this.aporte = new Aportes();
            this.DataContext = aporte;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aportes = AportesBLL.Buscar(Utilidades.ToInt(AporteIDTextBox.Text));

            if (!AportesBLL.ExisteID(Utilidades.ToInt(AporteIDTextBox.Text)))
            {
                MessageBox.Show("No existe un registro con ese ID, Ingrese uno diferente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (aporte != null)
            {
                this.aporte = aportes;
                GuardarButton.IsEnabled = false;

            }
            else
            {

                this.aporte = new Aportes();
            }

            this.DataContext = this.aporte;

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            if (GuardarButton.IsEnabled == false)
            {
                GuardarButton.IsEnabled = true;
            }
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            if (AportesBLL.ExisteID(Utilidades.ToInt(AporteIDTextBox.Text)))
            {
                MessageBox.Show("Ya existe un registro con ese ID, Ingrese uno diferente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var paso = AportesBLL.Guardar(aporte);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AportesBLL.Eliminar(Utilidades.ToInt(AporteIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro Eliminado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = AportesBLL.Modificar(aporte);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
