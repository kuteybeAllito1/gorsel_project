namespace Vize_odevi1;

public partial class VucutHesaplama : ContentPage
{
	public VucutHesaplama()
	{
		InitializeComponent();
	}
    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(EntryHeight.Text, out double height) && double.TryParse(EntryWeight.Text, out double weight))
        {
            double heightInMeters = height / 100;
            double bmi = weight / (heightInMeters * heightInMeters);
            string bmiStatus = GetBmiStatus(bmi);
            LabelResult.Text = $"Vücut Kitle indeksi: {bmi:F2} ({bmiStatus})";
        }
        else
        {
            LabelResult.Text = "Lütfen geçerli boy ve kilo degerleri girin.";
        }
    }

    private string GetBmiStatus(double bmi)
    {
        if (bmi < 16)
            return " ileri duzeyde zaif";
        else if (bmi >= 16 && bmi < 16.9)
            return " hafif duzeyde zaif";
        else if (bmi >= 17 && bmi < 18.4)
            return " Hafif duzeyde Zayif";
        else if (bmi >= 18.5 && bmi < 24.9)
            return " Normal kilolu";
        else if (bmi >= 25 && bmi < 29.9)
            return " Fazla sisman";
        else if (bmi >= 30 && bmi < 34.9)
            return " 1.derece Obez ";
        else if (bmi >= 35 && bmi < 39.9)
            return " 2.derece Obez ";
        else
            return "3.derece Obez";
    }
}