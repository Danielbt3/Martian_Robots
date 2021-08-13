Steps to generate a coverage report:
Go to your package manager console and execute "dotnet test --collect:"XPlat Code Coverage"" save the resulting path
If it,s the first time that u are doing a coverage report you need to execute "dotnet tool install -g dotnet-reportgenerator-globaltool" on your package console
First step should have generated a TestResults folder , on the root folder of the test proyect, replace this command path with the one of the xml in that folder and run it:
"reportgenerator -reports:"{YOUR COMPLETE PATH HERE}" -targetdir:"coveragereport" -reporttypes:Html"
You should be able to find a "coverageReport" folder in your root proyect folder containing the results.