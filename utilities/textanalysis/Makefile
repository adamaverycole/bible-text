project_name =  src/TextAnalysis.Cli

all:
	clean build test

debug:
	dotnet run --project $(project_name) -c Debug

clean:
	dotnet clean src

build:
	dotnet build src

test:
	dotnet test src

run:
	dotnet run --project $(project_name)

run-transliterate:
	dotnet run --project src/TextAnalysis.Cli -- textanalysis transliterate genesis,exodus --sourceFile tanakh.txt --outputFile gen-exo.txt --type transliterate
