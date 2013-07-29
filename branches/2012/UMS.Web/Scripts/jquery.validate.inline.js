(function ($) {
    //Change <span> validation message display to top right corner style prompt
    $.fn.makeValidationInline = function (options) {

        var settings = {
            showTriangle: true,
            promptPosition: "topRight"
        };
        $.extend(settings, options);

        return this.each(function () {

            var $form = $(this);

            //#region message prompt functions
            /*
            * Inline Form Validation Engine 1.3.9.5, jQuery plugin
            * 
            * Copyright(c) 2009, Cedric Dugas
            * http://www.position-relative.net
            *	
            * Form validation engine which allow custom regex rules to be added.
            * Licenced under the MIT Licence
            * Modified by Jeffrey Lee, http://blog.darkthread.net, to support ASP.NET MVC 3
            */
            function buildPrompt(caller, promptText, type, ajaxed) {			// ERROR PROMPT CREATION AND DISPLAY WHEN AN ERROR OCCUR

                var $divFormError = $("<div />");
                var $formErrorContent = $("<div class='formErrorContent' />");

                $formErrorContent.html(promptText);

                var $caller = $(caller);

                $divFormError.addClass("formError");

                if (type == "pass") { $divFormError.addClass("greenPopup") }
                if (type == "load") { $divFormError.addClass("blackPopup") }
                if (ajaxed) { $divFormError.addClass("ajaxed") }

                $divFormError.addClass($caller.attr("id"))
                .append($formErrorContent).appendTo("body");

                if (settings.showTriangle != false) {		// NO TRIANGLE ON MAX CHECKBOX AND RADIO
                    var $arrow = $("<div class='formErrorArrow' />");
                    $divFormError.append($arrow)
                    if (settings.promptPosition == "bottomLeft" || settings.promptPosition == "bottomRight") {
                        $arrow.addClass("formErrorArrowBottom")
                        $arrow.html('<div class="line1"><!-- --></div><div class="line2"><!-- --></div><div class="line3"><!-- --></div><div class="line4"><!-- --></div><div class="line5"><!-- --></div><div class="line6"><!-- --></div><div class="line7"><!-- --></div><div class="line8"><!-- --></div><div class="line9"><!-- --></div><div class="line10"><!-- --></div>');
                    }
                    if (settings.promptPosition == "topLeft" || settings.promptPosition == "topRight") {
                        $divFormError.append($arrow)
                        $arrow.html('<div class="line10"><!-- --></div><div class="line9"><!-- --></div><div class="line8"><!-- --></div><div class="line7"><!-- --></div><div class="line6"><!-- --></div><div class="line5"><!-- --></div><div class="line4"><!-- --></div><div class="line3"><!-- --></div><div class="line2"><!-- --></div><div class="line1"><!-- --></div>');
                    }
                }

                callerTopPosition = $caller.offset().top;
                callerleftPosition = $caller.offset().left;
                callerWidth = $caller.width()
                inputHeight = $divFormError.height()

                /* POSITIONNING */
                if (settings.promptPosition == "topRight") { callerleftPosition += callerWidth - 30; callerTopPosition += -inputHeight - 10; }
                if (settings.promptPosition == "topLeft") { callerTopPosition += -inputHeight - 10; }

                if (settings.promptPosition == "centerRight") { callerleftPosition += callerWidth + 13; }

                if (settings.promptPosition == "bottomLeft") {
                    callerHeight = $caller.height();
                    callerleftPosition = callerleftPosition;
                    callerTopPosition = callerTopPosition + callerHeight + 15;
                }
                if (settings.promptPosition == "bottomRight") {
                    callerHeight = $caller.height();
                    callerleftPosition += callerWidth - 30;
                    callerTopPosition += callerHeight + 15;
                }
                $divFormError.css({
                    top: callerTopPosition,
                    left: callerleftPosition,
                    opacity: 0
                })
                return $divFormError.animate({ "opacity": 0.8 }, function () { return true; });
            }

            function updatePromptText(caller, promptText, type, ajaxed) {	// UPDATE TEXT ERROR IF AN ERROR IS ALREADY DISPLAYED

                var $caller = $(caller);
                var $updateThisPrompt = $("div." + caller.id);
                if ($updateThisPrompt.length == 0)
                    return buildPrompt(caller, promptText, type, ajaxed);

                (type == "pass") ? $updateThisPrompt.addClass("greenPopup") : $updateThisPrompt.removeClass("greenPopup");
                (type == "load") ? $updateThisPrompt.addClass("blackPopup") : $updateThisPrompt.removeClass("blackPopup");
                (ajaxed) ? $updateThisPrompt.addClass("ajaxed") : $updateThisPrompt.removeClass("ajaxed");

                $updateThisPrompt.find(".formErrorContent").html(promptText);

                callerTopPosition = $caller.offset().top;
                inputHeight = $updateThisPrompt.height()

                if (settings.promptPosition == "bottomLeft" || settings.promptPosition == "bottomRight") {
                    callerHeight = $caller.height()
                    callerTopPosition = callerTopPosition + callerHeight + 15
                }
                if (settings.promptPosition == "centerRight") { callerleftPosition += callerWidth + 13; }
                if (settings.promptPosition == "topLeft" || settings.promptPosition == "topRight") {
                    callerTopPosition = callerTopPosition - inputHeight - 10
                }
                $updateThisPrompt.animate({
                    top: callerTopPosition
                });
                return $updateThisPrompt;
            }

            function showInvalidPrompt(caller, message) {
                updatePromptText(caller, message, "error", false);
            }
            function hideInvalidPrompt(caller) {
                $("div." + caller.id).remove();
            }
            //#endregion

            function custErrorPlacement(error, inputElement) {  // 'this' is the form element
                var container = $(this).find("[data-valmsg-for='" + inputElement[0].name + "']");
                if (container.length == 0) {
                    container = $("<span data-valmsg-for='" + inputElement[0].name + "' />");
                    $(inputElement).after(container);
                }
                var msg = error.text();
                if (msg.length > 1)
                    error.data("inv_msg_prompt", showInvalidPrompt(inputElement[0], msg));
                else
                    hideInvalidPrompt(inputElement[0]);
            }

            function custSuccess(error) {  // 'this' is the form element
                var p = error.data("inv_msg_prompt");
                if (p) p.remove();
            }



            //#region change errorPlacement
            var valdSettings = $form.data("validator").settings;
            valdSettings.errorElement = "li";
            valdSettings.errorPlacement = $.proxy(custErrorPlacement, this);
            valdSettings.success = $.proxy(custSuccess, this);
            $form.validate(valdSettings);
            //#endregion
        });
    }
})(jQuery);