package main

import (
	"github.com/gin-contrib/static"
	"github.com/gin-gonic/gin"
	"github.com/kardianos/osext"
)

func main() {
	path, _ := osext.ExecutableFolder()

	r := gin.Default()
	r.Use(static.Serve("/", static.LocalFile(path+"/public", true)))
	r.NoRoute(func(c *gin.Context) {
		c.File("./public/index.html")
	})
	r.Run()
}
