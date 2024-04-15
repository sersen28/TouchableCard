using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TouchableCard.Controls
{
	/// <summary>
	/// SelectButton.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class SelectButton : RadioButton
	{
		public SelectButton()
		{
			InitializeComponent();
		}

		public static readonly DependencyProperty NormalSourceProperty
			= DependencyProperty.Register("NormalSource", typeof(ImageSource)
				, typeof(SelectButton));

		public ImageSource NormalSource
		{
			get => (ImageSource)GetValue(NormalSourceProperty);
			set => SetValue(NormalSourceProperty, value);
		}

		public static readonly DependencyProperty CheckedSourceProperty
			= DependencyProperty.Register("CheckedSource", typeof(ImageSource)
				, typeof(SelectButton));

		public ImageSource CheckedSource
		{
			get => (ImageSource)GetValue(CheckedSourceProperty);
			set => SetValue(CheckedSourceProperty, value);
		}
	}
}
