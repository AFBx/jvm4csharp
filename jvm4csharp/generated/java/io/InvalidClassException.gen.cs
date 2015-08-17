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
namespace jvm4csharp.java.io
{
	[JavaProxy("java/io/InvalidClassException")]
	public class InvalidClassException : ObjectStreamException
	{
		protected InvalidClassException(ProxyCtor p) : base(p) {}
		
		public InvalidClassException(String arg0) : base(ProxyCtor.I)
		{
			Instance.CallConstructor("(Ljava/lang/String;)V", arg0);
		}
		
		public InvalidClassException(String arg0, String arg1) : base(ProxyCtor.I)
		{
			Instance.CallConstructor("(Ljava/lang/String;Ljava/lang/String;)V", arg0, arg1);
		}
	
		[JavaSignature("Ljava/lang/String;")]
		public String classname
		{
			get { return Instance.GetField<String>("classname", "Ljava/lang/String;"); }
			set { Instance.SetField("classname", "Ljava/lang/String;", value); }
		}
	}
}
