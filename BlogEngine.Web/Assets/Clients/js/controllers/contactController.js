var contactController = {
    init: function () {
        contactController.registerEvents();
        contactController.customRules();
    },
    registerEvents: function () {
        var frm_contactInfoConfig = {
            rules: {
                name: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                email: {
                    required: true,
                    email: true,
                    minlength: 12,
                    maxlenghth: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                message: {
                    required: true,
                    minlength: 2,
                    maxlength: 500,
                    preventScriptInjection: true,
                    preventHtmlInjection: false,
                    preventWhiteSpace: true
                },
                captchaCode: {
                    required: true,
                    preventScriptInjection: true,
                    preventHtmlInjection: false,
                    preventWhiteSpace: true
                }
            },
            messages: {
                email: {
                    required: 'Email is required',
                    email: 'Email is invalid',
                    minlength: 'Email requires at least 12 characters',
                    maxlenght: 'Email cannot length over 50 characters',
                    preventScriptInjection: 'Email cannot contain any javascript code',
                    preventHtmlInjection: 'Email cannot contain any html characters',
                    preventWhiteSpace: 'Email cannot contain any white space or empty string'
                },
                name: {
                    required: 'Name is required',
                    minlength: 'Name requires at least 2 characters',
                    maxlength: 'Name name cannot length over 255 characters',
                    preventScriptInjection: 'Name cannot contain any javascript code',
                    preventHtmlInjection: 'Name cannot contain any html characters',
                    preventWhiteSpace: 'Name cannot contain any white space or empty string'
                },
                message: {
                    required: 'Message is required',
                    minlength: 'Message requires at least 2 characters',
                    maxlength: 'Message name cannot length over 500 characters',
                    preventScriptInjection: 'Message cannot contain any javascript code',
                    preventWhiteSpace: 'Message cannot contain any white space or empty string'
                },
                captchaCode: {
                    required: 'Captcha is required',
                    preventScriptInjection: 'Captcha cannot contain any javascript code',
                    preventWhiteSpace: 'Captcha cannot contain any white space or empty string'
                },
            }
        };

        $('#frm_contactInfo').validate(frm_contactInfoConfig);
        var isValid = $('#frm_contactInfo').valid();
        if (isValid == false) {
            $('#btnAddContact').attr('disabled', 'disabled');
        }
        $('#btnAddContact').off('click').on('click', function (event) {
            // The event.preventDefault() method stops the default action of an element from happening.
            // Prevent a submit button from submitting a form
            // Prevent a link from following the URL
            event.preventDefault();

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
            contactController.addContact(contact);
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
            success: function (response, status, xhr) {
                if (response.status) {
                    toastr.success('Thank you for your feedback. I will contact you as soon as possible', 'Success');
                } else if (!response.status) {
                    if (!response.error)
                        toastr.error(response.error, 'Error');
                    else toastr.error('Something went wrong', 'Error');
                }
            }, error: function (xhr, status, error) {
                toastr.error(error, 'Error');
            }
        };
        $.ajax(ajaxConfig);
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