# Instructios
You can run it using CLI (dotnet run) or in VS, just need to be pointing RapidPay.Api project.

Will need to run docker compose up --build in order to run the database container

You will 2 options to run the project, locally or in docker, bot cases using port 5008.

after you run it, please run the followig commands in order to create the migration for the data: "dotnet ef migrations add initial"  and "dotnet ef database update"

After you test, will need to register a user using /api/login/registeration, and then use api/login/ to get the access token (jwt) , both cases need to use POST
