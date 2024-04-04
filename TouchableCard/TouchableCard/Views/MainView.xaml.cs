using System.Windows;
using TouchableCard.ViewModels;

namespace TouchableCard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
			this.DataContext = new MainViewModel();
		}
	}
}
