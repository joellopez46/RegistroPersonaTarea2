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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroPersona.Entidades;
using RegistroPersona.BLL;

namespace RegistroPersona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            TBid.Text = "0";
            TBnombre.Text = string.Empty;
            TBtelefono.Text = string.Empty;
            TBcedula.Text = string.Empty;
            TBdireccion.Text = string.Empty;
            fecha_nacimiento.SelectedDate = DateTime.Now;
        }
        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.ID = Convert.ToInt32(TBid.Text);
            persona.nombre = TBnombre.Text;
            persona.telefono = TBtelefono.Text;
            persona.cedula = TBcedula.Text;
            persona.direccion = TBdireccion.Text;
            persona.fecha_nacimiento = (DateTime)fecha_nacimiento.SelectedDate;
            return persona;
        }
        private void LlenaCampo(Persona persona)
        {
            TBid.Text = Convert.ToString(persona.ID);
            TBnombre.Text = persona.nombre;
            TBtelefono.Text = persona.telefono;
            TBcedula.Text = persona.cedula;
            TBdireccion.Text = persona.direccion;
        }
        private void BTbuscar_Click_1(object sender, RoutedEventArgs e)
        {
            int id;
            Persona persona = new Persona();
            int.TryParse(TBid.Text, out id);

            Limpiar();

            persona = PersonaBLL.buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona No valida");
                LlenaClase();
            }
            else
            {
                MessageBox.Show("Persona No valida");
            }
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Persona persona = PersonaBLL.buscar(Convert.ToInt32(TBid.Text));
            return (persona != null);
        }
        private void BTNuevo_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BTguardar_Click_1(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;

            if (!validar())
                return;

            persona = LlenaClase();

            if (TBid.Text == "0")
                paso = PersonaBLL.guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("ERROR", "Opcion no valida", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonaBLL.modificar(persona);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("ERROR", "Opcion no valida", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private bool validar()
        {
            bool paso = true;
            if (TBnombre.Text == string.Empty)
            {
                MessageBox.Show("Debe colocar Direccion");
                TBnombre.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TBcedula.Text))
            {
                MessageBox.Show("Debe colocar Cedula");
                TBdireccion.Focus();
                paso = false;
            }

            if (string.IsNullOrEmpty(TBtelefono.Text))
            {
                MessageBox.Show("Debe colocar Telefono");
                TBdireccion.Focus();
                paso = false;
            }
            return paso;
        }

        private void BTeliminar_Click_1(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(TBid.Text, out id);
            Limpiar();

            if (PersonaBLL.eliminar(id))
            {
                MessageBox.Show("Eliminado correctamente", "Persona eliminada", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}