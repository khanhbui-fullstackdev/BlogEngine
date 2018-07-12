var contactController = {
    init: function () {
        contactController.registerEvents();
        contactController.customRules();
    },
    registerEvents: function () {
        var frm_contactInfoConfig = {
            rules: {
                ContactName: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                ContactEmail: {
                    required: true,
                    email: true,
                    minlength: 12,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                Content: {
                    required: true,
                    minlength: 2,
                    maxlength: 500,
                    preventScriptInjection: true,
                    preventHtmlInjection: false,
                    preventWhiteSpace: true
                },
                CaptchaCode: {
                    required: true,
                    preventScriptInjection: true,
                    preventHtmlInjection: false,
                    preventWhiteSpace: true
                }
            },
            messages: {
                ContactEmail: {
                    required: 'Email is required',
                    email: 'Email is invalid',
                    minlength: 'Email requires at least 12 characters',
                    maxlenght: 'Email cannot length over 50 characters',
                    preventScriptInjection: 'Email cannot contain any javascript code',
                    preventHtmlInjection: 'Email cannot contain any html characters',
                    preventWhiteSpace: 'Email cannot contain any white space or empty string'
                },
                ContactName: {
                    required: 'Name is required',
                    minlength: 'Name requires at least 2 characters',
                    maxlength: 'Name name cannot length over 255 characters',
                    preventScriptInjection: 'Name cannot contain any javascript code',
                    preventHtmlInjection: 'Name cannot contain any html characters',
                    preventWhiteSpace: 'Name cannot contain any white space or empty string'
                },
                Content: {
                    required: 'Message is required',
                    minlength: 'Message requires at least 2 characters',
                    maxlength: 'Message name cannot length over 500 characters',
                    preventScriptInjection: 'Message cannot contain any javascript code',
                    preventWhiteSpace: 'Message cannot contain any white space or empty string'
                },
                CaptchaCode: {
                    required: 'Captcha is required',
                    preventScriptInjection: 'Captcha cannot contain any javascript code',
                    preventWhiteSpace: 'Captcha cannot contain any white space or empty string'
                },
            }
        };
        $('#txtName').off('keyup').on('keyup', function (event) {
            var nameValid = $('#txtName').valid();
            switch (nameValid) {
                case true:
                    $('#txtName').removeClass('contact-fields-textbox-error');
                    $('#txtName-error').removeClass('contact-fields-label-error');
                    break;
                case false:
                    $('#txtName').addClass('contact-fields-textbox-error');
                    $('#txtName-error').addClass('contact-fields-label-error');
                    break;
            };
        });
        $('#txtEmail').off('keyup').on('keyup', function (event) {
            var nameValid = $('#txtEmail').valid();
            switch (nameValid) {
                case true:
                    $('#txtEmail').removeClass('contact-fields-textbox-error');
                    $('#txtEmail-error').removeClass('contact-fields-label-error');
                    break;
                case false:
                    $('#txtEmail').addClass('contact-fields-textbox-error');
                    $('#txtEmail-error').addClass('contact-fields-label-error');
                    break;
            };
        });

        $('#txtMessage').off('keyup').on('keyup', function (event) {
            var nameValid = $('#txtMessage').valid();
            switch (nameValid) {
                case true:
                    $('#txtMessage').removeClass('contact-fields-textbox-error');
                    $('#txtMessage-error').removeClass('contact-fields-label-error');
                    break;
                case false:
                    $('#txtMessage').addClass('contact-fields-textbox-error');
                    $('#txtMessage-error').addClass('contact-fields-label-error');
                    break;
            };
        });

        $('#txtCaptchaCode').off('keyup').on('keyup', function (event) {
            var nameValid = $('#txtCaptchaCode').valid();
            switch (nameValid) {
                case true:
                    $('#txtCaptchaCode').removeClass('contact-fields-textbox-error');
                    $('#txtCaptchaCode-error').removeClass('contact-fields-label-error');
                    break;
                case false:
                    $('#txtCaptchaCode').addClass('contact-fields-textbox-error');
                    $('#txtCaptchaCode-error').addClass('contact-fields-label-error');
                    break;
            };
        });

        $('#frm_contactInfo').validate(frm_contactInfoConfig);
        $('#btnAddContact').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_contactInfo').valid();
            if (isValid) {
                var contactName = $('#txtName').val();
                var contactEmail = $('#txtEmail').val();
                var contactMessage = $('#txtMessage').val();
                var captchaCode = $('#txtCaptchaCode').val();

                var contact = {
                    ContactName: contactName,
                    ContactEmail: contactEmail,
                    Content: contactMessage,
                    CaptchaCode: captchaCode
                };
                contactController.checkCaptcha(contact);
            } else { contactController.validatedFields(); }
        });
    },
    addContact: function (contact) {
        var ajaxConfig = {
            url: "/About/AddContact",
            data: {
                contactInfo: JSON.stringify(contact)
            },
            type: "POST",
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (response, status, xhr) {
                if (response.status) {
                    toastr.success('Thank you for your feedback. I will contact you as soon as possible', 'Success');
                    contact.clearText();
                } else {
                    toastr.error(response.error, 'Error');
                }
            }, error: function (xhr, status, error) {
                toastr.error(error, 'Error');
            }
        };
        $.ajax(ajaxConfig);
    },
    checkCaptcha: function (contact) {
        // get client-side Captcha object instance
        var captchaObj = $("#txtCaptchaCode").get(0).Captcha;

        // gather data required for Captcha validation
        var params = {}
        params.CaptchaId = captchaObj.Id;
        params.InstanceId = captchaObj.InstanceId;
        params.UserInput = $("#txtCaptchaCode").val();

        var url = '/About/CheckCaptcha';
        $.getJSON(url, params, function (result) {
            if (result === true) {
                contactController.addContact(contact);
            } else {
                $('#lblCaptcha').show();
                captchaObj.ReloadImage();
            }
        });
        event.preventDefault();
    },
    clearText: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtMessage').val('');
        $('#txtCaptchaCode').val('');
    },
    validatedFields: function () {
        var nameValid = $('#txtName').valid();
        var emailValid = $('#txtEmail').valid();
        var messageValid = $('#txtMessage').valid();
        var captchaValid = $('#txtCaptchaCode').valid();

        switch (nameValid) {
            case true:
                $('#txtName').removeClass('contact-fields-textbox-error');
                $('#txtName-error').removeClass('contact-fields-label-error');
                break;
            case false:
                $('#txtName').addClass('contact-fields-textbox-error');
                $('#txtName-error').addClass('contact-fields-label-error');
                break;
        };
        switch (emailValid) {
            case true:
                $('#txtEmail').removeClass('contact-fields-textbox-error');
                $('#txtEmail-error').removeClass('contact-fields-label-error');
                break;
            case false:
                $('#txtEmail').addClass('contact-fields-textbox-error');
                $('#txtEmail-error').addClass('contact-fields-label-error');
                break;
        };
        switch (messageValid) {
            case true:
                $('#txtMessage').removeClass('contact-fields-textbox-error');
                $('#txtMessage-error').removeClass('contact-fields-label-error');
                break;
            case false:
                $('#txtMessage').addClass('contact-fields-textbox-error');
                $('#txtMessage-error').addClass('contact-fields-label-error');
                break;
        };
        switch (captchaValid) {
            case true:
                $('#txtCaptchaCode').removeClass('contact-fields-textbox-error');
                $('#txtCaptchaCode-error').removeClass('contact-fields-label-error');
                break;
            case false:
                $('#txtCaptchaCode').addClass('contact-fields-textbox-error');
                $('#txtCaptchaCode-error').addClass('contact-fields-label-error');
                break;
        };
    },
    customRules: function () {
        jQuery.validator.addMethod('preventScriptInjection', function (value, element, params) {
            if (value.toLowerCase().search('<script>') !== -1 || value.toLowerCase().search('</script>') !== -1)
                return false; // has script
            return true; // none script
        }, '');
        jQuery.validator.addMethod('preventHtmlInjection', function (value, element, params) {
            var htmlPattern = new RegExp(/<[a-z][\s\S]*>/i);
            if (htmlPattern.test(value))
                return false; // has html
            return true; // none html
        }, '');
        jQuery.validator.addMethod('preventWhiteSpace', function (value, element, params) {
            if (value.trim() === '')
                return false; // has empty string
            return true; // none empty string
        }, '');
    }
};
contactController.init();//call itself