High performance C# model mapping!
+ Map between Models with similar properties.
+ Map from Data Readers, Data Tables and Data Sets to Models.
+ Execute Stored Procedures as objects.
+ Everything mock able for proper unit testing.
+ Prefer Async calls where available.

## NuGet
[Add via NuGet](https://www.nuget.org/packages/King.Mapper)
```
PM> Install-Package King.Mapper
```

## Examples
### Namespaces
```
using King.Mapper;
using King.Mapper.Data;
```
### [Model Mapping](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Tests/ObjectMapTests.cs)
```
var a = new ModelA()
{
	PropertyA = "The-Value-Of-Property-A"
};

var b = a.Map<ModelB>();
var isTrue = a.PropertyA == b.PropertyA;
```
### [Dictionary Mapping](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Tests/ObjectMapTests.cs)
```
var a = new ModelA()
{
	PropertyA = "The-Value-Of-Property-A"
};

var dic = a.ToDictionary();
var isTrue = a.PropertyA == dic["PropertyA"];
```
### [Data Record](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/IDataRecordTests.cs)
```
var record = new IDataRecord();
var firstName = record.Get<string>("FirstName");
var id = record.Get<int>("Identifier");
```
### [Data Reader/Data Set](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/LoaderTests.cs)
```
var reader = new IDataReader();
var model = reader.Model<object>(); //Single Model from one Row
var list = reader.Models<object>(); //Multiple Models from many Rows
```
### [Stored Procedure](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/ExecutorTests.cs)
Autogenerate your data access layer: [King.Mapper.Generator](https://github.com/jefking/King.Mapper.Generator)
```
using (var connection = new SqlConnection(""))
{
	var sproc = new IStoredProcedure();
	var executor = new Executor(connection);
	var data = await executor.Execute(sproc);
}
```
### Testing (Mocking Data with NSubstitute)
```
var sproc = new IStoredProcedure();
var executor = Substitute.For<IExecute>();
executor.Execute(sproc).Returns(DataSet);
// Pass to class you are testing.
var dal = new DataClass(executor);
```