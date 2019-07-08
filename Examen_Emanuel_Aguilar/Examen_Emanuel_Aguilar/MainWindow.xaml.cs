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
//AGREGANDO LIBRERIAS
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Examen_Emanuel_Aguilar
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlconnection;


        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["Examen_Emanuel_Aguilar.Properties.Settings.ERPDataSet2"].ConnectionString;
            sqlconnection = new SqlConnection(connectionString);

            MostrarUsuarios();
            MostrarEstado();
            TipoUsuario();
        }

        private void MostrarUsuarios()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Usuario.Usuario";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {
                    
                    DataTable tablaUsuario = new DataTable();

                    
                    sqlDataAdapter.Fill(tablaUsuario);
                    
                    lbListadoUsuarios.DisplayMemberPath = "Nombre,Apellido,Correo_Electronico";         
                    lbListadoUsuarios.SelectedValuePath = "Id";                    
                    lbListadoUsuarios.ItemsSource = tablaUsuario.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        

        private void MostrarEstado()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Usuario.Usuario";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tablaUsuario = new DataTable();


                    sqlDataAdapter.Fill(tablaUsuario);

                    lbEstado.DisplayMemberPath = "Nom_Usuario,Estado";
                    lbEstado.SelectedValuePath = "Id";
                    lbEstado.ItemsSource = tablaUsuario.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void TipoUsuario()
        {
            try
            {
                // El query ha realizar en la BD
                string query = "SELECT * FROM Usuario.Usuario";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlconnection);

                using (sqlDataAdapter)
                {

                    DataTable tablaUsuario = new DataTable();


                    sqlDataAdapter.Fill(tablaUsuario);

                    lbTipoUsuario.DisplayMemberPath = "Tipo_Usuario";
                    lbTipoUsuario.SelectedValuePath = "Id";
                    lbTipoUsuario.ItemsSource = tablaUsuario.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void BtnEliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (lbListadoUsuarios.SelectedValue == null)
                MessageBox.Show("Debes seleccionar un Usuario");
            else
            {
                try
                {
                    string query = "DELETE FROM Usuario.Usuario WHERE Id = @UsuId";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    
                    sqlconnection.Open();

                    
                    sqlCommand.Parameters.AddWithValue("@UsuId", lbListadoUsuarios.SelectedValue);

                    
                    sqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    MostrarUsuarios();
                }
            }
        }
        private void BtnAgregarUsuario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "INSERT INTO Usuario.Usuario(Nombre) VALUES(@Nombre)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

     
                sqlconnection.Open();

     
                sqlCommand.Parameters.AddWithValue("@Nombre", txtInformacion.Text);

                
                
                sqlCommand.ExecuteNonQuery();

                
                txtInformacion.Text = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlconnection.Close();
                
                MostrarUsuarios();
            }

        }
        
        private void BtnActualizarTipoUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (txtInformacion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el tipo de usuario en la caja de texto.");
                txtInformacion.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Usuario.Usuario SET Nombre = @nombre WHERE id = @idusu";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", txtInformacion.Text);
                    sqlCommand.Parameters.AddWithValue("@idusu", lbTipoUsuario.SelectedValue);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    TipoUsuario();
                }
            }
        }


        
        private void BtnActualizarEstado_Click(object sender, RoutedEventArgs e)
        {
            if (txtInformacion.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar el estado en la caja de texto.");
                txtInformacion.Focus();
            }
            else
            {
                try
                {
                    string query = "UPDATE Usuario.Usuario SET Nombre = @nombre WHERE id = @idusu";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                    sqlconnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", txtInformacion.Text);
                    sqlCommand.Parameters.AddWithValue("@idusu", lbEstado.SelectedValue);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlconnection.Close();
                    TipoUsuario();
                }
            }
        }

    }
}
