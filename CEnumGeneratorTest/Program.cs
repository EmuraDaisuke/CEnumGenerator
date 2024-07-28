


using System.Runtime.Serialization;

using CEnum;



[CEnum]
enum EHoge : byte {Hoge,Fuga,Piyo,_Length,}



namespace SourceGeneratorTest
{
	[CEnum]
	enum EFuga : short {Hoge=(short)EHoge._Length,Fuga,Piyo,}
	
	
	
	namespace Hoge
	{
		[CEnum] [Flags]
		enum EPiyo : long {Hoge=(1<<0),Fuga=(1<<1),Piyo=(1<<2),All=(Hoge|Fuga|Piyo),}
		
		
		
		partial class Program
		{
			[CEnum]
			public enum EPuyo : short {Hoge=0,Fuga=0,Piyo=0,}
			
			
			
			public partial class Child
			{
				[CEnum]
				public enum EPoyo : byte
				{
					[EnumMember(Value = "MemberHoge")] Hoge=1,
					[EnumMember(Value = "MemberFuga")] Fuga,
					[EnumMember(Value = "MemberPiyo")] Piyo,
				}
			}
			
			
			
			static void Main(string[] args)
			{
				Log("[ Main");
				
				{	// 
					var c = (CEHoge)EHoge.Piyo;
					Log($"{c.Name}");
					var e = (EHoge)c;
					Log($"{Enum.GetName<EHoge>(e)}");
					Log($"---");
				}
				
				{	// 
					var e = CEHoge.CPiyo;
					Log($"{e.Name}.{e.Value}.{e.ToString()}");
				}
				
				{	// 
					var e = CEHoge.Parse("CFuga");
					Log($"{e.Name}.{e.Value}.{e.ToString()}");
				}
				
				{	// 
					var e = CEHoge.Parse(3);
					Log($"{e.Name}.{e.Value}.{e.ToString()}");
				}
				
				{	// 
					if (CEHoge.TryParse("CPiyo", out var e)){
						Log($"{e.Name}.{e.Value}.{e.ToString()}");
					} else {
						Log($"Error");
					}
				}
				
				{	// 
					if (CEHoge.TryParse(1, out var e)){
						Log($"{e.Name}.{e.Value}.{e.ToString()}");
					} else {
						Log($"Error");
					}
				}
				
				{	// 
					var f3 = EPiyo.Hoge | EPiyo.Piyo;
					Log($"{Enum.GetName<EPiyo>(f3)}.{(int)f3}.{f3.ToString()}");
					Log($"{f3.HasFlag(EPiyo.Hoge)}");
					Log($"{f3.HasFlag(EPiyo.Fuga)}");
					Log($"{f3.HasFlag(EPiyo.Piyo)}");
					Log($"{f3.HasFlag(EPiyo.Hoge | EPiyo.Piyo)}");
				}
				
				{	// 
					var e3 = CEPiyo.CHoge | CEPiyo.CPiyo;
					Log($"{e3.Name}.{e3.Value}.{e3.ToString()}");
					Log($"{e3.HasFlag(CEPiyo.CHoge)}");
					Log($"{e3.HasFlag(CEPiyo.CFuga)}");
					Log($"{e3.HasFlag(CEPiyo.CPiyo)}");
					Log($"{e3.HasFlag(CEPiyo.CHoge | CEPiyo.CPiyo)}");
				}
				
				{	// 
					var e = (CEFuga)5;
					Log($"{e.Name}.{e.Value}");
				}
				
				{	// 
					var e = (CEFuga)EFuga.Fuga;
					Log($"{e.Name}.{e.Value}");
				}
				
				{	// 
					var e = (CEFuga)"CHoge";
					Log($"{e.Name}.{e.Value}");
				}
				
				Log("] Main");
			}
			
			
			
			static void Log(string Text) => Console.WriteLine(Text);
		}
	}
}
