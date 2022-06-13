dotnet sonarscanner begin /k:"empleosApp" /d:sonar.host.url="https://sonar-test.bit2bittest.com" /d:sonar.login="b91b00efdb5258dc80e389ced2faa6383ac001c4"
dotnet build "EmpleosApp.sln"
dotnet sonarscanner end /d:sonar.login="b91b00efdb5258dc80e389ced2faa6383ac001c4"