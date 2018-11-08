#!/usr/bin/env bash

#exit if any command fail
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

dotnet restore

dotnet test ./CalcSoft.Test/CalcSoft.Test.csproj -c Release -f netcoreapp2.1

dtonet build ./CalcSoft.Test/CalcSoft.Test.csproj -c Release -f net451

mono \
  ./CalcSoft.Test/bin/Release/net451/*/dotnet-test-xunit.exe \
  ./CalcSoft.Test/bin/Release/net451/*/CalcSoft.Test.dll

revision=${TRAVIS_JOB_ID:=1}
revision=$(printf "%04d" $revision) 

dotnet pack ./CalcSoft.Api/CalcSoft.Api.csproj -c Release -o ./artifacts --version-suffix=$revision