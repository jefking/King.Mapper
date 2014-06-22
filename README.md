King Mapper
==========

Simple C# object mapping!
+ Map between objects with similar properties.
+ Map from Data Readers, Data Tables and Data Sets to Models.
+ Execute Stored Procedures with objects.
+ Everything mockable for proper unit testing.

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
using King.Mapper.Data.Sql;
```
### [Object Mapping](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Tests/ObjectMapTests.cs)
```
var a = new ObjectA()
{
	PropertyA = "The-Value-Of-Property-A"
};

var b = a.Map<ObjectB>();
var isTrue = a.PropertyA == b.PropertyA;
```
### [Data Record](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/IDataRecordTests.cs)
```
IDataRecord x = null;
var firstName = x.Get<string>("FirstName");
var id = x.Get<int>("Identifier");
```
### [Data Reader/Data Set](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/LoaderTests.cs)
```
IDataReader x = null;
var obj = x.LoadObject<object>();
IEnumerable<object> list = x.LoadObjects<object>();
```
### [Stored Procedure](https://github.com/jefking/King.Mapper/blob/master/King.Mapper.Integration/ExecutorTests.cs)
```
using (var connection = new SqlConnection(""))
{
	IStoredProcedure sproc = null;
	var executor = new Executor(con);
	var data = await executor.Execute(sproc);
}
```
## Contributing

Contributions are always welcome. If you have find any issues, please report them to the [Github Issues Tracker](https://github.com/jefking/King.Mapper/issues?sort=created&direction=desc&state=open).

## About the Author

Jef King has worked in the software industry for fourteen years. Over this time he has experienced a range of responsibilities in various industries. His passion for technology and motivating teams has kept his drive and focus strong. Early on in his career he showed an entrepreneurial spirit, starting multiple small companies. He departed from this to learn more about the software industry by working with larger companies, such as Microsoft. These diverse experiences have given a very unique perspective on teams and software engineering. Since moving back to Vancouver he has built several highly productive software development teams, and inspired others to try similar techniques.

## Apache 2.0 Licence

Copyright 2014 Jef King

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at

[http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.