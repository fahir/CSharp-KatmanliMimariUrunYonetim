using OZBAY.Core.Aspects.Postsharp.ExceptionAspects;
using OZBAY.Core.Aspects.Postsharp.LogAspects;
using OZBAY.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System.Reflection;
using System.Runtime.InteropServices;
using OZBAY.Core.Aspects.PostSharp.PerformanceAspects;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MyShop.Northwind.Business")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MyShop.Northwind.Business")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: LogAspect(typeof(FileLogger), AttributeTargetTypes = "MyShop.Northwind.Business.Concrete.Managers.*")]
[assembly: LogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "MyShop.Northwind.Business.Concrete.Managers.*")]
[assembly: ExceptionLogAspect(typeof(DatabaseLogger), AttributeTargetTypes = "MyShop.Northwind.Business.Concrete.Managers.*")]
[assembly: PerformanceCounterAspect(5, typeof(MailLogger), AttributeTargetTypes = "MyShop.Northwind.Business.Concrete.Managers.*")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUId is for the Id of the typelib if this project is exposed to COM
[assembly: Guid("ecec3bcb-01be-4006-a528-f66d253abbf8")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
