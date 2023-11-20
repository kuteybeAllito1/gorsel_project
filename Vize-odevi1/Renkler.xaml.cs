namespace Vize_odevi1;

public partial class Renkler : ContentPage
{
    private Color _currentColor;
    public Renkler()
	{
		InitializeComponent();
	}
    private void setBGcolor()
    {
        lbl.BackgroundColor = Color.FromRgb((int)slR.Value, (int)slG.Value, (int)slB.Value);
    }


    private void slR_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblR.Text = e.NewValue.ToString("0");
        setBGcolor();
    }

    private void slG_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblG.Text = e.NewValue.ToString("0");
        setBGcolor();
    }

    private void slB_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblB.Text = e.NewValue.ToString("0");
        setBGcolor();
    }

    private async void OnCopyButtonClicked(object sender, EventArgs e)
    {
        int red = (int)slR.Value;
        int green = (int)slG.Value;
        int blue = (int)slB.Value;

        string colorCode = $"#{red:X2}{green:X2}{blue:X2}";
        await Clipboard.SetTextAsync(colorCode);

        await DisplayAlert("Kopyalandi", "Renk kodu panoya kopyalandi.", "OK");
    }
    private void OnRandomColorButtonClicked(object sender, EventArgs e)
    {
        var random = new Random();
        int red = random.Next(0, 256);
        int green = random.Next(0, 256);
        int blue = random.Next(0, 256);

        slR.Value = red;
        slG.Value = green;
        slB.Value = blue;
    }
}