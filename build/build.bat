@ECHO OFF
SET Arbor.X.Build.Bootstrapper.AllowPrerelease=true
SET Arbor.X.Tools.External.MSpec.Enabled=true
SET Arbor.X.MSBuild.NuGetRestore.Enabled=true
SET Arbor.X.NuGet.Package.Artifacts.CreateOnAnyBranchEnabled=false
SET Arbor.X.NuGet.Package.CreateNuGetWebPackages.Enabled=true
CALL "%~dp0\Build.exe"

REM Restore variables to default

SET Arbor.X.Build.Bootstrapper.AllowPrerelease=
REM SET Arbor.X.Vcs.Branch.Name=
SET Arbor.X.Tools.External.MSpec.Enabled=
SET Arbor.X.NuGet.Package.Artifacts.Suffix=
SET Arbor.X.NuGet.Package.Artifacts.BuildNumber.Enabled=
SET Arbor.X.Log.Level=
SET Arbor.X.NuGetPackageVersion=
SET Arbor.X.Vcs.Branch.Name.Version.OverrideEnabled=
SET Arbor.X.VariableOverrideEnabled=
SET Arbor.X.Artifacts.CleanupBeforeBuildEnabled=
SET Arbor.X.Build.NetAssembly.Configuration=

EXIT /B %ERRORLEVEL%
