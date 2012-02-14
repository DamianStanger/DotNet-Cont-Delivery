Set-StrictMode -Version 2

# run this first -   Set-ExecutionPolicy RemoteSigned
# Start-Process @BuildArgs -NoNewWindow


# Local Variables
$MsBuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe";
$SlnFilePath = "ContinuousDelivery.sln";
 
$BuildArgs = @{
 FilePath = $MsBuild;
 ArgumentList = $SlnFilePath, "/target:Clean", "/target:Build", "/property:OutDir=build\";
}
 
# Start the build
Start-Process @BuildArgs;