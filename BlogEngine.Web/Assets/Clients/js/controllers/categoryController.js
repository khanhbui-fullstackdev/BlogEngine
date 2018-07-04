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
                    var data = JSON.parse(result.data);

                    var treeConfig = {
                        data: data,
                        showTags: true,
                        enableLinks: true,
                        highlightSelected: false,
                        levels: 1
                    };
                    $('#tree').treeview(treeConfig);
                } else {
                    toastr.error(result.errorMessage, "Error");
                }
            },
            error: function (xhr, status, error) {
                toastr.error(result.errorMessage, "Error");
            }
        };
        $.ajax(ajaxConfig);
    }
}
categoryController.init();
