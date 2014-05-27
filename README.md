King Mapper
==========

Simple C# object mapping; map between objects with similar properties; or from Data Reader, Data Table and Data Sets.

## Nuget
https://www.nuget.org/packages/King.Mapper
```
PM> Install-Package King.Mapper
```
## Examples
### Object Mapping
```
var a = new ObjectA();
var b = a.Map<ObjectB>();
```
### Data Reader
```
IDataReader x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();
```
### Data Table
```
DataTable x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();
```
### Data Set
```
DataSet x = null;
object obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();
```