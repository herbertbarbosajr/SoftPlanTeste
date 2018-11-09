var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));
var bynarypackDirectory = MakeAbsolute(Directory("./bynarypack"));

Setup(context =>
{
    CleanDirectory(artifactsDirectory);
    CleanDirectory(bynarypackDirectory);
});

Task("Build")
    .Does(() =>
    {
        foreach (var project in GetFiles("**/*.csproj"))
        {
            DotNetCoreBuild(
                project.GetDirectory().FullPath,
                new DotNetCoreBuildSettings()
                {
                    Configuration = configuration
                });
        }
    }
);

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        foreach(var project in GetFiles("**/*.Test.csproj"))
        {
            DotNetCoreTest(
                project.GetDirectory().FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration
                }
            );
        }
    }
);

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
    {
        foreach(var project in GetFiles("**/*.Api.csproj"))
        {
            DotNetCorePublish(
                project.GetDirectory().FullPath,
                new DotNetCorePublishSettings()
                {
                    Configuration = configuration,
                    OutputDirectory = artifactsDirectory
                }
            );
        }
    }
);

Task("BynaryPack")
    .IsDependentOn("Publish")
    .Does(() => 
    {
        var bynarys = GetFiles($"{artifactsDirectory}/**/*");
        Zip("./", $"{bynarypackDirectory}/calcsoftApi.zip", bynarys);
    }
);

Task("Default")
    .IsDependentOn("BynaryPack");

RunTarget(target);