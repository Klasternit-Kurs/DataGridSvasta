using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
	/// 

	public class PromenaCeneArgs
	{
		public decimal cena;

		public PromenaCeneArgs(decimal c) => cena = c;
		
	}
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> lstArt = new ObservableCollection<Artikal>();
		public decimal UnosCena { get; set; }

		public delegate void PromenaCeneHandler(object posiljaoc, PromenaCeneArgs a);
		public event PromenaCeneHandler OnPromenaCene;

		public List<Artikal> lArt = new List<Artikal>();

		public MainWindow()
		{
			InitializeComponent();

			DataContext = this;

			lstArt.Add(new Artikal("Nesto", 20));
			lstArt.Add(new Artikal("Nesto drugo", 30));
			lstArt.Add(new Artikal("Nesto trece", 70));
			lstArt.Add(new Artikal("Plazam", 200));
			lstArt.Add(new Artikal("Jos nesto", 770));
			lstArt.Add(new Artikal("Bla", 40));
			lstArt.Add(new Artikal("Bla bla", 890));

			dg.ItemsSource = lstArt;
		}

		private void Obrisi(object sender, RoutedEventArgs e)
		{
			//ToggleButton tb = sender as ToggleButton;
			//Artikal a = tb.DataContext as Artikal;

			//Artikal a = (sender as ToggleButton).DataContext as Artikal;

			lstArt.Remove((sender as Button).DataContext as Artikal);
		}

		private void Promeni(object sender, RoutedEventArgs e)
		{
			OnPromenaCene?.Invoke(this, new PromenaCeneArgs(UnosCena));

			//foreach (Artikal a in lArt)
			//{
			//	a.Cena = UnosCena;
			//}

			//lArt.ForEach(a => a.Cena = UnosCena);

		}

		private void Cekiran(object sender, RoutedEventArgs e)
		{
			OnPromenaCene += ((sender as ToggleButton).DataContext as Artikal).Promena;
			//lArt.Add(((sender as ToggleButton).DataContext as Artikal));
		}

		private void Odcekiran(object sender, RoutedEventArgs e)
		{
			OnPromenaCene -= ((sender as ToggleButton).DataContext as Artikal).Promena;
			//lArt.Remove(((sender as ToggleButton).DataContext as Artikal));
		}

		/*private void Kliknut(object sender, RoutedEventArgs e)
		{
			ToggleButton tb = sender as ToggleButton;

			if (tb.IsChecked == true)
			{
				OnPromenaCene += ((sender as ToggleButton).DataContext as Artikal).Promena;
			}
			else 
			{
				OnPromenaCene -= ((sender as ToggleButton).DataContext as Artikal).Promena;
			}
		}*/
	}

	public class Artikal : INotifyPropertyChanged
	{
		public string Naziv { get; set; }

		private decimal cena;
		public decimal Cena 
		{
			get => cena; 
			set
			{
				cena = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cena"));
			}
		}
		
		public bool Selektovano { get; set; }

		public Artikal(string n, decimal c)
		{
			Naziv = n;
			Cena = c;
		}

		public Artikal() { }

		public event PropertyChangedEventHandler PropertyChanged;

		public void Promena(object p, PromenaCeneArgs a)
		{
			Cena = a.cena;
		}

	}
}
