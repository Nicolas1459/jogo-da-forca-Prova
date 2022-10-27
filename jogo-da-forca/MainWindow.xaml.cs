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


namespace jogo_da_forca
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        string palavraInformada = "";
        string acertosDaPalavra = "";
        int totalErros = 0;


        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
           foreach (char i in txtPalavra.Text.ToString())
            {
                palavraInformada += i+" ";
                acertosDaPalavra += "_ ";
               
            }

            txtPalavra.MaxLength = 1;

            btnJogar.Visibility = Visibility.Hidden;
            btnInserirLetra.Visibility = Visibility.Visible;

            txtFrase.Text = "";
            txtFrase.Text = acertosDaPalavra;
            txtPalavra.Text = "";
            

        }

        private void InserirLetra(object sender, RoutedEventArgs e)
        {
            if (txtPalavra.Text != "" && txtPalavra.Text != " ")
            {
                txtFrase.Text = "";
                bool achouLetra = false;
                string acertoTemporario = "";
                for (int i = 0; i < palavraInformada.Length; i++)
                {
                     if (txtPalavra.Text == palavraInformada[i].ToString())
                    {
                        txtFrase.Text += $"{txtPalavra.Text}";
                        acertoTemporario += txtPalavra.Text;
                        achouLetra = true;
                    }
                    else
                    {
                        txtFrase.Text += $" {acertosDaPalavra[i]} ";
                        acertoTemporario += acertosDaPalavra[i];
                    }

                }
                acertosDaPalavra = acertoTemporario;
                if (achouLetra == false)
                {
                    if (txtLetrasErradas.Text.Contains(txtPalavra.Text)) {

                        txtPalavra.Text = "";

                    }
                    else
                    {
                        txtLetrasErradas.Text += txtPalavra.Text + " . ";
                        totalErros += 1;
                        CalculaErros();
                    }
                }
                txtPalavra.Text = "";
                VerificaVitoria();
            }
        }

     
        private void ReiniciarJogo(object sender, RoutedEventArgs e)
        {
            //EstadosIniciaisJogo();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

   
        private void SairDaAplicacao(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CalculaErros()
        {
            if (totalErros == 1)
            {
                txtCabeca.Visibility = Visibility.Visible;
            }
            if (totalErros == 2)
            {
                txtCorpo.Visibility = Visibility.Visible;
            }
            if (totalErros == 3)
            {
                txtBracoEsquerdo.Visibility = Visibility.Visible;
            }
            if (totalErros == 4)
            {
                txtBracoDireito.Visibility = Visibility.Visible;
            }
            if (totalErros == 5)
            {
                txtPernaEsquerda.Visibility = Visibility.Visible;
            }
            if (totalErros == 6)
            {
                txtPernaDireita.Visibility = Visibility.Visible;
            }
            if (totalErros == 7 )
            
            
            {
                MessageBox.Show("Você perdeu!", "Game Over!", MessageBoxButton.OK, MessageBoxImage.Error);
                btnInserirLetra.Visibility = Visibility.Hidden;
                btnReiniciarJogo.Visibility = Visibility.Visible;
                txtPalavra.Focusable = false;

            }

        }

        private void VerificaVitoria()
        {
            if (acertosDaPalavra == palavraInformada)
            {
                MessageBox.Show("Você Ganhou!", "Parabéns!", MessageBoxButton.OK, MessageBoxImage.Information);
                btnInserirLetra.Visibility = Visibility.Hidden;
                btnReiniciarJogo.Visibility = Visibility.Visible;
                txtPalavra.Focusable = false;
            }
        }

        private void EstadosIniciaisJogo()
        {
            btnReiniciarJogo.Visibility = Visibility.Hidden;
            btnJogar.Visibility = Visibility.Visible;
            txtPalavra.MaxLength = 200;
            txtBracoDireito.Visibility = Visibility.Hidden;
            txtBracoEsquerdo.Visibility = Visibility.Hidden;
            txtPernaDireita.Visibility = Visibility.Hidden;
            txtPernaEsquerda.Visibility = Visibility.Hidden;
            txtCorpo.Visibility = Visibility.Hidden;
            txtCabeca.Visibility = Visibility.Hidden;

            txtLetrasErradas.Text = " ";
            txtFrase.Text =  " ";
            txtPalavra.Focusable = true;
            acertosDaPalavra = " ";
            palavraInformada = " ";
        }
    }
}
