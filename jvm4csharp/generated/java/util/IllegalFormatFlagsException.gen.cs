//------------------------------------------------------------------------
//	This code was generated using jvm4csharp-generator:
//	https://github.com/bcrusu/jvm4csharp-generator
//
//	Generated using:
//	java_version					: 1.8.0_51
//	java_vm_name					: Java HotSpot(TM) 64-Bit Server VM
//	java_vm_version					: 25.51-b03
//------------------------------------------------------------------------

using jvm4csharp.java.lang;

// ReSharper disable InconsistentNaming
namespace jvm4csharp.java.util
{
	[JavaProxy("java/util/IllegalFormatFlagsException")]
	public partial class IllegalFormatFlagsException : IllegalFormatException
	{
		protected IllegalFormatFlagsException(ProxyCtor p) : base(p) {}
		
		public IllegalFormatFlagsException(String arg0) : base(ProxyCtor.I)
		{
			Instance.CallConstructor("(Ljava/lang/String;)V", arg0);
		}
	
		[JavaSignature("()Ljava/lang/String;")]
		public String getFlags()
		{
			return Instance.CallMethod<String>("getFlags", "()Ljava/lang/String;");
		}
	}
}
