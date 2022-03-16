# CopaGamesLambda3Api

<strong>@Lambda3</strong> technical test built with .NET 5 by <strong>Lucas Eschechola.</strong>

<br>

## How to run - API

<br>

1. Download .NET 5 SDK <a href="https://dotnet.microsoft.com/en-us/download/dotnet/5.0">here</a>

<br>

2. Clone the repository
    
    ```bash
    $ git clone https://github.com/Eschechola/CopaGamesLambda3Api.git
    ```

<br>

3. Clean, restore and build
    
    ```bash
    $ cd LucasEschechola-10-03-2022/CopaGamesLambda3Api
    $ dotnet clean
    $ dotnet restore
    $ dotnet build 
    ```

<br>

4. Add enviroment variables
    <br><br>4.1. Init user secrets
    ```bash
    $ dotnet user-secrets init --project .\src\CopaGamesLambda3.API\CopaGamesLambda3.API.csproj
    ```

    <br>4.2. Add games api url
    ```bash
    $ dotnet user-secrets set "APIs:GamesApiUrl" "https://l3-processoseletivo.azurewebsites.net/api" --project .\src\CopaGamesLambda3.API\CopaGamesLambda3.API.csproj
    ```

    <br>5. Run the project!
    ```bash
    $ dotnet run 
    ```
    <strong>OBS:</strong> <i>The project runs on https://localhost:5001, to access routes documentation swagger runs on https://localhost:5001/swagger/index.html :)</i>


<br><br>

<p align="center"><strong>2022</strong></p>