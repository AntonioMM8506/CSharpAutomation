# CSharpAutomation



dotnet test

Run specific test using a @Tag
dotnet test --filter Category=GoogleSearch


Run and dumb the results in a text files
dotnet test --logger "console;verbosity=detailed" > testlog.txt

Combine both commands above
dotnet test --filter "Category=ReadExcel" --logger "console;verbosity=detailed" > testlog.txt