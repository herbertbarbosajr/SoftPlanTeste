var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));

Setup(context =>
{
    CleanDirectory(artifactsDirectory);
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

Task("Default")
    .IsDependentOn("Publish");

RunTarget(target);