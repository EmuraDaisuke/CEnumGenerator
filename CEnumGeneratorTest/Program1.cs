


using CEnum;



namespace SourceGeneratorTest
{
	[CEnum]
	enum EFuga2 : long {
		Hoge=1,
		Fuga=3,
		Piyo=5,
	}
	[CEnum]
	enum EFuga3 : long {
		Hoge=1,
		Fuga,
		Piyo,
	}
	[CEnum]
	enum EFuga4 {
	}
	[CEnum, Flags]
	enum EFuga5 {
	}
	[CEnum, Flags]
	enum EFuga6 {
		Zero,
	}
}
