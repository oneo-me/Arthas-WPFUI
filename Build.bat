@echo off
dotnet clean --nologo -c Release
dotnet pack --nologo -c Release -o ./Output