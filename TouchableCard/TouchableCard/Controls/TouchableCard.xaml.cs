﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using TouchableCard.Contants;

namespace TouchableCard.Controls
{
	/// <summary>
	/// TouchableCard.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class TouchableCard : UserControl
	{
		private const double MaxAngle = 25;

		private bool _isMousePressed = false;
		private Dictionary<ReactionType, Action<object, MouseEventArgs>> _cardReactionDict = new();
		
		public TouchableCard()
		{
			InitializeComponent();
			this._cardReactionDict.Add(ReactionType.Moving, MovingCard);
			this._cardReactionDict.Add(ReactionType.Spinning, SpinningCard);
			this._cardReactionDict.Add(ReactionType.Skew, SkewCard);

			this.PreviewMouseLeftButtonDown += (s, e) => {
				this._isMousePressed = true;
			};

			this.MouseMove += (s, e) => {
				this._cardReactionDict[this.ReactionType].Invoke(s, e);
			 };

			this.PreviewMouseLeftButtonUp += this.RestoreCard;
			this.MouseLeave += this.RestoreCard;
		}

		private void RestoreCard(object sender, MouseEventArgs e)
		{
			this._isMousePressed = false;
			this.Card.RenderTransform = new TransformGroup();
			this.Card.LayoutTransform = new TransformGroup();
		}

		private void SkewCard(object sender, MouseEventArgs e)
		{
			if (!this._isMousePressed) return;

			var pos = e.GetPosition(this);
			var x = pos.X - this.ActualWidth / 2;
			var y = pos.Y - this.ActualHeight / 2;

			SkewTransform skew = new SkewTransform(
				GetAngle(this.ActualWidth, pos.X),
				-GetAngle(this.ActualHeight, pos.Y),
				x, y);
			this.Card.LayoutTransform = skew;
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
		/// 컨트롤 내 마우스 위치에 비례하여 각도 구하기
		/// </summary>
		private double GetAngle(double size, double pos)
		{
			var unit = size / (MaxAngle * 2);
			var angle = pos / unit - MaxAngle;

			if (Math.Abs(angle) < 1) return 0;
			return angle;
		}

		/// <summary>
		/// 두 점 사이의 각도 구하기
		/// </summary>
		private double GetAngle(Point v1, Point v2)
		{
			double xdf = v2.X - v1.X;
			double ydf = v2.Y - v1.Y;

			double radian = Math.Atan2(ydf, xdf);

			return radian * 57.3f + 90; // 180.0f / 3.141592f
		}

		public static readonly DependencyProperty ReactionTypeProperty
			= DependencyProperty.Register("ReactionType", typeof(ReactionType)
				, typeof(TouchableCard));

		public ReactionType ReactionType
		{
			get => (ReactionType)GetValue(ReactionTypeProperty);
			set => SetValue(ReactionTypeProperty, value);
		}

		public static readonly DependencyProperty EffectTypeProperty
			= DependencyProperty.Register("EffectType", typeof(EffectType)
				, typeof(TouchableCard));

		public EffectType EffectType
		{
			get => (EffectType)GetValue(EffectTypeProperty);
			set => SetValue(EffectTypeProperty, value);
		}
	}
}
