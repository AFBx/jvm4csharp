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
namespace jvm4csharp.java.util.logging
{
	[JavaProxy("java/util/logging/LoggingMXBean")]
	public interface LoggingMXBean : IJavaObject
	{
		[JavaSignature("(Ljava/lang/String;)Ljava/lang/String;")]
		String getLoggerLevel(String arg0);
		
		[JavaSignature("(Ljava/lang/String;)Ljava/lang/String;")]
		String getParentLoggerName(String arg0);
		
		[JavaSignature("(Ljava/lang/String;Ljava/lang/String;)V")]
		void setLoggerLevel(String arg0, String arg1);
		
		[JavaSignature("()Ljava/util/List;")]
		List<String> getLoggerNames();
	}
}
