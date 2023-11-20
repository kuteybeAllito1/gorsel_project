namespace Vize_odevi1;

public partial class KrediHesaplama : ContentPage
{
	public KrediHesaplama()
	{
		InitializeComponent();
	}
    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender == Slider1)
        {
            EntryKredi.Text = $"{Slider1.Value:F0}";
        }
        else if (sender == Slider2)
        {
            EntryFaiz.Text = $"{Slider2.Value:F2}";
        }
        else if (sender == Slider3)
        {
            EntryKrediSuresi.Text = $"{Slider3.Value:F0}";
        }
    }

    private void OnEntryCompleted(object sender, EventArgs e)
    {
        if (sender == EntryKredi && double.TryParse(EntryKredi.Text, out double loanAmount))
        {
            Slider1.Value = loanAmount;
        }
        else if (sender == EntryFaiz && double.TryParse(EntryFaiz.Text, out double interestRate))
        {
            Slider2.Value = interestRate;
        }
        else if (sender == EntryKrediSuresi && int.TryParse(EntryKrediSuresi.Text, out int loanTerm))
        {
            Slider3.Value = loanTerm;
        }
    }

    private void OnCalculateButtonClicked(object sender, EventArgs e)
    {
        if (double.TryParse(EntryKredi.Text, out double loanAmount) &&
            double.TryParse(EntryFaiz.Text, out double interestRate) &&
            int.TryParse(EntryKrediSuresi.Text, out int loanTerm))
        {
            double monthlyInterestRate = interestRate / 100 / 12;
            double months = loanTerm;

            double monthlyPayment = loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, months) /
                                     (Math.Pow(1 + monthlyInterestRate, months) - 1);

            LabelResult.Text = $"Aylik ödeme: {monthlyPayment:F2}";
        }
        else
        {
            LabelResult.Text = "Lütfen geçerli değerler girin!!!";
        }
    }

    private void PickerLoanType_ChildAdded(object sender, ElementEventArgs e)
    {

    }
}