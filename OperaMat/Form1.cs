namespace OperaMat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CmbOperaciones.Items.Add("Suma");
            this.CmbOperaciones.Items.Add("Resta");
            this.CmbOperaciones.Items.Add("Division");
            this.CmbOperaciones.Items.Add("Multiplicacion");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double resultado = 0;
            string operaciones = string.Empty;
                operaciones = CmbOperaciones.SelectedItem?.ToString() ?? "Valor predeterminado";
            if (operaciones == null)
            {
                MessageBox.Show("La selección en la ComboBox no puede estar vacía. Se asignará un valor predeterminado.");
                if (CmbOperaciones.Items.Count > 0)
                {
                    CmbOperaciones.SelectedIndex = 0;
                }
                else
                {
                    CmbOperaciones.Items.Add("Valor predeterminado");
                    CmbOperaciones.SelectedIndex = 0;
                }
            }
                
            
            switch (operaciones){
                case "Suma":
                    validacionNum();
                    resultado = double.Parse(this.txtNum1.Text) + double.Parse(this.txtNum2.Text);
                    break;
                case "Resta":
                    validacionNum();
                    resultado = double.Parse(this.txtNum1.Text) - double.Parse(this.txtNum2.Text);
                    break;
                case "Division":
                    validacionNum();
                    resultado = double.Parse(this.txtNum1.Text) / double.Parse(this.txtNum2.Text);
                    break;
                case "Multiplicacion":
                    validacionNum();
                    resultado = double.Parse(this.txtNum1.Text) * double.Parse(this.txtNum2.Text);
                    break;
                default:
                    resultado = 0;
                    this.txtResultado.Text = resultado.ToString();
                    break;
            }
            this.txtResultado.Text = resultado.ToString();
        }
        public void validacionNum()
        {
            if (string.IsNullOrWhiteSpace(txtNum1.Text))
            {
                MessageBox.Show("El primer campo de texto está vacío. Se establecerá en 0.");
                txtNum1.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtNum2.Text))
            {
                MessageBox.Show("El segundo campo de texto está vacío. Se establecerá en 0.");
                txtNum2.Text = "0";
            }
            if (!int.TryParse(txtNum1.Text, out _) || !double.TryParse(txtNum1.Text, out _))
            {
                txtNum1.Text = "0";
            }

            if (!int.TryParse(txtNum2.Text, out _) || !double.TryParse(txtNum1.Text, out _))
            {
                txtNum2.Text = "0";
            }
        }
    }
}
