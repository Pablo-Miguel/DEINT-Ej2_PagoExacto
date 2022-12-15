namespace DEINT_Ej2_PagoExacto;

public partial class MainPage : ContentPage
{

    private Int32 contPersonas;

	public MainPage()
	{
		InitializeComponent();
        this.contPersonas = 1;
	}

    private void calcularPagos() {
        try
        {
            Double totalPago = Math.Round((Double.Parse(entryTxtCuenta.Text.Replace(".", ",")) + (Double.Parse(entryTxtCuenta.Text.Replace(".", ",")) * (Double.Parse(slider.Value.ToString()) / 100))) / Int32.Parse(lblContPers.Text), 2);
            Double subtotal = Math.Round((Double.Parse(entryTxtCuenta.Text.Replace(".", ","))) / Int32.Parse(lblContPers.Text), 2);
            Double propina = Math.Round((Double.Parse(entryTxtCuenta.Text.Replace(".", ",")) * (Double.Parse(slider.Value.ToString()) / 100)) / Int32.Parse(lblContPers.Text), 2);

            lblTotalPago.Text = $"{totalPago}€";
            lblSubtotal.Text = $"{subtotal}€";
            lblPropina.Text = $"{propina}€";
        }
        catch (FormatException)
        {
            lblTotalPago.Text = "Formato incorrecto";
            lblSubtotal.Text = "0.0€";
            lblPropina.Text = "0.0€";
        }
        catch (NullReferenceException) {
            lblTotalPago.Text = "Valor de cuenta vacío";
            lblSubtotal.Text = "0.0€";
            lblPropina.Text = "0.0€";
        }
    }

    private void entryTxtCuenta_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!entryTxtCuenta.Text.Equals("")) {
            calcularPagos();
        }
    }

    private void btn10_Clicked(object sender, EventArgs e)
	{
		slider.Value = 10;
    }

	private void btn15_Clicked(object sender, EventArgs e)
	{
        slider.Value = 15;
    }

	private void btn20_Clicked(object sender, EventArgs e)
	{
        slider.Value = 20;
    }

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblPropinaSlider.Text = $"Propina: {Math.Round(Double.Parse(slider.Value.ToString()), 2)}%";
        calcularPagos();
    }

    private void btnRestar_Clicked(object sender, EventArgs e)
    {
        if (contPersonas > 1) {
            contPersonas--;
            lblContPers.Text = contPersonas.ToString();
        }
        calcularPagos();
    }

    private void btnSumar_Clicked(object sender, EventArgs e)
    {
        contPersonas++;
        lblContPers.Text = contPersonas.ToString();
        calcularPagos();
    }
}

