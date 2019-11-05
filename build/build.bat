@ECHO OFF
SET Arbor.Build.Build.Bootstrapper.AllowPrerelease=true
SET Arbor.Build.Tools.External.MSpec.Enabled=true
SET Arbor.Build.MSBuild.NuGetRestore.Enabled=true
SET Arbor.Build.NuGet.Package.Artifacts.CreateOnAnyBranchEnabled=false
SET Arbor.Build.NuGet.Package.CreateNuGetWebPackages.Enabled=true
CALL dotnet arbor-build

REM Restore variables to default

REM SET Arbor.Build.Vcs.Branch.Name=
SET Arbor.Build.Tools.External.MSpec.Enabled=
SET Arbor.Build.NuGet.Package.Artifacts.Suffix=
SET Arbor.Build.NuGet.Package.Artifacts.BuildNumber.Enabled=
SET Arbor.Build.Log.Level=
SET Arbor.Build.NuGetPackageVersion=
SET Arbor.Build.Vcs.Branch.Name.Version.OverrideEnabled=
SET Arbor.Build.VariableOverrideEnabled=
SET Arbor.Build.Artifacts.CleanupBeforeBuildEnabled=
SET Arbor.Build.Build.NetAssembly.Configuration=

EXIT /B %ERRORLEVEL%
