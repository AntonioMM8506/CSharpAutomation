# CSharpAutomation

## Instructions

Clone this repository

Then run the following command

```
dotnet restore
```

If no  error was found then run the following command
```
dotnet build
```

The folders **bin** and **obj** have to be created once these 2 command have been completed.

### Important
**All the Excel files have to be allocated inside the _bin/netcoreapp8_ folder.**


If you want to run all the available test cases
```
dotnet test
```

If you want to run a specific test using a @Tag
```
dotnet test --filter Category=GoogleSearch
```

Usually, you will not see anything printed in the console, so if you want to see what it is printed in the console and a morde detailed log. Run and dumb the results in a text files
```
dotnet test --logger "console;verbosity=detailed" > testlog.txt

```

You can also combine both commands above
```
dotnet test --filter "Category=ReadExcel" --logger "console;verbosity=detailed" > testlog.txt
```