KingMapper
==========

Simple C# object mapping

Nuget
https://www.nuget.org/packages/King.Mapper
PM> Install-Package King.Mapper

Example

var a = new ObjectA();
var b = a.Map<ObjectB>();

IDataReader x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();

DataTable x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();

DataSet x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();