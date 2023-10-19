using System.Globalization;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double principal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {  
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            double taxaDeJurosAnual = double.Parse(txtTaxaJuros.Text);

            int numeroDeParcelas = int.Parse(txtMeses.Text);

            double taxaDeJurosMensal = (taxaDeJurosAnual/100)/ 12;

            double valorDaParcela = principal * (taxaDeJurosMensal / (1 - Math.Pow(1 + taxaDeJurosMensal, -numeroDeParcelas)));
            lblResultado.Text = $"Valor da parcela:R${valorDaParcela.ToString("N2")}";
            lblResultado.Text+=$"\nTotal de Juros:{(valorDaParcela* numeroDeParcelas).ToString("N2")}";

        }

        private void txtValorPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Impede a entrada do caractere
            }
        }

        private void txtValorPrincipal_Leave(object sender, EventArgs e)
        {
            if (!txtValorPrincipal.Text.Equals("")){ 
            principal = double.Parse(txtValorPrincipal.Text);
            txtValorPrincipal.Text = "R$" + principal.ToString("N2");
            
            }
        }

        private void txtValorPrincipal_Enter(object sender, EventArgs e)
        {
            txtValorPrincipal.Clear();
        }
    }
}