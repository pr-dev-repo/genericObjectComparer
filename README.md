# genericObjectComparer
Allows the implementation of customized equality comparison for collections. 

# Framework: .NET Core 3.1


# Usage

To be used with dynamic link.

reference library or class as you please

eg. 

someIQueryable.Select<someDTO>($"new({field})").Distinct(new ObjectComparer<someDTO>(field)).OrderBy(field).Take(someNumber).ToList();
