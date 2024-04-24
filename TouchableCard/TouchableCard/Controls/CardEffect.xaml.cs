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
		public CardEffect()
        {
            InitializeComponent();

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

		public static readonly DependencyProperty EffectTypeProperty
			= DependencyProperty.Register("EffectType", typeof(EffectType)
				, typeof(CardEffect));

		public EffectType EffectType
		{
			get => (EffectType)GetValue(EffectTypeProperty);
			set => SetValue(EffectTypeProperty, value);
		}
	}
}
