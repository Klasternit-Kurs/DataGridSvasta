using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridSvasta
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> lstArt = new ObservableCollection<Artikal>();

		public MainWindow()
		{
			InitializeComponent();

			lstArt.Add(new Artikal("Nesto", 20));
			lstArt.Add(new Artikal("Nesto drugo", 30));
			lstArt.Add(new Artikal("Nesto trece", 70));

			dg.ItemsSource = lstArt;
		}

		private void Cekirano(object sender, RoutedEventArgs e)
		{
			//ToggleButton tb = sender as ToggleButton;
			//Artikal a = tb.DataContext as Artikal;

			//Artikal a = (sender as ToggleButton).DataContext as Artikal;

			lstArt.Remove((sender as ToggleButton).DataContext as Artikal);
		}
	}

	public class Artikal
	{
		public string Naziv { get; set; }
		public decimal Cena { get; set; }
		public bool Selektovano { get; set; }

		public Artikal(string n, decimal c)
		{
			Naziv = n;
			Cena = c;
		}

		public Artikal() { }

	}
}
