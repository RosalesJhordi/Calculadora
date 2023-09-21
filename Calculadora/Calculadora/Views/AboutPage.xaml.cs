using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora.Views
{
	public partial class AboutPage : ContentPage
	{
		double currentValue = 0;
		string currentOperator = "";
		bool isNewEntry = true;

		public AboutPage()
		{
			InitializeComponent();
		}
		void Btn_numeros(object sender, EventArgs e)
		{
			if (isNewEntry)
			{
				Resultado.Text = "";
				isNewEntry = false;
			}

			Button button = (Button)sender;
			Resultado.Text += button.Text;
		}
		private void Btn_borrar(object sender, EventArgs e)
		{
			currentValue = 0;
			currentOperator = "";
			Resultado.Text = "0";
			isNewEntry = true;
		}
		private void Btn_borrarTodo(object sender, EventArgs e)
		{
			Resultado.Text = string.Empty;
		}
		private void Op(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			currentOperator = button.Text;
			currentValue = double.Parse(Resultado.Text);

			Resultado.Text += button.Text;
			isNewEntry = true;
		}
		private void Op_igual(object sender, EventArgs e)
		{
			double newValue = double.Parse(Resultado.Text);
			switch (currentOperator)
			{
				case "+":
					currentValue += newValue;
					break;
				case "-":
					currentValue -= newValue;
					break;
				case "x":
					currentValue *= newValue;
					break;
				case "÷":
					if (newValue != 0)
					{
						currentValue /= newValue;
					}
					else
					{
						Resultado.Text = "Syntax Error";
						isNewEntry = true;
						return;
					}
					break;
			}

			Resultado.Text = currentValue.ToString();
			isNewEntry = true;
		}

		private void Decimal(object sender, EventArgs e)
		{
			if (!Resultado.Text.Contains("."))
				Resultado.Text += ".";
		}
	}
}