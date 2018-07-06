var commonController = {
    init: function () {
        commonController.registerEvents();
    },
    registerEvents: function () {
        $.widget("custom.catcomplete", $.ui.autocomplete, {
            _create: function () {
                this._super();
                this.widget().menu("option", "items", "> :not(.ui-autocomplete-category)");
            },
            _renderMenu: function (ul, items) {
                var that = this,
                    currentCategory = "";
                $.each(items, function (index, item) {
                    var li;
                    if (item.category != currentCategory) {
                        ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
                        currentCategory = item.category;
                    }
                    li = that._renderItemData(ul, item);
                    if (item.category) {
                        li.attr("aria-label", item.category + " : " + item.label);
                    }
                });
            }
        });

        $('#txtSearch').catcomplete({
            delay: 500,
            minLength: 4,
            source: commonController.getPostsByKeyword,
        });
    },
    getPostsByKeyword: function (request, response) {
        var ajaxConfig = {
            // request:  request object, with a single term property, 
            // which refers to the value currently in the text input

            // response: A response callback, 
            // which expects a single argument: the data to suggest to the user

            url: '/Home/GetPostsByKeyword',
            type: 'POST',
            dataType: "json",
            data: {
                keyword: request.term,
            },
            success: function (result, status, xhr) {
                if (result.status) {
                    var data = JSON.parse(result.data);
                    response(data);
                } else {
                    toastr.error(result.error);
                }
            },
            error: function (xhr, status, error) {
                toastr.error(error);
            }
        };
        $.ajax(ajaxConfig);
    }
};
commonController.init();