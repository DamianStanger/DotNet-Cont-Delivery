# run this first -   Set-ExecutionPolicy RemoteSigned


# Local Variables
$MsBuild = $env:systemroot + "\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe";
$SlnFilePath = "ContinuousDelivery.sln"
 
$BuildArgs = @{
 FilePath = $MsBuild
 ArgumentList = $SlnFilePath, "/target:Clean", "/target:Build"
}
 
# Start the build
Start-Process @BuildArgs