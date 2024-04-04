using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	/// TouchableCard.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TouchableCard : UserControl
	{
		private bool _isMousePressed = false;

		public TouchableCard()
		{
			InitializeComponent();

			this.PreviewMouseLeftButtonDown += (s, e) => {
				this._isMousePressed = true;
			};

			this.MouseMove += this.SpinningCard;
			this.PreviewMouseLeftButtonUp += this.RestoreCard;
			this.MouseLeave += this.RestoreCard;
		}

		private void RestoreCard(object sender, MouseEventArgs e)
		{
			this._isMousePressed = false;
		}

		private void SpinningCard(object sender, MouseEventArgs e)
		{
			var pos = e.GetPosition(this);

			if (sender is Control rect)
			{
				var x = rect.ActualWidth / 2;
				var y = rect.ActualHeight / 2;

				if (!this._isMousePressed) return;

				var angle = GetAngle(new Point(x, y), new Point(pos.X, pos.Y));

				var rotateTransform = new RotateTransform(angle);
				var group = new TransformGroup();
				group.Children.Add(rotateTransform);
				this.Card.LayoutTransform = rotateTransform;
			}
		}

		/// <summary>
		/// 두 점 사이의 각도 구하기
		/// </summary>
		private double GetAngle(Point v1, Point v2)
		{
			double xdf = v2.X - v1.X;
			double ydf = v2.Y - v1.Y;

			double radian = Math.Atan2(ydf, xdf);

			Debug.WriteLine($"{radian * 57.3f}");

			return radian * 57.3f; // 180.0f / 3.141592f
		}
	}
}
