![](https://repository-images.githubusercontent.com/10535292/2e6cd280-afd5-11ea-84ab-c2b720ecf962)

## Local machine setup
You will need a few components installed in order to pull, build, and run this app locally:
* Ensure you have already installed the pre-reqs:
    * `golang >=1.14.3`
    * `node >=14.3.0 && npm >=6.14.4 && vue-cli >= 4.4.4`
    * `docker >= 19.03.8`
* You will need the ability to execute a Makefile, if you're using Windows make sure you have the Linux runtime or cygwin compatible stuff installed

## Makefile targets
All local dev work executes using Makefile targets.  Some targets are chained to provide some semblance of shorthand commands.  You can always run `make help` in the working directory to see a current list of common commands.

## TL;DR; quickstart
Run `make` to start the app

That's it? That's it.