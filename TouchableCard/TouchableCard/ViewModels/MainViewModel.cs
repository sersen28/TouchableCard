using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchableCard.Contants;
using TouchableCard.MVVM;

namespace TouchableCard.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		public const string Title = "Touchable Card";

		#region
		public ReactionType CardReactionType
		{
			get => _cardReactionType;
			set
			{
				if (_cardReactionType != value)
				{
					_cardReactionType = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CardReactionType)));
				}
			}
		}
		private ReactionType _cardReactionType = ReactionType.Sloping;

		public EffectType CardEffectType
		{
			get => _CardEffectType;
			set
			{
				if (_CardEffectType != value)
				{
					_CardEffectType = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CardEffectType)));
				}
			}
		}
		private EffectType _CardEffectType = EffectType.None;
		#endregion

		public DelegateCommand<string> EffectCommand { get; set; }
		public DelegateCommand<string> ReactionCommand { get; set; }

		private static Dictionary<string, ReactionType> _reatcionTypeDict = new();
		private static Dictionary<string, EffectType> _effectTypeDict = new();

		static MainViewModel()
		{
			_reatcionTypeDict.Add("Sloping", ReactionType.Sloping);
			_reatcionTypeDict.Add("Moving", ReactionType.Moving);
			_reatcionTypeDict.Add("Spinning", ReactionType.Spinning);

			_effectTypeDict.Add("None", EffectType.None);
			_effectTypeDict.Add("Shining", EffectType.Shining);
			_effectTypeDict.Add("Prism", EffectType.Prism);
		}

		public MainViewModel()
		{
			this.EffectCommand = new(param => {
				if (_effectTypeDict.ContainsKey(param))
				{
					this.CardEffectType = _effectTypeDict[param];
				}
			});

			this.ReactionCommand = new(param => {
				if (_reatcionTypeDict.ContainsKey(param))
				{
					this.CardReactionType = _reatcionTypeDict[param];
				}
			});
		}
	}
}
