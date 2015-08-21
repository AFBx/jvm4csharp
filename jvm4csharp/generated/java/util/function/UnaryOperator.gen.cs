//------------------------------------------------------------------------
//	This code was generated using jvm4csharp-generator:
//	https://github.com/bcrusu/jvm4csharp-generator
//
//	Generated using:
//	java_version					: 1.8.0_51
//	java_vm_name					: Java HotSpot(TM) 64-Bit Server VM
//	java_vm_version					: 25.51-b03
//------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace jvm4csharp.java.util.function
{
	[JavaProxy("java/util/function/UnaryOperator")]
	public partial interface UnaryOperator<T> : Function<T, T>
		where T : IJavaObject
	{
	}
	
	public static partial class UnaryOperator_
	{
		private static readonly JavaProxyOperations.Static Static = JavaProxyOperations.Static.Singleton;
		
		[JavaSignature("()Ljava/util/function/UnaryOperator;")]
		public static UnaryOperator<T1> identity<T1>()
			where T1 : IJavaObject
		{
			return Static.CallMethod<UnaryOperator<T1>>(typeof(UnaryOperator<>), "identity", "()Ljava/util/function/UnaryOperator;");
		}
	
	}
}
