## MSBuild


### Technology Overview

What is it?

Underlying tech by Visual Studio to compile and build projects
  - interpreted programming language expressed in XML
  - expressed in XML
  - The interpreter is called MSBuild.exe
    - part of Vistual Studio (F5), part of the command line and part of DevOps
  - Optimised for building software and automating common development tasks
  - It's the underlying technology in visual studio to build projects
  
### MSBuild Project Files

It's basically an xml file

- You need a Project tag, entry point or highest level container for all msbuild instructions
`<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">`
this resolves to a schema in the dotnet framework folders `c:\windows\microsoft.net\framework\v4.0.30319\msbuild`

### Targets
Container for instructions, a simple one is `<Target Name="HelloWorld">`  

Multiple targets, the first target is always executed, to execute another target, you use the following command  
`msbuild .\DoSomething.msbuild /target:ByeWorld`  

Set a default target in the Project container  
`<Project DefaultTargets="ByeWorld" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">`  


### Tasks
Invoking a function or another tool from within the xml file  
`<Message Text="Hello, World!"/>`  

Like a method or a function call. Gets invoked by the msbuild runtime  

If you add Importance, it will output different logging levels to the console  
`Importance="high"`  

You can change verbosity from the command line `/v:minimal` (normal, detailed or ordiagnostic)
or add that to the rsp file  

### RSP files

A repsonse file is used to pass in commands  
`msbuild .\DoSomething.msbuild @args.rsp`  
Note: The file must be in the same directory as msbuild.exe, you will need to use the full path  
`msbuild .\DoSomething.msbuild @e:\repos\MSBuild\args.rsp`  


### Properties
Scalar variable, key value pair. Storage area
```
<PropertyGroup>
  <Name>Homie</Name>
</PropertyGroup>
```
To reference the value, use the following syntax  
`<Message Text="Hello, $(Name)" Importance="high"/>`

You can also do something like this:  

<PropertyGroup>
  <Name>Homie</Name>
  <FullName>$(name) Simpson</FullName>
</PropertyGroup>
```

Then refernce it as follows:  
`<Message Text="$FullName)" Importance="high"/>`

You can also override the value on the command line `/p:Name=Lisa`  

There are some reserved properties  
```
  <Target Name="ReservedProperties">
    <Message Text="MSBuildProjectDirectory: $(MSBuildProjectDirectory)"/>
  </Target>
```
### Items
This can be though of as an array

To use the Items, use the following syntax  
```
    <PropertyGroup>
        <Name>Homer</Name>
        <FullName>$(Name) Simpson</FullName>
        <FilePath>$(MSBuildProjectDirectory)\*.*</FilePath>
    </PropertyGroup>

    <ItemGroup>
        <Files Include="$(FilePath)"/>
    </ItemGroup>
    
    <Target Name="ListFiles">
        <Message Text="@(Files)"/>
    </Target>
```