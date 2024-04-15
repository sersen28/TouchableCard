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
using TouchableCard.Contants;

namespace TouchableCard.Controls
{
    /// <summary>
    /// ShiningEffect.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CardEffect : UserControl
	{
		private bool _isMousePressed = false;

		public CardEffect()
        {
            InitializeComponent();

			this.PreviewMouseLeftButtonDown += (s, e) => {
				this._isMousePressed = true;
			};

			this.PreviewMouseLeftButtonUp += this.RestoreEffect;

			this.MouseMove += (s, e) =>
			{
				var pos = e.GetPosition(this);
				var xCenter = this.ActualWidth / 2;

				double x = pos.X - xCenter;
				 x /= 10;

				var tranform = new TranslateTransform();
				tranform.X = x;
				this.effectBorder.RenderTransform = tranform;
			};
		}

		private void RestoreEffect(object sender, MouseEventArgs e)
		{
			this._isMousePressed = false;
		}

		public static readonly DependencyProperty EffectTypeProperty
			= DependencyProperty.Register("EffectType", typeof(EffectType)
				, typeof(CardEffect));

		public EffectType EffectType
		{
			get => (EffectType)GetValue(EffectTypeProperty);
			set => SetValue(EffectTypeProperty, value);
		}

		public static readonly DependencyProperty CardLinearGradientBrushProperty
			= DependencyProperty.Register("CardLinearGradientBrush", typeof(LinearGradientBrush)
				, typeof(CardEffect));

		public LinearGradientBrush CardLinearGradientBrush
		{
			get => (LinearGradientBrush)GetValue(CardLinearGradientBrushProperty);
			set => SetValue(CardLinearGradientBrushProperty, value);
		}

		public static readonly DependencyProperty CardRadialGradientBrushProperty
			= DependencyProperty.Register("CardRadialGradientBrush", typeof(RadialGradientBrush)
				, typeof(CardEffect));

		public RadialGradientBrush CardRadialGradientBrush
		{
			get => (RadialGradientBrush)GetValue(CardRadialGradientBrushProperty);
			set => SetValue(CardRadialGradientBrushProperty, value);
		}
	}
}
