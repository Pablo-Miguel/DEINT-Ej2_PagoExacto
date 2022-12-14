namespace DEINT_Ej2_PagoExacto;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void entryTxtCuenta_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            lblTotalPago.Text = ((Double.Parse(entryTxtCuenta.Text) + (Double.Parse(entryTxtCuenta.Text) * (Int32.Parse(slider.Value.ToString()) / 100))) / Int32.Parse(lblContPers.Text)) + "€";
            lblSubtotal.Text = ((Double.Parse(entryTxtCuenta.Text)) / Int32.Parse(lblContPers.Text)) + "€";
            lblPropina.Text = ((Double.Parse(entryTxtCuenta.Text) * (Int32.Parse(slider.Value.ToString()) / 100)) / Int32.Parse(lblContPers.Text)) + "€";
        }
        catch (FormatException) {
            lblTotalPago.Text = "0.0€";
            lblSubtotal.Text = "0.0€";
            lblPropina.Text = "0.0€";
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
}

