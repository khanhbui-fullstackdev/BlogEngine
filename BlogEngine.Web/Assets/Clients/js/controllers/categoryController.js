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
                        highlightSelected:false,
                        levels: 1
                    };
                    //$('#tree').attr('tags',[])
                    $('#tree').treeview(treeConfig);
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
