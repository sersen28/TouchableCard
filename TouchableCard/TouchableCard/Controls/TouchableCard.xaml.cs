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
using System.Windows.Media.Media3D;
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

			this.MouseMove += this.MovingCard;
			this.PreviewMouseLeftButtonUp += this.RestoreCard;
			this.MouseLeave += this.RestoreCard;
		}

		private void RestoreCard(object sender, MouseEventArgs e)
		{
			this._isMousePressed = false;
			this.Card.RenderTransform = new TransformGroup();
			this.Card.LayoutTransform = new TransformGroup();
		}

		private void SpinningCard(object sender, MouseEventArgs e)
		{
			if (!this._isMousePressed) return;

			var pos = e.GetPosition(this);
			var x = this.ActualWidth / 2;
			var y = this.ActualHeight / 2;

			var angle = GetAngle(new Point(x , y), new Point(pos.X, pos.Y));
			var rotateTransform = new RotateTransform(angle);
			this.Card.LayoutTransform = rotateTransform;
			
		}

		private void MovingCard(object sender, MouseEventArgs e)
		{
			if (!this._isMousePressed) return;

			var pos = e.GetPosition(this);
			var x = this.ActualWidth / 2;
			var y = this.ActualHeight / 2;

			var translateTransform = new TranslateTransform(pos.X - x, pos.Y - y);
			this.Card.RenderTransform = translateTransform;
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
