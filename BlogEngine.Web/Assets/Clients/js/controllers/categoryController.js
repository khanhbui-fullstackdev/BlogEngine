// https://stackoverflow.com/questions/7556400/injecting-content-into-specific-sections-from-a-partial-view-asp-net-mvc-3-with
/*
 * Sections don't work in partial views and that's by design. 
 * You may use some custom helpers to achieve similar behavior, 
 * but honestly it's the view's responsibility to include the necessary scripts, 
 * not the partial's responsibility. 
 * I would recommend using the @scripts section of the main view to do that 
 * and not have the partials worry about scripts.
 * */

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
categoryController.init();//call itselt
