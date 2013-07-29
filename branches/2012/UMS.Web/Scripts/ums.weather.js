function WeatherModel(element) {
    var self = this;
    self.update = function () {
        if (navigator && navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                self.getWeather(position.coords.latitude, position.coords.longitude);
            });
        }
        else {
            $(element).html("<em>Temporarily Unavailable</em>");
        }
    };
    self.getWeather = function (latitude, longitude) {
        $.ajax({
            url: "http://i.wxbug.net/REST/Direct/GetData.ashx?dt=o&dt=f&nf=2&ic=1&api_key=" + key + "&la=" + latitude + "&lo=" + longitude,
            dataType: "jsonp",
            crossDomain: true,
            jsonp: "f",
            jsonpCallback: "umanage",
            success: function (data) {
                var o = data.weather.ObsData;
                var f = data.weather.ForecastData.forecastList;
                var s = "";
                s += "<div class=\"clear-fix\">";
                s += "<div class=\"left\">";
                s += "<img src=\"http://img.weather.weatherbug.com/forecast/icons/localized/55x46/en/trans/" + o.icon + ".png\" alt=\"" + o.desc + "\" />";
                s += "</div>";
                s += "<div class=\"left\">";
                s += o.stationName;
                s += "<br />";
                s += "<strong>Currently:</strong>";
                s += "<br />";
                s += o.desc + ", " + o.temperature + o.temperatureUnits;
                s += "</div>";
                s += "</div>";
                s += "<strong>Forecast:</strong>";
                s += "<br />";
                for (var i = 0; i < f.length; i++) {
                    s += "<u>" + f[i].dayTitle + "</u><br />";
                    s += f[i].dayDesc + ". H: ";
                    s += f[i].high + o.temperatureUnits + " / L: ";
                    s += f[i].low + o.temperatureUnits;
                    s += "<br />";
                }
                $(element).html(s);
            }
        });
    };
};