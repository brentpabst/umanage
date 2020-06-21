SRC := ./cmd
DIST := ./bin

.PHONY: help build clean

start: clean install build run ## A shortcut method to build and run the app

help:
	@grep -E '^[a-zA-Z0-9_-]+:.*?## .*$$' $(MAKEFILE_LIST) | sort | awk 'BEGIN {FS = ":.*?## "}; {printf "\033[36m%-30s\033[0m %s\n", $$1, $$2}'

build: ## Compile full app
	export GO111MODULE=on
	mkdir -p $(DIST)
	npm run build --cwd ./web --prefix ./web
	GO111MODULE=on go build -o $(DIST)/umanage $(SRC)/server.go

clean: ## Cleans the local workspace
	rm -rf ./bin Gopkg.lock

install: ## Install dependencies
	go mod download
	npm install --cwd ./web --prefix ./web

run: ## Runs the app
	./bin/umanage