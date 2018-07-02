var categoryController = {
    init: function () {
        categoryController.getCategories();
        categoryController.registerEvents();       
    },
    registerEvents: function () {
        // Event
    },
    getCategories: function () {
        var ajaxConfig = {
            url: '/Home/GetCategories',
            type: 'GET',
            dataType: 'json',            
            success: function (result, status, xhr) {
                if (result.status) {
                    
                    console.log(result.data);
                } else {
                    console.log(result.errorMessage);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
    }
}
categoryController.init();
