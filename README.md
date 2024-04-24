TouchableCard


1. 프로젝트 개요
-	단순히 화면 내에 보이는 포켓몬 카드 이미지를 움직일 수 있는 프로젝트입니다.
-	WPF 내의 Transform, Grdient를 사용해보기 위해 만들었습니다.
-	Nuget 등 외부 라이브러리의 도움 없이 WPF 기본 제공 기능으로만 제작하였습니다.
-	GIthub: https://github.com/sersen28/TouchableCard


2. 기능 설명
 2-1. Reactions
-	Skew: SkewTransform을 적용하였습니다. 마우스를 좌클릭한 상태로 움직이면 왜곡이 일어납니다.
-	Moving: 마우스를 좌클릭하면 해당 위치로 카드가 이동합니다.
-	Spinning: 카드 중심을 기준으로 마우스가 좌클릭된 위치를 향해 카드가 회전합니다.
2-2. Effects
-	None: 이펙트를 없앱니다.
-	Shining: 카드에 하얀색 이펙트를 입힙니다.
-	Prism: 무지개색 이펙트를 입힙니다.
 
3. 구현

3-1. SelectButton
-	RadioButton을 상속받아 구현한 컨트롤입니다.
-	카드의 반응, 혹은 리액션을 선택하기 위해 구현하였습니다.
-	ImageSource 데이터를 전달받는 NormalSource, CheckedSource를 DependencyProperty로 전달받아 이미지와 텍스트를 표시하는 RadioButton입니다.

 3-2. CardEffect
-	카드에 표시되는 이펙트입니다.
-	None, Shining, Prism의 세 가지 값을 가지는 CardType을 DependencyProperty로 전달받습니다.
-	움직이는 느낌을 주기 위해 중심부를 기준으로 약간의 TanslateTranform이 적용되어 있습니다.
-	CardType의 값에 따라 LinearGradientBrush로 구현된 PrsimEffect 혹은 RadialGradientBrush로 구현된 ShiningEffect가 DataTrigger로 Background 속성을 대체합니다.

 3-3. TouchableCard
-	실제로 유저 동작에 반응하는 카드가 구현된 컨트롤입니다.
-	Moving, Spinning, Skew의 세 가지 값을 가지는 CardType과 EffectType(내부의 CardEffetc에 전달)을 DependencyProperty로 전달받습니다.
-	마우스를 좌클릭한 경우에만 MouseMove 이벤트가 동작하며, Control의 범위를 이탈하거나 좌클릭을 해제하면 Transform이 원상 복구됩니다.
