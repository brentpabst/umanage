package main

import (
	"github.com/gin-contrib/static"
	"github.com/gin-gonic/gin"
	"github.com/kardianos/osext"
)

func main() {
	path, _ := osext.ExecutableFolder()

	r := gin.Default()

	// Static route
	r.Use(static.Serve("/", static.LocalFile(path+"/public", false)))

	// API routes
	// a := r.Group("/api")
	// {
	// 	// a.POST("/user", userEndpoint)
	// }

	// Not found route redirects to the web app for a pretty 404
	r.NoRoute(func(c *gin.Context) {
		c.Redirect(304, "/")
	})

	// Run gin
	r.Run()
}
