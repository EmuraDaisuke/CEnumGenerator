


using System.Runtime.Serialization;

using CEnum;



[CEnum] enum ETest {a,b,};
[CEnum, Flags] enum EFlag : long {[EnumMember(Value="A")]a=(1L<<0),[EnumMember(Value="B")]b=(1L<<60),}



namespace SourceGeneratorTest
{
	namespace Hoge
	{
		partial class Program
		{
			static void Main(string[] args)
			{
				Log("[ Main");
				
				{	// 
					var c0 = (CETest)ETest.a;
					CETest c1 = ETest.b;
					Log($"{c0.Name}.{c0.Value}");
					Log($"{c1.Name}.{c1.Value}");
					
					var e0 = (ETest)c0;
					ETest e1 = c1;
					Log($"{Enum.GetName(e0)}.{(int)e0}");
					Log($"{Enum.GetName(e1)}.{(int)e1}");
					
					var c2 = CETest.Ca;
					var c3 = CETest.Cb;
					Log($"{c2.Name}.{c2.Value}");
					Log($"{c3.Name}.{c3.Value}");
					
					switch (c2){
						case (int)ETest.a: break;
						case (int)ETest.b: break;
					}
					
					switch (c2.Value){
						case (int)ETest.a: break;
						case (int)ETest.b: break;
					}
					
					var a0 = new string[CETest.Length];
					a0[(int)ETest.a] = "a";
					a0[(int)ETest.b] = "b";
					var s0 = a0[c2];
					
					var a1 = new string[CETest.Length];
					a1[(int)ETest.a] = "a";
					a1[(int)ETest.b] = "b";
					var s1 = a1[c2.Value];
					
					var c4 = CEFlag.Ca;
					var c5 = c4 | CEFlag.Cb;
					Log($"{c5.Name}.0x{c5.Value:x}.{c5.ToString()}");
					
					var m4 = c4.GetEnumMemberValue();
					Log($"{m4}");
					
					try {
						var c6 = (CETest)999;
						Log($"c6 : Done");
					}
					catch (Exception){
						Log($"c6 : Exception");
					}
					
					try {
						var c7 = (CEFlag)(1<<30);
						Log($"c7 : Done");
					}
					catch (Exception){
						Log($"c7 : Exception");
					}
					
					var e6 = (ETest)999;
					var e7 = (EFlag)(1<<30);
					Log($"{Enum.GetName(e6)}.{(int)e6}");
					Log($"{Enum.GetName(e7)}.0x{(int)e7:x}");
				}
				
				Log("] Main");
			}
			
			
			
			static void Log(string Text) => Console.WriteLine(Text);
		}
	}
}
