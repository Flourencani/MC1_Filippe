using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Data;

namespace MC1_Filippe
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

        //Obtendo a string de conexão do arquivo App.Config
        string _stringConexao = ConfigurationManager.ConnectionStrings["db_MC1"].ConnectionString;

        //public void VinculaDados()
        //{
        //    SqlCeConnection _Conn = new SqlCeConnection(_stringConexao);

        //    // Abre a conexão 
        //    _Conn.Open();

        //    SqlCeDataAdapter _Adapter = new SqlCeDataAdapter("Select * from cadastros", _Conn);

        //    DataSet _ds = new DataSet();
        //    _Adapter.Fill(_ds, "ClientesDataBinding");


        //    grdConteudo.DataContext = _ds;

        //    // Fecha a conexão
        //    _Conn.Close();
        //}


        private void textBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        //private void grdConteudo_Loaded(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        this.VinculaDados();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void grdConteudo_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    try
        //    {
        //        DataRowView _dv = grdConteudo.CurrentCell.Item as DataRowView;

        //        if (_dv != null)
        //        {
        //            txtIdCadastro.Text = string.Empty;
        //            txtNome.Text = _dv.Row[0].ToString();
        //            txtNome.IsEnabled = false;
        //            txtAnoNascimento.Text = _dv.Row[1].ToString();
        //            //lblFonte.GetValue = _dv.Row[2].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCeConnection _Conn = new SqlCeConnection(_stringConexao);

                // abre a conexao
                _Conn.Open();          

                // comando SQL para inserir - Insert Into
                string _Inserir = @"insert into cadastros
                                         (NOME,ANO_NASCIMENTO,VALOR_LABEL)
                                         Values('" + txtNome.Text + "','" + txtAnoNascimento.Text + "','" + 1 + "')";

                // inicializa o comando e a conexão
                SqlCeCommand _cmd = new SqlCeCommand(_Inserir, _Conn);
                // executa o comando
                _cmd.ExecuteNonQuery();
                MessageBox.Show("Registro incluído !");
                //txtIdCadastro.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtAnoNascimento.Text = string.Empty;
                //this.VinculaDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

//        private void btnDeletar_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                SqlCeConnection _Conn = new SqlCeConnection(_stringConexao);

//                // Open Database Connection
//                _Conn.Open();

//                // Command String
//                string _Deletar = @"Delete from cadastros
//                                  Where codigo = " + Convert.ToInt32(txtIdCadastro.Text);

//                // inicializa o comando e a conexão
//                SqlCeCommand _cmdDeletar = new SqlCeCommand(_Deletar, _Conn);
//                // executa o comando
//                _cmdDeletar.ExecuteNonQuery();

//                MessageBox.Show("Registro deletado !");
//                //txtIdCadastro.Text = string.Empty;
//                txtNome.Text = string.Empty;
//                txtAnoNascimento.Text = string.Empty;
//                //this.VinculaDados();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.ToString());
//            }
//        }

               
    }
}
