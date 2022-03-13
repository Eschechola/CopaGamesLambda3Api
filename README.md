# CopaGamesLambda3Api

<strong>@Lambda3</strong> technical test built with .NET 5 by <strong>Lucas Eschechola.</strong>

<br>

## How to run

<br>

1. Clone the repository
    ```bash
    $ git clone https://github.com/<organization>/<repository>.git
    ```

2. Clean, restore and build
    ```bash
    $ cd <project-folder>
    $ dotnet clean
    $ dotnet restore
    $ dotnet build 
    ```
    
3. Add enviroment variables
    <br><br>3.1. Init user secrets
    ```bash
    $ dotnet user-secrets init --project .\src\CopaGamesLambda3.API\CopaGamesLambda3.API.csproj
    ```

    <br>3.2. Add games api url
    ```bash
    $ dotnet user-secrets set "APIs:GamesApiUrl" "https://l3-processoseletivo.azurewebsites.net/api" --project .\src\CopaGamesLambda3.API\CopaGamesLambda3.API.csproj
    ```

    <br>4. Run the project!
    ```bash
    $ dotnet run 
    ```
    <strong>OBS:</strong> <i>The project runs on https://localhost:5001, to access routes documentation swagger runs on https://localhost:5001/swagger/index.html :)</i>


<br><br>
<p align="center"><strong>2022</strong></p>